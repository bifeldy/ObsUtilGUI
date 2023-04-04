using System.Windows.Forms;

namespace ObsUtilGUI {

    public static class DialogInput {

        public static DialogResult ShowInputDialog(ref string inputOutput, string windowName) {
            System.Drawing.Size size = new System.Drawing.Size(200, 70);
            Form inputBox = new Form {
                FormBorderStyle = FormBorderStyle.FixedDialog,
                ClientSize = size,
                Text = windowName,
                MinimizeBox = false,
                MaximizeBox = false,
                StartPosition = FormStartPosition.CenterScreen
            };

            TextBox textBox = new TextBox {
                Size = new System.Drawing.Size(size.Width - 10, 23),
                Location = new System.Drawing.Point(5, 5),
                Text = inputOutput
            };
            inputBox.Controls.Add(textBox);

            Button okButton = new Button {
                DialogResult = DialogResult.OK,
                Name = "okButton",
                Size = new System.Drawing.Size(75, 23),
                Text = "&OK",
                Location = new System.Drawing.Point(size.Width - 80 - 80, 39)
            };
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button {
                DialogResult = DialogResult.Cancel,
                Name = "cancelButton",
                Size = new System.Drawing.Size(75, 23),
                Text = "&Cancel",
                Location = new System.Drawing.Point(size.Width - 80, 39)
            };
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            inputOutput = textBox.Text;

            return result;
        }

    }

}
