using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using OBS;
using OBS.Model;

namespace ObsUtilGUI {
    
    public partial class WinMain : Form {

        private ObsClient obsClient = new ObsClient("access_key", "secret_key", "url_endpoint");

        bool localTypeIsFile = false;
        string oldTxtLocalDirText = string.Empty;
        List<string> allLocalPath = new List<string>();
        string selectedLocalPath = string.Empty;

        bool remoteTypeIsFile = false;
        List<Icon> ilRemoteDirTemp = new List<Icon>();
        List<string> allRemotePath = new List<string>();
        string selectedRemotePath = string.Empty;
        string oldTxtRemoteDirText = string.Empty;
        IDictionary<string, dynamic> remoteDirTree = new Dictionary<string, dynamic>();

        IProgress<Tuple<DataGridViewRow, string>> onGoingStatus = null;
        IProgress<Tuple<DataGridViewRow, TransferStatus>> onGoingProgress = null;
        IProgress<Tuple<DataGridViewRow, int>> onStopProgress = null;

        [DllImport("urlmon.dll", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = false)]
        private static extern int FindMimeFromData(
            IntPtr pBC,
            [MarshalAs(UnmanagedType.LPWStr)] string pwzUrl,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1, SizeParamIndex = 3)] byte[] pBuffer,
            int cbSize,
            [MarshalAs(UnmanagedType.LPWStr)] string pwzMimeProposed,
            int dwMimeFlags,
            out IntPtr ppwzMimeOut,
            int dwReserved
        );

        public static string GetMimeFromFile(string filename) {
            if (!File.Exists(filename)) {
                throw new FileNotFoundException(filename + " Not Found");
            }
            const int maxContent = 256;
            var buffer = new byte[maxContent];
            using (var fs = new FileStream(filename, FileMode.Open)) {
                if (fs.Length >= maxContent) {
                    fs.Read(buffer, 0, maxContent);
                }
                else {
                    fs.Read(buffer, 0, (int)fs.Length);
                }
            }
            IntPtr mimeTypePtr = IntPtr.Zero;
            try {
                var result = FindMimeFromData(IntPtr.Zero, null, buffer, maxContent, null, 0, out mimeTypePtr, 0);
                if (result != 0) {
                    Marshal.FreeCoTaskMem(mimeTypePtr);
                    throw Marshal.GetExceptionForHR(result);
                }
                var mime = Marshal.PtrToStringUni(mimeTypePtr);
                Marshal.FreeCoTaskMem(mimeTypePtr);
                return mime;
            }
            catch {
                if (mimeTypePtr != IntPtr.Zero) {
                    Marshal.FreeCoTaskMem(mimeTypePtr);
                }
                return "unknown/unknown";
            }
        }

        public WinMain() {
            InitializeComponent();
            InitializeDataGridUpDownProgressStatus();
        }

        private void WinMain_Load(object sender, EventArgs e) {
            txtLocalDir.Text = Application.StartupPath;

            onGoingStatus = new Progress<Tuple<DataGridViewRow, string>>(obj => {
                DataGridViewRow dgvr = obj.Item1;
                string status = obj.Item2;

                dgvr.Cells[dgOnProgress.Columns["dgOnProgress_Status"].Index].Value = status;

                ClearDataGridSelection();
            });

            onGoingProgress = new Progress<Tuple<DataGridViewRow, TransferStatus>>(obj => {
                DataGridViewRow dgvr = obj.Item1;
                TransferStatus transferStatus = obj.Item2;

                string transferSpeed = $"{(transferStatus.InstantaneousSpeed / 1000):0.00} KB/s";
                decimal transferPercentage = transferStatus.TransferPercentage;

                dgvr.Cells[dgOnProgress.Columns["dgOnProgress_Progress"].Index].Value = transferPercentage;
                dgvr.Cells[dgOnProgress.Columns["dgOnProgress_Speed"].Index].Value = transferSpeed;

                ClearDataGridSelection();
            });

            onStopProgress = new Progress<Tuple<DataGridViewRow, int>>(async obj => {
                DataGridViewRow dgvr = obj.Item1;
                int statusCode = obj.Item2;

                if (statusCode >= 200 && statusCode < 300) {
                    string filePath = dgvr.Cells[dgOnProgress.Columns["dgOnProgress_FileLocal"].Index].Value.ToString();

                    dgSuccess.Rows.Add(
                        dgvr.Cells[dgOnProgress.Columns["dgOnProgress_FileLocal"].Index].Value,
                        dgvr.Cells[dgOnProgress.Columns["dgOnProgress_Direction"].Index].Value,
                        dgvr.Cells[dgOnProgress.Columns["dgOnProgress_FileRemote"].Index].Value,
                        dgvr.Cells[dgOnProgress.Columns["dgOnProgress_Progress"].Index].Value,
                        "Completed ..."
                    );
                    dgOnProgress.Rows.Remove(dgvr);

                    DialogResult dialogResult =
                        cbDeleteOnComplete.Checked ?
                            DialogResult.Yes :
                                MessageBox.Show(
                                    $"Delete File '{filePath}'",
                                    "Upload Finished",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question
                                );
                    if (dialogResult == DialogResult.Yes) {
                        FileInfo fi = new FileInfo(filePath);
                        if (fi.Exists) {
                            fi.Delete();
                        }
                    }
                }
                else {
                    dgErrorFail.Rows.Add(
                        dgvr.Cells[dgOnProgress.Columns["dgOnProgress_FileLocal"].Index].Value,
                        dgvr.Cells[dgOnProgress.Columns["dgOnProgress_Direction"].Index].Value,
                        dgvr.Cells[dgOnProgress.Columns["dgOnProgress_FileRemote"].Index].Value,
                        dgvr.Cells[dgOnProgress.Columns["dgOnProgress_Progress"].Index].Value,
                        "Failed ..."
                    );
                    dgOnProgress.Rows.Remove(dgvr);
                }

                await LoadRemoteDir();
                await ViewRemoteDir();
                ClearDataGridSelection();
            });

            LoadLocalDir();
        }

        private void InitializeDataGridUpDownProgressStatus() {
            #region Initialize Data Grid View Column

            DataGridViewCellStyle dgViewCellStyle = new DataGridViewCellStyle {
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            dgOnProgress.Columns.Add(new DataGridViewTextBoxColumn {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                HeaderText = "File Local",
                Name = "dgOnProgress_FileLocal",
                ReadOnly = true
            });
            dgOnProgress.Columns.Add(new DataGridViewTextBoxColumn {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                DefaultCellStyle = dgViewCellStyle,
                HeaderText = "Direction",
                Name = "dgOnProgress_Direction",
                ReadOnly = true
            });
            dgOnProgress.Columns.Add(new DataGridViewTextBoxColumn {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                HeaderText = "File Remote",
                Name = "dgOnProgress_FileRemote",
                ReadOnly = true
            });
            dgOnProgress.Columns.Add(new DataGridViewProgressColumn {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                DefaultCellStyle = dgViewCellStyle,
                HeaderText = "Progress",
                MinimumWidth = 100,
                Name = "dgOnProgress_Progress",
                ReadOnly = true
            });
            dgOnProgress.Columns.Add(new DataGridViewTextBoxColumn {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                HeaderText = "Speed",
                Name = "dgOnProgress_Speed",
                ReadOnly = true
            });
            dgOnProgress.Columns.Add(new DataGridViewTextBoxColumn {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                HeaderText = "Status",
                MinimumWidth = 100,
                Name = "dgOnProgress_Status",
                ReadOnly = true
            });
            dgOnProgress.Columns.Add(new DataGridViewButtonColumn {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                DefaultCellStyle = dgViewCellStyle,
                HeaderText = "Action",
                Name = "dgOnProgress_Cancel",
                Text = "Cancel",
                ReadOnly = true,
                FlatStyle = FlatStyle.Flat,
                UseColumnTextForButtonValue = true
            });

            dgOnProgress.EnableHeadersVisualStyles = false;

            dgErrorFail.Columns.Add(new DataGridViewTextBoxColumn {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                HeaderText = "File Local",
                Name = "dgErrorFail_FileLocal",
                ReadOnly = true
            });
            dgErrorFail.Columns.Add(new DataGridViewTextBoxColumn {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                DefaultCellStyle = dgViewCellStyle,
                HeaderText = "Direction",
                Name = "dgErrorFail_Direction",
                ReadOnly = true
            });
            dgErrorFail.Columns.Add(new DataGridViewTextBoxColumn {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                HeaderText = "File Remote",
                Name = "dgErrorFail_FileRemote",
                ReadOnly = true
            });
            dgErrorFail.Columns.Add(new DataGridViewProgressColumn {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                DefaultCellStyle = dgViewCellStyle,
                HeaderText = "Progress",
                MinimumWidth = 100,
                Name = "dgErrorFail_Progress",
                ReadOnly = true
            });
            dgErrorFail.Columns.Add(new DataGridViewTextBoxColumn {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                HeaderText = "Status",
                MinimumWidth = 100,
                Name = "dgErrorFail_Status",
                ReadOnly = true
            });
            dgErrorFail.Columns.Add(new DataGridViewButtonColumn {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                DefaultCellStyle = dgViewCellStyle,
                HeaderText = "Action",
                Name = "dgErrorFail_Retry",
                Text = "Retry",
                ReadOnly = true,
                FlatStyle = FlatStyle.Flat,
                UseColumnTextForButtonValue = true
            });

            dgErrorFail.EnableHeadersVisualStyles = false;

            dgSuccess.Columns.Add(new DataGridViewTextBoxColumn {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                HeaderText = "File Local",
                Name = "dgSuccess_FileLocal",
                ReadOnly = true
            });
            dgSuccess.Columns.Add(new DataGridViewTextBoxColumn {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                DefaultCellStyle = dgViewCellStyle,
                HeaderText = "Direction",
                Name = "dgSuccess_Direction",
                ReadOnly = true
            });
            dgSuccess.Columns.Add(new DataGridViewTextBoxColumn {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                HeaderText = "File Remote",
                Name = "dgSuccess_FileRemote",
                ReadOnly = true
            });
            dgSuccess.Columns.Add(new DataGridViewProgressColumn {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                DefaultCellStyle = dgViewCellStyle,
                HeaderText = "Progress",
                MinimumWidth = 100,
                Name = "dgSuccess_Progress",
                ReadOnly = true
            });
            dgSuccess.Columns.Add(new DataGridViewTextBoxColumn {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                HeaderText = "Status",
                MinimumWidth = 100,
                Name = "dgSuccess_Status",
                ReadOnly = true
            });

            dgSuccess.EnableHeadersVisualStyles = false;

            #endregion
        }

        /* ** */

        private void FilterLocalDir() {
            lvLocalDir.Items.Clear();
            lvLocalDir.Items.Add("..", 0);
            for(int i = 0; i < allLocalPath.Count; i++) {
                string filePath = allLocalPath[i].ToLower();
                string fileNameFilter = txtFilterLocalDir.Text.ToLower();
                string fileExtensionFilter = ConfigurationManager.AppSettings["local_allowed_file_ext"] ?? string.Empty;
                bool isFile = Regex.Match(filePath, @" \(\d+ bytes\)").Success;
                bool isAllowed = filePath.Contains(fileNameFilter);
                if (isFile && !string.IsNullOrEmpty(fileExtensionFilter)) {
                    isAllowed = isAllowed && filePath.Contains(fileExtensionFilter);
                }
                if (isAllowed) {
                    lvLocalDir.Items.Add(filePath, i + 1);
                }
            }
            oldTxtLocalDirText = txtLocalDir.Text;
            btnUpload.Enabled = false;
            selectedLocalPath = string.Empty;
        }

        private void LoadLocalDir() {
            try {
                if (string.IsNullOrEmpty(txtLocalDir.Text)) {
                    txtLocalDir.Text = Application.StartupPath;
                }
                ilLocalDir.Images.Clear();
                allLocalPath.Clear();
                ilLocalDir.Images.Add(DefaultIcons.FolderLarge);
                DirectoryInfo di = new DirectoryInfo(txtLocalDir.Text);
                FileSystemInfo[] fsis = di.GetFileSystemInfos();
                for (int i = 0; i < fsis.Length; i++) {
                    string name = fsis[i].Name;
                    Icon ico = DefaultIcons.FolderLarge;
                    if (!fsis[i].Attributes.HasFlag(FileAttributes.Directory)) {
                        ico = Icon.ExtractAssociatedIcon(fsis[i].FullName);
                        FileInfo fi = new FileInfo(fsis[i].FullName);
                        name += $" ({fi.Length} bytes)";
                    }
                    ilLocalDir.Images.Add(ico);
                    allLocalPath.Add(name);
                }
                FilterLocalDir();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Local Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFilterLocalDir_TextChanged(object sender, EventArgs e) {
            FilterLocalDir();
        }

        private void btnLocalDirRefresh_Click(object sender, EventArgs e) {
            LoadLocalDir();
        }
        private void txtLocalDir_Enter(object sender, EventArgs e) {
            oldTxtLocalDirText = txtLocalDir.Text;
        }

        private void txtLocalDir_Leave(object sender, EventArgs e) {
            txtLocalDir.Text = oldTxtLocalDirText;
        }

        private void TxtLocalDir_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Escape:
                    txtLocalDir.Text = oldTxtLocalDirText;
                    break;
                case Keys.Enter:
                    LoadLocalDir();
                    break;
                default:
                    break;
            }
        }

        private void lvLocalDir_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            localTypeIsFile = Regex.Match(e.Item.Text, @" \(\d+ bytes\)").Success;
            string selectedName = Regex.Replace(e.Item.Text, @" \(\d+ bytes\)", string.Empty);
            string newSelectedName = Path.Combine(txtLocalDir.Text, selectedName);
            selectedLocalPath = (selectedLocalPath == newSelectedName) ? string.Empty : newSelectedName;
            btnUpload.Enabled = !string.IsNullOrEmpty(selectedLocalPath);
        }

        private void lvLocalDir_MouseDoubleClick(object sender, MouseEventArgs e) {
            try {
                string currentLocalPath = Path.GetFullPath(txtLocalDir.Text);
                ListView.SelectedListViewItemCollection x = lvLocalDir.SelectedItems;
                if (x.Count == 1) {
                    FileInfo fi = new FileInfo(selectedLocalPath);
                    if (fi.Attributes.HasFlag(FileAttributes.Directory)) {
                        if (x[0].Text == "..") {
                            string parentLocalPath = Directory.GetParent(currentLocalPath)?.FullName;
                            txtLocalDir.Text = parentLocalPath;
                            selectedLocalPath = string.Empty;
                        }
                        else {
                            txtLocalDir.Text = selectedLocalPath;
                        }
                    }
                }
                LoadLocalDir();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Local Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* ** */

        private void SetBusy(bool isBusy) {
            txtRemoteDir.ReadOnly = isBusy;
            btnRemoteDirRefresh.Enabled = !isBusy;
            txtFilterRemoteDir.ReadOnly = isBusy;
            lvRemoteDir.Enabled = !isBusy;
            btnRemoteNewFolder.Enabled = !isBusy;
            btnUpload.Enabled = !isBusy && !string.IsNullOrEmpty(selectedLocalPath);
            btnDownload.Enabled = !isBusy && !string.IsNullOrEmpty(selectedRemotePath);
            btnRemoteMoveRename.Enabled = !isBusy && !string.IsNullOrEmpty(selectedRemotePath);
            btnRemoteDelete.Enabled = !isBusy && !string.IsNullOrEmpty(selectedRemotePath);
        }

        private void FilterRemoteDir() {
            lvRemoteDir.Items.Clear();
            if (!string.IsNullOrEmpty(txtRemoteDir.Text)) {
                lvRemoteDir.Items.Add("..", 0);
            }
            for (int i = 0; i < allRemotePath.Count; i++) {
                if (allRemotePath[i].ToLower().Contains(txtFilterRemoteDir.Text.ToLower())) {
                    lvRemoteDir.Items.Add(allRemotePath[i], i + 1);
                }
            }
            oldTxtRemoteDirText = txtRemoteDir.Text;
            btnDownload.Enabled = false;
            btnRemoteDelete.Enabled = false;
            btnRemoteMoveRename.Enabled = false;
            selectedRemotePath = string.Empty;
        }

        private async Task ViewRemoteDir(bool stopRecursive = false) {
            try {
                if (string.IsNullOrEmpty(txtRemoteDir.Text)) {
                    await LoadRemoteDir();
                    return;
                }
                string[] dirPath = txtRemoteDir.Text.Split('/');
                IDictionary<string, dynamic> ptr = remoteDirTree[dirPath[0]];
                for (int i = 1; i < dirPath.Length; i++) {
                    if (ptr.ContainsKey(dirPath[i])) {
                        ptr = ptr[dirPath[i]];
                    }
                }
                if (ptr.Count == 0) {
                    await LoadRemoteDir();
                    if (!stopRecursive) {
                        await ViewRemoteDir(true);
                        return;
                    }
                }
                ilRemoteDir.Images.Clear();
                allRemotePath.Clear();
                ilRemoteDir.Images.Add(DefaultIcons.FolderLarge);
                foreach (KeyValuePair<string, dynamic> p in ptr) {
                    bool isDir = p.Value.GetType() == typeof(Dictionary<string, dynamic>);
                    string name = p.Key;
                    Icon ico = DefaultIcons.FolderLarge;
                    if (!isDir) {
                        ico = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
                        name += $" ({p.Value} bytes)";
                    }
                    ilRemoteDir.Images.Add(ico);
                    allRemotePath.Add(name);
                }
                FilterRemoteDir();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "List All Objects In Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadRemoteDir() {
            try {
                SetBusy(true);
                if (string.IsNullOrEmpty(txtRemoteDir.Text)) {
                    ilRemoteDir.Images.Clear();
                    ilRemoteDir.Images.Add(DefaultIcons.FolderLarge);
                    ilRemoteDirTemp.Clear();
                    allRemotePath.Clear();
                    await Task.Factory.StartNew(() => {
                        try {
                            ListBucketsRequest request = new ListBucketsRequest();
                            ListBucketsResponse response = obsClient.ListBuckets(request);
                            foreach (ObsBucket bucket in response.Buckets) {
                                if (!remoteDirTree.ContainsKey(bucket.BucketName)) {
                                    remoteDirTree[bucket.BucketName] = new Dictionary<string, dynamic>();
                                }
                                ilRemoteDirTemp.Add(DefaultIcons.FolderLarge);
                                allRemotePath.Add(bucket.BucketName);
                            }
                        }
                        catch (Exception ex) {
                            MessageBox.Show(ex.Message, "List All Bucket", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                    foreach (Icon ico in ilRemoteDirTemp) {
                        ilRemoteDir.Images.Add(DefaultIcons.FolderLarge);
                    }
                    FilterRemoteDir();
                }
                else {
                    await Task.Factory.StartNew(() => {
                        try {
                            ListObjectsRequest request = new ListObjectsRequest() {
                                BucketName = txtRemoteDir.Text.Split('/').First()
                            };
                            ListObjectsResponse response = obsClient.ListObjects(request);
                            foreach (ObsObject obsObj in response.ObsObjects) {
                                string[] obj = obsObj.ObjectKey.Split('/');
                                var ptr = remoteDirTree[request.BucketName];
                                for (int i = 0; i < obj.Length - 1; i++) {
                                    if (!ptr.ContainsKey(obj[i])) {
                                        ptr[obj[i]] = new Dictionary<string, dynamic>();
                                    }
                                    ptr = ptr[obj[i]];
                                }
                                if (!string.IsNullOrEmpty(obj[obj.Length - 1])) {
                                    ptr[obj[obj.Length - 1]] = obsObj.Size;
                                }
                            }
                        }
                        catch (Exception ex) {
                            MessageBox.Show(ex.Message, "List All Objects In Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                }
                DateTime timeStamp = DateTime.Now;
                lblDate.Text = $"{timeStamp:dd-MM-yyyy}";
                lblTime.Text = $"{timeStamp:HH:mm:ss}";
                SetBusy(false);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Remote Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenConfig_Click(object sender, EventArgs e) {
            txtEndpoint.Text = ConfigurationManager.AppSettings["remote_url_endpoint"] ?? string.Empty;
            txtAccessKey.Text = ConfigurationManager.AppSettings["remote_access_key"] ?? string.Empty;
            txtSecretKey.Text = ConfigurationManager.AppSettings["remote_secret_key"] ?? string.Empty;
        }

        private async void btnConnect_Click(object sender, EventArgs e) {
            SetBusy(true);
            if (!string.IsNullOrEmpty(txtAccessKey.Text) && !string.IsNullOrEmpty(txtSecretKey.Text) && !string.IsNullOrEmpty(txtEndpoint.Text)) {
                obsClient = new ObsClient(txtAccessKey.Text, txtSecretKey.Text, txtEndpoint.Text);
                await LoadRemoteDir();
            }
            else {
                MessageBox.Show("Please Insert Your Credential Information", "Authorization", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SetBusy(false);
        }

        private async void btnRemoteDirRefresh_Click(object sender, EventArgs e) {
            await LoadRemoteDir();
            await ViewRemoteDir();
        }

        private void txtFilterRemoteDir_TextChanged(object sender, EventArgs e) {
            FilterRemoteDir();
        }

        private void txtRemoteDir_Enter(object sender, EventArgs e) {
            oldTxtRemoteDirText = txtRemoteDir.Text;
        }

        private void txtRemoteDir_Leave(object sender, EventArgs e) {
            txtRemoteDir.Text = oldTxtRemoteDirText;
        }

        private async void txtRemoteDir_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Escape:
                    txtRemoteDir.Text = oldTxtRemoteDirText;
                    break;
                case Keys.Enter:
                    await ViewRemoteDir();
                    break;
                default:
                    break;
            }
        }

        private void lvRemoteDir_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            remoteTypeIsFile = Regex.Match(e.Item.Text, @" \(\d+ bytes\)").Success;
            string selectedName = Regex.Replace(e.Item.Text, @" \(\d+ bytes\)", string.Empty);
            string newSelectedName = Path.Combine(txtRemoteDir.Text, selectedName).Replace("\\", "/");
            selectedRemotePath = (selectedRemotePath == newSelectedName) ? string.Empty : newSelectedName;
            btnDownload.Enabled = !string.IsNullOrEmpty(selectedRemotePath);
            btnRemoteDelete.Enabled = !string.IsNullOrEmpty(selectedRemotePath);
            btnRemoteMoveRename.Enabled = !string.IsNullOrEmpty(selectedRemotePath);
        }

        private async void lvRemoteDir_MouseDoubleClick(object sender, MouseEventArgs e) {
            try {
                string currentRemotePath = txtRemoteDir.Text;
                ListView.SelectedListViewItemCollection x = lvRemoteDir.SelectedItems;
                if (x.Count == 1) {
                    string[] dirPath = selectedRemotePath.Split('/');
                    var ptr = remoteDirTree[dirPath[0]];
                    for (int i = 1; i < dirPath.Length; i++) {
                        if (ptr.ContainsKey(dirPath[i])) {
                            ptr = ptr[dirPath[i]];
                        }
                    }
                    bool isDir = ptr.GetType() == typeof(Dictionary<string, dynamic>);
                    if (isDir) {
                        if (x[0].Text == "..") {
                            string parentRemotePath = string.Join("/", selectedRemotePath.Split('/').Reverse().Skip(2).Reverse().ToArray());
                            txtRemoteDir.Text = parentRemotePath;
                            selectedRemotePath = string.Empty;
                        }
                        else {
                            txtRemoteDir.Text = selectedRemotePath;
                        }
                    }
                }
                if (string.IsNullOrEmpty(txtRemoteDir.Text)) {
                    await LoadRemoteDir();
                }
                else {
                    await ViewRemoteDir();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Remote Path Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* ** */

        private void ClearDataGridSelection() {
            dgOnProgress.ClearSelection();
            dgSuccess.ClearSelection();
            dgErrorFail.ClearSelection();
        }

        private bool checkProgressIsRunning(string localPath, string remotePath) {
            foreach (DataGridViewRow row in dgOnProgress.Rows) {
                if (
                    row.Cells[dgOnProgress.Columns["dgOnProgress_FileLocal"].Index].Value.ToString().Equals(localPath) &&
                    row.Cells[dgOnProgress.Columns["dgOnProgress_FileRemote"].Index].Value.ToString().Equals(remotePath)
                ) {
                    return true;
                }
            }
            return false;
        }

        private async void btnUpload_Click(object sender, EventArgs e) {
            try {
                if (!string.IsNullOrEmpty(oldTxtRemoteDirText) && !string.IsNullOrEmpty(selectedLocalPath) && !selectedLocalPath.Contains("..") && localTypeIsFile) {
                    string targetBucket = oldTxtRemoteDirText.Split('/').First();
                    string targetPathRemote = Path.Combine(string.Join("/", oldTxtRemoteDirText.Split('/').Skip(1)), selectedLocalPath.Replace("\\", "/").Split('/').Last()).Replace("\\", "/");

                    if (checkProgressIsRunning(selectedLocalPath, $"OBS://{targetBucket}/{targetPathRemote}")) {
                        MessageBox.Show("Progress Already Running", "On-Going Added", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string allowedMime = ConfigurationManager.AppSettings["local_allowed_file_mime"] ?? string.Empty;
                    if (!string.IsNullOrEmpty(allowedMime)) {
                        string selectedMime = GetMimeFromFile(selectedLocalPath);
                        if (selectedMime != allowedMime) {
                            MessageBox.Show("Wrong MiMe Type", "File Rejected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string signFull = ConfigurationManager.AppSettings["local_allowed_file_sign"] ?? string.Empty;
                    if (!string.IsNullOrEmpty(signFull)) {
                        FileInfo fi = new FileInfo(selectedLocalPath);
                        string[] signSplit = signFull.Split(' ');
                        int minFileSize = signSplit.Length;
                        if (fi.Length < minFileSize) {
                            MessageBox.Show("Invalid File Size", "File Rejected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        try {
                            int[] intList = new int[minFileSize];
                            for (int i = 0; i < intList.Length; i++) {
                                if (signSplit[i] == "??") {
                                    intList[i] = -1;
                                }
                                else {
                                    intList[i] = int.Parse(signSplit[i], NumberStyles.HexNumber);
                                }
                            }
                            using (BinaryReader reader = new BinaryReader(new FileStream(selectedLocalPath, FileMode.Open))) {
                                bool valid = false;
                                byte[] buff = new byte[minFileSize];
                                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                                reader.Read(buff, 0, buff.Length);
                                for (int a = 0; a < buff.Length; a++) {
                                    for (int b = 0; b < intList.Length; b++) {
                                        if (intList[b] != -1 && intList[b] != buff[a + b]) {
                                            break;
                                        }
                                        if (b + 1 == intList.Length) {
                                            valid = true;
                                        }
                                    }
                                }
                                if (!valid) {
                                    throw new Exception("Signature Verification Failed");
                                }
                            }
                        }
                        catch (Exception ex) {
                            MessageBox.Show(ex.Message, "File Rejected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string[] dirPath = oldTxtRemoteDirText.Split('/');
                    var ptr = remoteDirTree[dirPath[0]];
                    for (int i = 1; i < dirPath.Length; i++) {
                        if (ptr.ContainsKey(dirPath[i])) {
                            ptr = ptr[dirPath[i]];
                        }
                    }

                    DialogResult dialogResult = DialogResult.Yes;
                    string selectedName = selectedLocalPath.Replace("\\", "/").Split('/').Reverse().First();
                    if (ptr.ContainsKey(selectedName)) {
                        dialogResult = MessageBox.Show($"Replace '{selectedName}'", "File Already Exist", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }

                    if (dialogResult == DialogResult.Yes) {

                        int idx = dgOnProgress.Rows.Add(selectedLocalPath, "===>>>", $"OBS://{targetBucket}/{targetPathRemote}", 0, "0 B/s", "Checking ...");
                        DataGridViewRow dgvr = dgOnProgress.Rows[idx];

                        await Task.Factory.StartNew(() => {
                            try {
                                UploadFileRequest request = new UploadFileRequest {
                                    BucketName = targetBucket,
                                    ObjectKey = targetPathRemote,
                                    UploadFile = selectedLocalPath,
                                    UploadPartSize = 10 * (long) Math.Pow(2, 20),
                                    EnableCheckpoint = true,
                                    EnableCheckSum = true,
                                    UploadProgress = (sndr, evnt) => {
                                        onGoingStatus.Report(Tuple.Create(dgvr, "Uploading ..."));
                                        onGoingProgress.Report(Tuple.Create(dgvr, evnt));
                                    }
                                };

                                CompleteMultipartUploadResponse response = obsClient.UploadFile(request);
                                onStopProgress.Report(Tuple.Create(dgvr, (int) response.StatusCode));
                            }
                            catch (ObsException ex) {
                                MessageBox.Show(ex.Message, "Upload Chunk Part", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        });

                    }
                }
            }
            catch (Exception exception) {
                MessageBox.Show(exception.Message, "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDownload_Click(object sender, EventArgs e) {
            try {
                if (!string.IsNullOrEmpty(oldTxtRemoteDirText) && !string.IsNullOrEmpty(selectedRemotePath) && !selectedRemotePath.Contains("..") && remoteTypeIsFile) {
                    string targetBucket = oldTxtRemoteDirText.Split('/').First();
                    string targetPathRemote = $"{string.Join("/", oldTxtRemoteDirText.Split('/').Skip(1))}/{selectedRemotePath.Split('/').Last()}";
                    string targetPathLocal = Path.Combine(oldTxtLocalDirText, targetPathRemote.Split('/').Reverse().First());

                    if (checkProgressIsRunning(targetPathLocal, $"OBS://{targetBucket}/{targetPathRemote}")) {
                        MessageBox.Show("Progress Already Running", "On-Going Added", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DialogResult dialogResult = DialogResult.Yes;
                    string selectedName = selectedRemotePath.Split('/').Reverse().First();
                    if (File.Exists(targetPathLocal)) {
                        dialogResult = MessageBox.Show($"Replace '{selectedName}'", "File Already Exist", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }

                    if (dialogResult == DialogResult.Yes) {

                        int idx = dgOnProgress.Rows.Add(targetPathLocal, "<<<===", $"OBS://{targetBucket}/{targetPathRemote}", 0, "0 B/s", "Checking ...");
                        DataGridViewRow dgvr = dgOnProgress.Rows[idx];

                        await Task.Factory.StartNew(() => {
                            DownloadFileRequest request = new DownloadFileRequest {
                                BucketName = targetBucket,
                                ObjectKey = targetPathRemote,
                                DownloadFile = targetPathLocal,
                                DownloadPartSize = 10 * (long) Math.Pow(2, 20),
                                EnableCheckpoint = true,
                                DownloadProgress = (sndr, evnt) => {
                                    onGoingStatus.Report(Tuple.Create(dgvr, "Downloading ..."));
                                    onGoingProgress.Report(Tuple.Create(dgvr, evnt));
                                }
                            };

                            GetObjectMetadataResponse response = obsClient.DownloadFile(request);
                            onStopProgress.Report(Tuple.Create(dgvr, (int) response.StatusCode));
                        });

                        LoadLocalDir();

                    }
                }
            }
            catch (Exception exception) {
                MessageBox.Show(exception.Message, "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRemoteDelete_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(oldTxtRemoteDirText) && !string.IsNullOrEmpty(selectedRemotePath) && !selectedRemotePath.Contains("..")) {
                string selectedName = selectedRemotePath.Split('/').Reverse().First();
                DialogResult dialogResult = MessageBox.Show($"Are You Sure Want To Delete '{selectedName}'", "Delete File / Folder", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes) {
                    string targetBucket = oldTxtRemoteDirText.Split('/').First();
                    string targetPath = Path.Combine(string.Join("/", oldTxtRemoteDirText.Split('/').Skip(1)), selectedRemotePath.Split('/').Last()).Replace("\\", "/");

                    if (remoteTypeIsFile) {
                        await Task.Factory.StartNew(() => {
                            DeleteObjectRequest request = new DeleteObjectRequest() {
                                BucketName = targetBucket,
                                ObjectKey = $"{targetPath}{(remoteTypeIsFile ? "" : "/")}"
                            };
                            DeleteObjectResponse response = obsClient.DeleteObject(request);
                        });

                        string[] dirPath = selectedRemotePath.Split('/');
                        var ptr = remoteDirTree[dirPath[0]];
                        for (int i = 1; i < dirPath.Length; i++) {
                            if (ptr.ContainsKey(selectedName)) {
                                ptr.Remove(selectedName);
                            }
                            else if (ptr.ContainsKey(dirPath[i])) {
                                ptr = ptr[dirPath[i]];
                            }
                        }

                        await LoadRemoteDir();
                        await ViewRemoteDir();
                    }
                    else {

                        // TODO ::
                        MessageBox.Show("SDK's Feature Not Available", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRemoteMoveRename_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(oldTxtRemoteDirText) && !string.IsNullOrEmpty(selectedRemotePath) && !selectedRemotePath.Contains("..")) {
                string fileName = selectedRemotePath;
                DialogInput.ShowInputDialog(ref fileName, "Move / Rename");
                if (string.IsNullOrEmpty(fileName)) {
                    MessageBox.Show("Path File Cannot Is Empty", "Move / Rename", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // TODO ::
                MessageBox.Show("SDK's Feature Not Available", "Move / Rename", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRemoteNewFolder_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(oldTxtRemoteDirText)) {
                string folderName = "New Folder";
                DialogInput.ShowInputDialog(ref folderName, "New Folder");
                if (string.IsNullOrEmpty(folderName)) {
                    MessageBox.Show("Folder Name Cannot Is Empty", "New Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string targetBucket = oldTxtRemoteDirText.Split('/').First();
                string targetPath = Path.Combine(string.Join("/", oldTxtRemoteDirText.Split('/').Skip(1)), $"{folderName}/").Replace("\\", "/");

                await Task.Factory.StartNew(() => {
                    PutObjectRequest request = new PutObjectRequest() {
                        BucketName = targetBucket,
                        ObjectKey = targetPath
                    };
                    PutObjectResponse response = obsClient.PutObject(request);
                });

                await LoadRemoteDir();
                await ViewRemoteDir();
            }
        }

        private void dgOnProgress_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == dgOnProgress.Columns["dgOnProgress_Cancel"].Index) {

                // TODO ::
                MessageBox.Show("SDK's Feature Not Available", "Cancel Upload / Download", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgErrorFail_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == dgOnProgress.Columns["dgErrorFail_Retry"].Index) {

                // TODO ::
                MessageBox.Show("SDK's Feature Not Available", "Retry Upload / Download", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}
