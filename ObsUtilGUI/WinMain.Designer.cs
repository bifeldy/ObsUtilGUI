
namespace ObsUtilGUI {

    partial class WinMain {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.lblAccessKey = new System.Windows.Forms.Label();
            this.lblSecretKey = new System.Windows.Forms.Label();
            this.txtAccessKey = new System.Windows.Forms.TextBox();
            this.txtSecretKey = new System.Windows.Forms.TextBox();
            this.grpCredential = new System.Windows.Forms.GroupBox();
            this.btnLoadConfig = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblEndpoint = new System.Windows.Forms.Label();
            this.txtEndpoint = new System.Windows.Forms.TextBox();
            this.lblLocalDirectory = new System.Windows.Forms.Label();
            this.lblRemoteDirectory = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRemoteMoveRename = new System.Windows.Forms.Button();
            this.btnRemoteNewFolder = new System.Windows.Forms.Button();
            this.btnRemoteDelete = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.txtFilterRemoteDir = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.txtFilterLocalDir = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRemoteDirRefresh = new System.Windows.Forms.Button();
            this.txtRemoteDir = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtLocalDir = new System.Windows.Forms.TextBox();
            this.btnLocalDirRefresh = new System.Windows.Forms.Button();
            this.lvLocalDir = new System.Windows.Forms.ListView();
            this.ilLocalDir = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.lvRemoteDir = new System.Windows.Forms.ListView();
            this.ilRemoteDir = new System.Windows.Forms.ImageList(this.components);
            this.dgOnProgress = new System.Windows.Forms.DataGridView();
            this.tabUpDownProgress = new System.Windows.Forms.TabControl();
            this.tabOnProgress = new System.Windows.Forms.TabPage();
            this.tabErrorFail = new System.Windows.Forms.TabPage();
            this.dgErrorFail = new System.Windows.Forms.DataGridView();
            this.tabSuccess = new System.Windows.Forms.TabPage();
            this.dgSuccess = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblRefresh = new System.Windows.Forms.Label();
            this.grpCredential.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOnProgress)).BeginInit();
            this.tabUpDownProgress.SuspendLayout();
            this.tabOnProgress.SuspendLayout();
            this.tabErrorFail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgErrorFail)).BeginInit();
            this.tabSuccess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSuccess)).BeginInit();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAccessKey
            // 
            this.lblAccessKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAccessKey.AutoSize = true;
            this.lblAccessKey.Location = new System.Drawing.Point(6, 50);
            this.lblAccessKey.Name = "lblAccessKey";
            this.lblAccessKey.Size = new System.Drawing.Size(68, 15);
            this.lblAccessKey.TabIndex = 4;
            this.lblAccessKey.Text = "Access Key";
            // 
            // lblSecretKey
            // 
            this.lblSecretKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSecretKey.AutoSize = true;
            this.lblSecretKey.Location = new System.Drawing.Point(9, 77);
            this.lblSecretKey.Name = "lblSecretKey";
            this.lblSecretKey.Size = new System.Drawing.Size(65, 15);
            this.lblSecretKey.TabIndex = 6;
            this.lblSecretKey.Text = "Secret Key";
            // 
            // txtAccessKey
            // 
            this.txtAccessKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccessKey.Location = new System.Drawing.Point(80, 47);
            this.txtAccessKey.Name = "txtAccessKey";
            this.txtAccessKey.Size = new System.Drawing.Size(422, 21);
            this.txtAccessKey.TabIndex = 7;
            // 
            // txtSecretKey
            // 
            this.txtSecretKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSecretKey.Location = new System.Drawing.Point(80, 74);
            this.txtSecretKey.Name = "txtSecretKey";
            this.txtSecretKey.Size = new System.Drawing.Size(422, 21);
            this.txtSecretKey.TabIndex = 5;
            // 
            // grpCredential
            // 
            this.grpCredential.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCredential.Controls.Add(this.btnLoadConfig);
            this.grpCredential.Controls.Add(this.btnConnect);
            this.grpCredential.Controls.Add(this.lblEndpoint);
            this.grpCredential.Controls.Add(this.txtEndpoint);
            this.grpCredential.Controls.Add(this.lblAccessKey);
            this.grpCredential.Controls.Add(this.txtSecretKey);
            this.grpCredential.Controls.Add(this.lblSecretKey);
            this.grpCredential.Controls.Add(this.txtAccessKey);
            this.grpCredential.Location = new System.Drawing.Point(12, 12);
            this.grpCredential.Name = "grpCredential";
            this.grpCredential.Size = new System.Drawing.Size(602, 107);
            this.grpCredential.TabIndex = 6;
            this.grpCredential.TabStop = false;
            // 
            // btnLoadConfig
            // 
            this.btnLoadConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadConfig.Location = new System.Drawing.Point(508, 19);
            this.btnLoadConfig.Name = "btnLoadConfig";
            this.btnLoadConfig.Size = new System.Drawing.Size(83, 23);
            this.btnLoadConfig.TabIndex = 0;
            this.btnLoadConfig.Text = "App.config";
            this.btnLoadConfig.UseVisualStyleBackColor = true;
            this.btnLoadConfig.Click += new System.EventHandler(this.btnOpenConfig_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(508, 47);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(83, 48);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblEndpoint
            // 
            this.lblEndpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEndpoint.AutoSize = true;
            this.lblEndpoint.Location = new System.Drawing.Point(18, 23);
            this.lblEndpoint.Name = "lblEndpoint";
            this.lblEndpoint.Size = new System.Drawing.Size(56, 15);
            this.lblEndpoint.TabIndex = 2;
            this.lblEndpoint.Text = "Endpoint";
            // 
            // txtEndpoint
            // 
            this.txtEndpoint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndpoint.Location = new System.Drawing.Point(80, 20);
            this.txtEndpoint.Name = "txtEndpoint";
            this.txtEndpoint.Size = new System.Drawing.Size(422, 21);
            this.txtEndpoint.TabIndex = 3;
            // 
            // lblLocalDirectory
            // 
            this.lblLocalDirectory.AutoSize = true;
            this.lblLocalDirectory.Location = new System.Drawing.Point(12, 131);
            this.lblLocalDirectory.Name = "lblLocalDirectory";
            this.lblLocalDirectory.Size = new System.Drawing.Size(107, 15);
            this.lblLocalDirectory.TabIndex = 5;
            this.lblLocalDirectory.Text = "My Local Directory";
            // 
            // lblRemoteDirectory
            // 
            this.lblRemoteDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRemoteDirectory.AutoSize = true;
            this.lblRemoteDirectory.Location = new System.Drawing.Point(607, 131);
            this.lblRemoteDirectory.Name = "lblRemoteDirectory";
            this.lblRemoteDirectory.Size = new System.Drawing.Size(165, 15);
            this.lblRemoteDirectory.TabIndex = 4;
            this.lblRemoteDirectory.Text = "OBS Cloud Remote Directory";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.5F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lvLocalDir, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lvRemoteDir, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(754, 254);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.Controls.Add(this.btnRemoteMoveRename, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.btnRemoteNewFolder, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.btnRemoteDelete, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(398, 221);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(353, 30);
            this.tableLayoutPanel7.TabIndex = 8;
            // 
            // btnRemoteMoveRename
            // 
            this.btnRemoteMoveRename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoteMoveRename.Enabled = false;
            this.btnRemoteMoveRename.Location = new System.Drawing.Point(120, 3);
            this.btnRemoteMoveRename.Name = "btnRemoteMoveRename";
            this.btnRemoteMoveRename.Size = new System.Drawing.Size(111, 24);
            this.btnRemoteMoveRename.TabIndex = 4;
            this.btnRemoteMoveRename.Text = "Move / Rename";
            this.btnRemoteMoveRename.UseVisualStyleBackColor = true;
            this.btnRemoteMoveRename.Click += new System.EventHandler(this.btnRemoteMoveRename_Click);
            // 
            // btnRemoteNewFolder
            // 
            this.btnRemoteNewFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoteNewFolder.Enabled = false;
            this.btnRemoteNewFolder.Location = new System.Drawing.Point(237, 3);
            this.btnRemoteNewFolder.Name = "btnRemoteNewFolder";
            this.btnRemoteNewFolder.Size = new System.Drawing.Size(113, 24);
            this.btnRemoteNewFolder.TabIndex = 0;
            this.btnRemoteNewFolder.Text = "New Folder";
            this.btnRemoteNewFolder.UseVisualStyleBackColor = true;
            this.btnRemoteNewFolder.Click += new System.EventHandler(this.btnRemoteNewFolder_Click);
            // 
            // btnRemoteDelete
            // 
            this.btnRemoteDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoteDelete.Enabled = false;
            this.btnRemoteDelete.Location = new System.Drawing.Point(3, 3);
            this.btnRemoteDelete.Name = "btnRemoteDelete";
            this.btnRemoteDelete.Size = new System.Drawing.Size(111, 24);
            this.btnRemoteDelete.TabIndex = 3;
            this.btnRemoteDelete.Text = "Delete";
            this.btnRemoteDelete.UseVisualStyleBackColor = true;
            this.btnRemoteDelete.Click += new System.EventHandler(this.btnRemoteDelete_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.txtFilterRemoteDir, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(398, 39);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(353, 30);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // txtFilterRemoteDir
            // 
            this.txtFilterRemoteDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilterRemoteDir.Location = new System.Drawing.Point(3, 3);
            this.txtFilterRemoteDir.Name = "txtFilterRemoteDir";
            this.txtFilterRemoteDir.ReadOnly = true;
            this.txtFilterRemoteDir.Size = new System.Drawing.Size(349, 21);
            this.txtFilterRemoteDir.TabIndex = 0;
            this.txtFilterRemoteDir.TextChanged += new System.EventHandler(this.txtFilterRemoteDir_TextChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.txtFilterLocalDir, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 39);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(352, 30);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // txtFilterLocalDir
            // 
            this.txtFilterLocalDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilterLocalDir.Location = new System.Drawing.Point(3, 3);
            this.txtFilterLocalDir.Name = "txtFilterLocalDir";
            this.txtFilterLocalDir.Size = new System.Drawing.Size(349, 21);
            this.txtFilterLocalDir.TabIndex = 0;
            this.txtFilterLocalDir.TextChanged += new System.EventHandler(this.txtFilterLocalDir_TextChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.btnRemoteDirRefresh, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtRemoteDir, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(398, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(353, 30);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // btnRemoteDirRefresh
            // 
            this.btnRemoteDirRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoteDirRefresh.Enabled = false;
            this.btnRemoteDirRefresh.Location = new System.Drawing.Point(275, 3);
            this.btnRemoteDirRefresh.Name = "btnRemoteDirRefresh";
            this.btnRemoteDirRefresh.Size = new System.Drawing.Size(75, 24);
            this.btnRemoteDirRefresh.TabIndex = 0;
            this.btnRemoteDirRefresh.Text = "Refresh";
            this.btnRemoteDirRefresh.UseVisualStyleBackColor = true;
            this.btnRemoteDirRefresh.Click += new System.EventHandler(this.btnRemoteDirRefresh_Click);
            // 
            // txtRemoteDir
            // 
            this.txtRemoteDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemoteDir.Location = new System.Drawing.Point(54, 3);
            this.txtRemoteDir.Name = "txtRemoteDir";
            this.txtRemoteDir.ReadOnly = true;
            this.txtRemoteDir.Size = new System.Drawing.Size(215, 21);
            this.txtRemoteDir.TabIndex = 1;
            this.txtRemoteDir.Enter += new System.EventHandler(this.txtRemoteDir_Enter);
            this.txtRemoteDir.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemoteDir_KeyDown);
            this.txtRemoteDir.Leave += new System.EventHandler(this.txtRemoteDir_Leave);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(45, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "OBS://";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.txtLocalDir, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnLocalDirRefresh, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(352, 30);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // txtLocalDir
            // 
            this.txtLocalDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLocalDir.Location = new System.Drawing.Point(3, 3);
            this.txtLocalDir.Name = "txtLocalDir";
            this.txtLocalDir.Size = new System.Drawing.Size(265, 21);
            this.txtLocalDir.TabIndex = 0;
            this.txtLocalDir.Text = "C:\\";
            this.txtLocalDir.Enter += new System.EventHandler(this.txtLocalDir_Enter);
            this.txtLocalDir.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtLocalDir_KeyDown);
            this.txtLocalDir.Leave += new System.EventHandler(this.txtLocalDir_Leave);
            // 
            // btnLocalDirRefresh
            // 
            this.btnLocalDirRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLocalDirRefresh.Location = new System.Drawing.Point(274, 3);
            this.btnLocalDirRefresh.Name = "btnLocalDirRefresh";
            this.btnLocalDirRefresh.Size = new System.Drawing.Size(75, 24);
            this.btnLocalDirRefresh.TabIndex = 1;
            this.btnLocalDirRefresh.Text = "Refresh";
            this.btnLocalDirRefresh.UseVisualStyleBackColor = true;
            this.btnLocalDirRefresh.Click += new System.EventHandler(this.btnLocalDirRefresh_Click);
            // 
            // lvLocalDir
            // 
            this.lvLocalDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLocalDir.HideSelection = false;
            this.lvLocalDir.LargeImageList = this.ilLocalDir;
            this.lvLocalDir.Location = new System.Drawing.Point(3, 75);
            this.lvLocalDir.MultiSelect = false;
            this.lvLocalDir.Name = "lvLocalDir";
            this.lvLocalDir.Size = new System.Drawing.Size(352, 140);
            this.lvLocalDir.SmallImageList = this.ilLocalDir;
            this.lvLocalDir.TabIndex = 4;
            this.lvLocalDir.UseCompatibleStateImageBehavior = false;
            this.lvLocalDir.View = System.Windows.Forms.View.Tile;
            this.lvLocalDir.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvLocalDir_ItemSelectionChanged);
            this.lvLocalDir.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvLocalDir_MouseDoubleClick);
            // 
            // ilLocalDir
            // 
            this.ilLocalDir.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilLocalDir.ImageSize = new System.Drawing.Size(32, 32);
            this.ilLocalDir.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnUpload, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnDownload, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(361, 75);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(31, 140);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // btnUpload
            // 
            this.btnUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpload.Enabled = false;
            this.btnUpload.Location = new System.Drawing.Point(3, 44);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(25, 23);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = ">>";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDownload.Enabled = false;
            this.btnDownload.Location = new System.Drawing.Point(3, 73);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(25, 23);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "<<";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // lvRemoteDir
            // 
            this.lvRemoteDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRemoteDir.Enabled = false;
            this.lvRemoteDir.HideSelection = false;
            this.lvRemoteDir.LargeImageList = this.ilRemoteDir;
            this.lvRemoteDir.Location = new System.Drawing.Point(398, 75);
            this.lvRemoteDir.Name = "lvRemoteDir";
            this.lvRemoteDir.Size = new System.Drawing.Size(353, 140);
            this.lvRemoteDir.SmallImageList = this.ilRemoteDir;
            this.lvRemoteDir.TabIndex = 6;
            this.lvRemoteDir.UseCompatibleStateImageBehavior = false;
            this.lvRemoteDir.View = System.Windows.Forms.View.Tile;
            this.lvRemoteDir.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvRemoteDir_ItemSelectionChanged);
            this.lvRemoteDir.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvRemoteDir_MouseDoubleClick);
            // 
            // ilRemoteDir
            // 
            this.ilRemoteDir.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilRemoteDir.ImageSize = new System.Drawing.Size(32, 32);
            this.ilRemoteDir.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // dgOnProgress
            // 
            this.dgOnProgress.AllowUserToAddRows = false;
            this.dgOnProgress.AllowUserToDeleteRows = false;
            this.dgOnProgress.AllowUserToOrderColumns = true;
            this.dgOnProgress.AllowUserToResizeRows = false;
            this.dgOnProgress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOnProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgOnProgress.Location = new System.Drawing.Point(0, 2);
            this.dgOnProgress.Name = "dgOnProgress";
            this.dgOnProgress.ReadOnly = true;
            this.dgOnProgress.RowHeadersVisible = false;
            this.dgOnProgress.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgOnProgress.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgOnProgress.Size = new System.Drawing.Size(744, 103);
            this.dgOnProgress.TabIndex = 2;
            this.dgOnProgress.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOnProgress_CellContentClick);
            // 
            // tabUpDownProgress
            // 
            this.tabUpDownProgress.Controls.Add(this.tabOnProgress);
            this.tabUpDownProgress.Controls.Add(this.tabErrorFail);
            this.tabUpDownProgress.Controls.Add(this.tabSuccess);
            this.tabUpDownProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabUpDownProgress.Location = new System.Drawing.Point(3, 263);
            this.tabUpDownProgress.Name = "tabUpDownProgress";
            this.tabUpDownProgress.SelectedIndex = 0;
            this.tabUpDownProgress.Size = new System.Drawing.Size(754, 134);
            this.tabUpDownProgress.TabIndex = 7;
            // 
            // tabOnProgress
            // 
            this.tabOnProgress.Controls.Add(this.dgOnProgress);
            this.tabOnProgress.Location = new System.Drawing.Point(4, 24);
            this.tabOnProgress.Name = "tabOnProgress";
            this.tabOnProgress.Padding = new System.Windows.Forms.Padding(0, 2, 2, 1);
            this.tabOnProgress.Size = new System.Drawing.Size(746, 106);
            this.tabOnProgress.TabIndex = 0;
            this.tabOnProgress.Text = "On Progress";
            this.tabOnProgress.UseVisualStyleBackColor = true;
            // 
            // tabErrorFail
            // 
            this.tabErrorFail.Controls.Add(this.dgErrorFail);
            this.tabErrorFail.Location = new System.Drawing.Point(4, 24);
            this.tabErrorFail.Name = "tabErrorFail";
            this.tabErrorFail.Padding = new System.Windows.Forms.Padding(0, 2, 2, 1);
            this.tabErrorFail.Size = new System.Drawing.Size(746, 106);
            this.tabErrorFail.TabIndex = 1;
            this.tabErrorFail.Text = "Error / Fail";
            this.tabErrorFail.UseVisualStyleBackColor = true;
            // 
            // dgErrorFail
            // 
            this.dgErrorFail.AllowUserToAddRows = false;
            this.dgErrorFail.AllowUserToDeleteRows = false;
            this.dgErrorFail.AllowUserToOrderColumns = true;
            this.dgErrorFail.AllowUserToResizeRows = false;
            this.dgErrorFail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgErrorFail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgErrorFail.Location = new System.Drawing.Point(0, 2);
            this.dgErrorFail.Name = "dgErrorFail";
            this.dgErrorFail.ReadOnly = true;
            this.dgErrorFail.RowHeadersVisible = false;
            this.dgErrorFail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgErrorFail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgErrorFail.Size = new System.Drawing.Size(744, 103);
            this.dgErrorFail.TabIndex = 3;
            this.dgErrorFail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgErrorFail_CellContentClick);
            // 
            // tabSuccess
            // 
            this.tabSuccess.Controls.Add(this.dgSuccess);
            this.tabSuccess.Location = new System.Drawing.Point(4, 24);
            this.tabSuccess.Name = "tabSuccess";
            this.tabSuccess.Padding = new System.Windows.Forms.Padding(0, 2, 2, 1);
            this.tabSuccess.Size = new System.Drawing.Size(746, 106);
            this.tabSuccess.TabIndex = 2;
            this.tabSuccess.Text = "Success";
            this.tabSuccess.UseVisualStyleBackColor = true;
            // 
            // dgSuccess
            // 
            this.dgSuccess.AllowUserToAddRows = false;
            this.dgSuccess.AllowUserToDeleteRows = false;
            this.dgSuccess.AllowUserToOrderColumns = true;
            this.dgSuccess.AllowUserToResizeRows = false;
            this.dgSuccess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSuccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSuccess.Location = new System.Drawing.Point(0, 2);
            this.dgSuccess.Name = "dgSuccess";
            this.dgSuccess.ReadOnly = true;
            this.dgSuccess.RowHeadersVisible = false;
            this.dgSuccess.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgSuccess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSuccess.Size = new System.Drawing.Size(744, 103);
            this.dgSuccess.TabIndex = 4;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.tabUpDownProgress, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(12, 149);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(760, 400);
            this.tableLayoutPanel8.TabIndex = 8;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(640, 54);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(132, 25);
            this.lblDate.TabIndex = 9;
            this.lblDate.Text = "88-88-8888";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(690, 79);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(79, 20);
            this.lblTime.TabIndex = 10;
            this.lblTime.Text = "88:88:88";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRefresh
            // 
            this.lblRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRefresh.AutoSize = true;
            this.lblRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefresh.Location = new System.Drawing.Point(700, 40);
            this.lblRefresh.Name = "lblRefresh";
            this.lblRefresh.Size = new System.Drawing.Size(67, 13);
            this.lblRefresh.TabIndex = 11;
            this.lblRefresh.Text = "Last Refresh";
            this.lblRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WinMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lblRefresh);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.tableLayoutPanel8);
            this.Controls.Add(this.lblRemoteDirectory);
            this.Controls.Add(this.lblLocalDirectory);
            this.Controls.Add(this.grpCredential);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "WinMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OBS-UTIL_GUI";
            this.Load += new System.EventHandler(this.WinMain_Load);
            this.grpCredential.ResumeLayout(false);
            this.grpCredential.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgOnProgress)).EndInit();
            this.tabUpDownProgress.ResumeLayout(false);
            this.tabOnProgress.ResumeLayout(false);
            this.tabErrorFail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgErrorFail)).EndInit();
            this.tabSuccess.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSuccess)).EndInit();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAccessKey;
        private System.Windows.Forms.Label lblSecretKey;
        private System.Windows.Forms.TextBox txtAccessKey;
        private System.Windows.Forms.TextBox txtSecretKey;
        private System.Windows.Forms.GroupBox grpCredential;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblEndpoint;
        private System.Windows.Forms.TextBox txtEndpoint;
        private System.Windows.Forms.Label lblLocalDirectory;
        private System.Windows.Forms.Label lblRemoteDirectory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgOnProgress;
        private System.Windows.Forms.TextBox txtRemoteDir;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnRemoteNewFolder;
        private System.Windows.Forms.ListView lvLocalDir;
        private System.Windows.Forms.ImageList ilLocalDir;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtLocalDir;
        private System.Windows.Forms.Button btnLocalDirRefresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnRemoteDirRefresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TextBox txtFilterRemoteDir;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox txtFilterLocalDir;
        private System.Windows.Forms.Button btnLoadConfig;
        private System.Windows.Forms.ListView lvRemoteDir;
        private System.Windows.Forms.ImageList ilRemoteDir;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl tabUpDownProgress;
        private System.Windows.Forms.TabPage tabOnProgress;
        private System.Windows.Forms.TabPage tabErrorFail;
        private System.Windows.Forms.DataGridView dgErrorFail;
        private System.Windows.Forms.TabPage tabSuccess;
        private System.Windows.Forms.DataGridView dgSuccess;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Button btnRemoteMoveRename;
        private System.Windows.Forms.Button btnRemoteDelete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblRefresh;
    }

}

