namespace CS_485_Project_2
{
    partial class SDESForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openFileDialogBox = new System.Windows.Forms.OpenFileDialog();
            this.chooseFileButton = new System.Windows.Forms.Button();
            this.fileLocLabel = new System.Windows.Forms.Label();
            this.encryptKeyBox = new System.Windows.Forms.TextBox();
            this.subKey1Box = new System.Windows.Forms.TextBox();
            this.subKey2Box = new System.Windows.Forms.TextBox();
            this.keyInputEncryptFileLabel = new System.Windows.Forms.Label();
            this.subkey1Label = new System.Windows.Forms.Label();
            this.subkey2Label = new System.Windows.Forms.Label();
            this.encryptFileButton = new System.Windows.Forms.Button();
            this.encryptPanel = new System.Windows.Forms.Panel();
            this.encryptLabel = new System.Windows.Forms.Label();
            this.decryptPanel = new System.Windows.Forms.Panel();
            this.sameEncryptionSoftwareCheckBox = new System.Windows.Forms.CheckBox();
            this.decryptButton = new System.Windows.Forms.Button();
            this.decryptKeyBox = new System.Windows.Forms.TextBox();
            this.decryptLabel = new System.Windows.Forms.Label();
            this.keyInputDecryptFileLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.byteKeyTextBox = new System.Windows.Forms.TextBox();
            this.encryptPlaintextBox = new System.Windows.Forms.TextBox();
            this.keyInputBinaryEncryptDecryptLabel = new System.Windows.Forms.Label();
            this.encryptCipherTextBox = new System.Windows.Forms.TextBox();
            this.encryptByteButton = new System.Windows.Forms.Button();
            this.encryptPlaintextLabel = new System.Windows.Forms.Label();
            this.encryptCiphertextLabel = new System.Windows.Forms.Label();
            this.encryptDecryptByteLabel = new System.Windows.Forms.Label();
            this.encryptDecryptBytePanel = new System.Windows.Forms.Panel();
            this.encryptDecryptFilePanel = new System.Windows.Forms.Panel();
            this.encryptFileDecimalNotificationLabel = new System.Windows.Forms.Label();
            this.encryptDecryptFileLabel = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byLarryEmersonJohnsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forCS485SP2023ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encryptByteBinaryNotificationLabel = new System.Windows.Forms.Label();
            this.encryptBytePanel = new System.Windows.Forms.Panel();
            this.encryptBytePanelLabel = new System.Windows.Forms.Label();
            this.decryptBytePanel = new System.Windows.Forms.Panel();
            this.decryptBytePanelLabel = new System.Windows.Forms.Label();
            this.decryptCiphertextLabel = new System.Windows.Forms.Label();
            this.decryptByteButton = new System.Windows.Forms.Button();
            this.decryptCiphertextBox = new System.Windows.Forms.TextBox();
            this.decryptPlaintextBox = new System.Windows.Forms.TextBox();
            this.decryptPlaintextLabel = new System.Windows.Forms.Label();
            this.encryptPanel.SuspendLayout();
            this.decryptPanel.SuspendLayout();
            this.encryptDecryptBytePanel.SuspendLayout();
            this.encryptDecryptFilePanel.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.encryptBytePanel.SuspendLayout();
            this.decryptBytePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialogBox
            // 
            this.openFileDialogBox.FileName = "openFileDialog1";
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Location = new System.Drawing.Point(288, 8);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(126, 23);
            this.chooseFileButton.TabIndex = 0;
            this.chooseFileButton.Text = "Choose File!";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.chooseFileButton_Click);
            // 
            // fileLocLabel
            // 
            this.fileLocLabel.Location = new System.Drawing.Point(-1, 34);
            this.fileLocLabel.Name = "fileLocLabel";
            this.fileLocLabel.Size = new System.Drawing.Size(702, 20);
            this.fileLocLabel.TabIndex = 2;
            this.fileLocLabel.Text = "<file loc>";
            this.fileLocLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.fileLocLabel.Visible = false;
            this.fileLocLabel.TextChanged += new System.EventHandler(this.fileSelectedByUser);
            // 
            // encryptKeyBox
            // 
            this.encryptKeyBox.Location = new System.Drawing.Point(111, 59);
            this.encryptKeyBox.MaxLength = 4;
            this.encryptKeyBox.Name = "encryptKeyBox";
            this.encryptKeyBox.Size = new System.Drawing.Size(100, 20);
            this.encryptKeyBox.TabIndex = 3;
            // 
            // subKey1Box
            // 
            this.subKey1Box.Location = new System.Drawing.Point(58, 149);
            this.subKey1Box.Name = "subKey1Box";
            this.subKey1Box.Size = new System.Drawing.Size(100, 20);
            this.subKey1Box.TabIndex = 5;
            this.subKey1Box.Visible = false;
            // 
            // subKey2Box
            // 
            this.subKey2Box.Location = new System.Drawing.Point(162, 149);
            this.subKey2Box.Name = "subKey2Box";
            this.subKey2Box.Size = new System.Drawing.Size(100, 20);
            this.subKey2Box.TabIndex = 6;
            this.subKey2Box.Visible = false;
            // 
            // keyInputEncryptFileLabel
            // 
            this.keyInputEncryptFileLabel.AutoSize = true;
            this.keyInputEncryptFileLabel.Location = new System.Drawing.Point(135, 43);
            this.keyInputEncryptFileLabel.Name = "keyInputEncryptFileLabel";
            this.keyInputEncryptFileLabel.Size = new System.Drawing.Size(52, 13);
            this.keyInputEncryptFileLabel.TabIndex = 7;
            this.keyInputEncryptFileLabel.Text = "Key Input";
            // 
            // subkey1Label
            // 
            this.subkey1Label.AutoSize = true;
            this.subkey1Label.Location = new System.Drawing.Point(82, 133);
            this.subkey1Label.Name = "subkey1Label";
            this.subkey1Label.Size = new System.Drawing.Size(52, 13);
            this.subkey1Label.TabIndex = 8;
            this.subkey1Label.Text = "Subkey 1";
            this.subkey1Label.Visible = false;
            // 
            // subkey2Label
            // 
            this.subkey2Label.AutoSize = true;
            this.subkey2Label.Location = new System.Drawing.Point(186, 133);
            this.subkey2Label.Name = "subkey2Label";
            this.subkey2Label.Size = new System.Drawing.Size(52, 13);
            this.subkey2Label.TabIndex = 9;
            this.subkey2Label.Text = "Subkey 2";
            this.subkey2Label.Visible = false;
            // 
            // encryptFileButton
            // 
            this.encryptFileButton.Location = new System.Drawing.Point(111, 192);
            this.encryptFileButton.Name = "encryptFileButton";
            this.encryptFileButton.Size = new System.Drawing.Size(100, 23);
            this.encryptFileButton.TabIndex = 10;
            this.encryptFileButton.Text = "Encrypt File";
            this.encryptFileButton.UseVisualStyleBackColor = true;
            this.encryptFileButton.Click += new System.EventHandler(this.encryptFileButton_Click);
            // 
            // encryptPanel
            // 
            this.encryptPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.encryptPanel.Controls.Add(this.subKey2Box);
            this.encryptPanel.Controls.Add(this.encryptFileButton);
            this.encryptPanel.Controls.Add(this.subkey2Label);
            this.encryptPanel.Controls.Add(this.encryptLabel);
            this.encryptPanel.Controls.Add(this.encryptKeyBox);
            this.encryptPanel.Controls.Add(this.subkey1Label);
            this.encryptPanel.Controls.Add(this.subKey1Box);
            this.encryptPanel.Controls.Add(this.keyInputEncryptFileLabel);
            this.encryptPanel.Enabled = false;
            this.encryptPanel.Location = new System.Drawing.Point(16, 57);
            this.encryptPanel.Name = "encryptPanel";
            this.encryptPanel.Size = new System.Drawing.Size(325, 245);
            this.encryptPanel.TabIndex = 11;
            // 
            // encryptLabel
            // 
            this.encryptLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encryptLabel.Location = new System.Drawing.Point(-1, 10);
            this.encryptLabel.Name = "encryptLabel";
            this.encryptLabel.Size = new System.Drawing.Size(324, 23);
            this.encryptLabel.TabIndex = 12;
            this.encryptLabel.Text = "Encrypt File";
            this.encryptLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // decryptPanel
            // 
            this.decryptPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.decryptPanel.Controls.Add(this.sameEncryptionSoftwareCheckBox);
            this.decryptPanel.Controls.Add(this.decryptButton);
            this.decryptPanel.Controls.Add(this.decryptKeyBox);
            this.decryptPanel.Controls.Add(this.decryptLabel);
            this.decryptPanel.Controls.Add(this.keyInputDecryptFileLabel);
            this.decryptPanel.Enabled = false;
            this.decryptPanel.Location = new System.Drawing.Point(356, 57);
            this.decryptPanel.Name = "decryptPanel";
            this.decryptPanel.Size = new System.Drawing.Size(327, 245);
            this.decryptPanel.TabIndex = 14;
            // 
            // sameEncryptionSoftwareCheckBox
            // 
            this.sameEncryptionSoftwareCheckBox.AutoSize = true;
            this.sameEncryptionSoftwareCheckBox.Checked = true;
            this.sameEncryptionSoftwareCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sameEncryptionSoftwareCheckBox.Location = new System.Drawing.Point(71, 117);
            this.sameEncryptionSoftwareCheckBox.Name = "sameEncryptionSoftwareCheckBox";
            this.sameEncryptionSoftwareCheckBox.Size = new System.Drawing.Size(182, 17);
            this.sameEncryptionSoftwareCheckBox.TabIndex = 15;
            this.sameEncryptionSoftwareCheckBox.Text = "File encrypted with this software?";
            this.sameEncryptionSoftwareCheckBox.UseVisualStyleBackColor = true;
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(111, 192);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(100, 23);
            this.decryptButton.TabIndex = 14;
            this.decryptButton.Text = "Decrypt File";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // decryptKeyBox
            // 
            this.decryptKeyBox.Location = new System.Drawing.Point(111, 59);
            this.decryptKeyBox.MaxLength = 4;
            this.decryptKeyBox.Name = "decryptKeyBox";
            this.decryptKeyBox.Size = new System.Drawing.Size(100, 20);
            this.decryptKeyBox.TabIndex = 3;
            // 
            // decryptLabel
            // 
            this.decryptLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decryptLabel.Location = new System.Drawing.Point(-1, 10);
            this.decryptLabel.Name = "decryptLabel";
            this.decryptLabel.Size = new System.Drawing.Size(324, 23);
            this.decryptLabel.TabIndex = 15;
            this.decryptLabel.Text = "Decrypt File";
            this.decryptLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // keyInputDecryptFileLabel
            // 
            this.keyInputDecryptFileLabel.AutoSize = true;
            this.keyInputDecryptFileLabel.Location = new System.Drawing.Point(135, 43);
            this.keyInputDecryptFileLabel.Name = "keyInputDecryptFileLabel";
            this.keyInputDecryptFileLabel.Size = new System.Drawing.Size(52, 13);
            this.keyInputDecryptFileLabel.TabIndex = 7;
            this.keyInputDecryptFileLabel.Text = "Key Input";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // byteKeyTextBox
            // 
            this.byteKeyTextBox.Location = new System.Drawing.Point(68, 75);
            this.byteKeyTextBox.MaxLength = 10;
            this.byteKeyTextBox.Name = "byteKeyTextBox";
            this.byteKeyTextBox.Size = new System.Drawing.Size(100, 20);
            this.byteKeyTextBox.TabIndex = 17;
            // 
            // encryptPlaintextBox
            // 
            this.encryptPlaintextBox.Location = new System.Drawing.Point(110, 27);
            this.encryptPlaintextBox.MaxLength = 8;
            this.encryptPlaintextBox.Name = "encryptPlaintextBox";
            this.encryptPlaintextBox.Size = new System.Drawing.Size(100, 20);
            this.encryptPlaintextBox.TabIndex = 18;
            // 
            // keyInputBinaryEncryptDecryptLabel
            // 
            this.keyInputBinaryEncryptDecryptLabel.Location = new System.Drawing.Point(68, 59);
            this.keyInputBinaryEncryptDecryptLabel.Name = "keyInputBinaryEncryptDecryptLabel";
            this.keyInputBinaryEncryptDecryptLabel.Size = new System.Drawing.Size(100, 13);
            this.keyInputBinaryEncryptDecryptLabel.TabIndex = 11;
            this.keyInputBinaryEncryptDecryptLabel.Text = "Key Input";
            this.keyInputBinaryEncryptDecryptLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // encryptCipherTextBox
            // 
            this.encryptCipherTextBox.Location = new System.Drawing.Point(340, 27);
            this.encryptCipherTextBox.Name = "encryptCipherTextBox";
            this.encryptCipherTextBox.ReadOnly = true;
            this.encryptCipherTextBox.Size = new System.Drawing.Size(100, 20);
            this.encryptCipherTextBox.TabIndex = 19;
            // 
            // encryptByteButton
            // 
            this.encryptByteButton.Location = new System.Drawing.Point(225, 18);
            this.encryptByteButton.Name = "encryptByteButton";
            this.encryptByteButton.Size = new System.Drawing.Size(100, 23);
            this.encryptByteButton.TabIndex = 22;
            this.encryptByteButton.Text = "Encrypt Byte";
            this.encryptByteButton.UseVisualStyleBackColor = true;
            this.encryptByteButton.Click += new System.EventHandler(this.encryptByteButton_Click);
            // 
            // encryptPlaintextLabel
            // 
            this.encryptPlaintextLabel.Location = new System.Drawing.Point(110, 11);
            this.encryptPlaintextLabel.Name = "encryptPlaintextLabel";
            this.encryptPlaintextLabel.Size = new System.Drawing.Size(100, 13);
            this.encryptPlaintextLabel.TabIndex = 23;
            this.encryptPlaintextLabel.Text = "Plaintext Byte";
            this.encryptPlaintextLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // encryptCiphertextLabel
            // 
            this.encryptCiphertextLabel.Location = new System.Drawing.Point(340, 11);
            this.encryptCiphertextLabel.Name = "encryptCiphertextLabel";
            this.encryptCiphertextLabel.Size = new System.Drawing.Size(100, 13);
            this.encryptCiphertextLabel.TabIndex = 24;
            this.encryptCiphertextLabel.Text = "Ciphertext Byte";
            this.encryptCiphertextLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // encryptDecryptByteLabel
            // 
            this.encryptDecryptByteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encryptDecryptByteLabel.Location = new System.Drawing.Point(53, 398);
            this.encryptDecryptByteLabel.Name = "encryptDecryptByteLabel";
            this.encryptDecryptByteLabel.Size = new System.Drawing.Size(702, 23);
            this.encryptDecryptByteLabel.TabIndex = 24;
            this.encryptDecryptByteLabel.Text = "Encrypt/Decrypt Byte";
            this.encryptDecryptByteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // encryptDecryptBytePanel
            // 
            this.encryptDecryptBytePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.encryptDecryptBytePanel.Controls.Add(this.decryptBytePanel);
            this.encryptDecryptBytePanel.Controls.Add(this.encryptBytePanel);
            this.encryptDecryptBytePanel.Controls.Add(this.encryptByteBinaryNotificationLabel);
            this.encryptDecryptBytePanel.Controls.Add(this.keyInputBinaryEncryptDecryptLabel);
            this.encryptDecryptBytePanel.Controls.Add(this.byteKeyTextBox);
            this.encryptDecryptBytePanel.Location = new System.Drawing.Point(53, 424);
            this.encryptDecryptBytePanel.Name = "encryptDecryptBytePanel";
            this.encryptDecryptBytePanel.Size = new System.Drawing.Size(702, 165);
            this.encryptDecryptBytePanel.TabIndex = 24;
            // 
            // encryptDecryptFilePanel
            // 
            this.encryptDecryptFilePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.encryptDecryptFilePanel.Controls.Add(this.encryptFileDecimalNotificationLabel);
            this.encryptDecryptFilePanel.Controls.Add(this.encryptPanel);
            this.encryptDecryptFilePanel.Controls.Add(this.chooseFileButton);
            this.encryptDecryptFilePanel.Controls.Add(this.fileLocLabel);
            this.encryptDecryptFilePanel.Controls.Add(this.decryptPanel);
            this.encryptDecryptFilePanel.Location = new System.Drawing.Point(53, 64);
            this.encryptDecryptFilePanel.Name = "encryptDecryptFilePanel";
            this.encryptDecryptFilePanel.Size = new System.Drawing.Size(702, 320);
            this.encryptDecryptFilePanel.TabIndex = 25;
            // 
            // encryptFileDecimalNotificationLabel
            // 
            this.encryptFileDecimalNotificationLabel.AutoSize = true;
            this.encryptFileDecimalNotificationLabel.Location = new System.Drawing.Point(5, 5);
            this.encryptFileDecimalNotificationLabel.Name = "encryptFileDecimalNotificationLabel";
            this.encryptFileDecimalNotificationLabel.Size = new System.Drawing.Size(210, 13);
            this.encryptFileDecimalNotificationLabel.TabIndex = 15;
            this.encryptFileDecimalNotificationLabel.Text = "Enter values in this box in decimal notation.";
            // 
            // encryptDecryptFileLabel
            // 
            this.encryptDecryptFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encryptDecryptFileLabel.Location = new System.Drawing.Point(53, 38);
            this.encryptDecryptFileLabel.Name = "encryptDecryptFileLabel";
            this.encryptDecryptFileLabel.Size = new System.Drawing.Size(702, 23);
            this.encryptDecryptFileLabel.TabIndex = 26;
            this.encryptDecryptFileLabel.Text = "Encrypt/Decrypt File";
            this.encryptDecryptFileLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(807, 24);
            this.menuStrip.TabIndex = 27;
            this.menuStrip.Text = "menuStrip1";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byLarryEmersonJohnsonToolStripMenuItem,
            this.forCS485SP2023ToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // byLarryEmersonJohnsonToolStripMenuItem
            // 
            this.byLarryEmersonJohnsonToolStripMenuItem.Name = "byLarryEmersonJohnsonToolStripMenuItem";
            this.byLarryEmersonJohnsonToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.byLarryEmersonJohnsonToolStripMenuItem.Text = "by Larry Emerson Johnson";
            // 
            // forCS485SP2023ToolStripMenuItem
            // 
            this.forCS485SP2023ToolStripMenuItem.Name = "forCS485SP2023ToolStripMenuItem";
            this.forCS485SP2023ToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.forCS485SP2023ToolStripMenuItem.Text = "for CS 485, SP2023";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // encryptByteBinaryNotificationLabel
            // 
            this.encryptByteBinaryNotificationLabel.AutoSize = true;
            this.encryptByteBinaryNotificationLabel.Location = new System.Drawing.Point(5, 6);
            this.encryptByteBinaryNotificationLabel.Name = "encryptByteBinaryNotificationLabel";
            this.encryptByteBinaryNotificationLabel.Size = new System.Drawing.Size(202, 13);
            this.encryptByteBinaryNotificationLabel.TabIndex = 16;
            this.encryptByteBinaryNotificationLabel.Text = "Enter values in this box in binary notation.";
            // 
            // encryptBytePanel
            // 
            this.encryptBytePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.encryptBytePanel.Controls.Add(this.encryptBytePanelLabel);
            this.encryptBytePanel.Controls.Add(this.encryptPlaintextLabel);
            this.encryptBytePanel.Controls.Add(this.encryptByteButton);
            this.encryptBytePanel.Controls.Add(this.encryptPlaintextBox);
            this.encryptBytePanel.Controls.Add(this.encryptCipherTextBox);
            this.encryptBytePanel.Controls.Add(this.encryptCiphertextLabel);
            this.encryptBytePanel.Location = new System.Drawing.Point(229, 10);
            this.encryptBytePanel.Name = "encryptBytePanel";
            this.encryptBytePanel.Size = new System.Drawing.Size(454, 67);
            this.encryptBytePanel.TabIndex = 28;
            // 
            // encryptBytePanelLabel
            // 
            this.encryptBytePanelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encryptBytePanelLabel.Location = new System.Drawing.Point(3, 18);
            this.encryptBytePanelLabel.Name = "encryptBytePanelLabel";
            this.encryptBytePanelLabel.Size = new System.Drawing.Size(101, 23);
            this.encryptBytePanelLabel.TabIndex = 28;
            this.encryptBytePanelLabel.Text = "Encrypt";
            this.encryptBytePanelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // decryptBytePanel
            // 
            this.decryptBytePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.decryptBytePanel.Controls.Add(this.decryptBytePanelLabel);
            this.decryptBytePanel.Controls.Add(this.decryptCiphertextLabel);
            this.decryptBytePanel.Controls.Add(this.decryptByteButton);
            this.decryptBytePanel.Controls.Add(this.decryptCiphertextBox);
            this.decryptBytePanel.Controls.Add(this.decryptPlaintextBox);
            this.decryptBytePanel.Controls.Add(this.decryptPlaintextLabel);
            this.decryptBytePanel.Location = new System.Drawing.Point(229, 86);
            this.decryptBytePanel.Name = "decryptBytePanel";
            this.decryptBytePanel.Size = new System.Drawing.Size(454, 67);
            this.decryptBytePanel.TabIndex = 29;
            // 
            // decryptBytePanelLabel
            // 
            this.decryptBytePanelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decryptBytePanelLabel.Location = new System.Drawing.Point(3, 18);
            this.decryptBytePanelLabel.Name = "decryptBytePanelLabel";
            this.decryptBytePanelLabel.Size = new System.Drawing.Size(101, 23);
            this.decryptBytePanelLabel.TabIndex = 28;
            this.decryptBytePanelLabel.Text = "Decrypt";
            this.decryptBytePanelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // decryptCiphertextLabel
            // 
            this.decryptCiphertextLabel.Location = new System.Drawing.Point(110, 11);
            this.decryptCiphertextLabel.Name = "decryptCiphertextLabel";
            this.decryptCiphertextLabel.Size = new System.Drawing.Size(100, 13);
            this.decryptCiphertextLabel.TabIndex = 23;
            this.decryptCiphertextLabel.Text = "Ciphertext Byte";
            this.decryptCiphertextLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // decryptByteButton
            // 
            this.decryptByteButton.Location = new System.Drawing.Point(225, 18);
            this.decryptByteButton.Name = "decryptByteButton";
            this.decryptByteButton.Size = new System.Drawing.Size(100, 23);
            this.decryptByteButton.TabIndex = 22;
            this.decryptByteButton.Text = "Decrypt Byte";
            this.decryptByteButton.UseVisualStyleBackColor = true;
            this.decryptByteButton.Click += new System.EventHandler(this.decryptByteButton_Click);
            // 
            // decryptCiphertextBox
            // 
            this.decryptCiphertextBox.Location = new System.Drawing.Point(110, 27);
            this.decryptCiphertextBox.MaxLength = 8;
            this.decryptCiphertextBox.Name = "decryptCiphertextBox";
            this.decryptCiphertextBox.Size = new System.Drawing.Size(100, 20);
            this.decryptCiphertextBox.TabIndex = 18;
            // 
            // decryptPlaintextBox
            // 
            this.decryptPlaintextBox.Location = new System.Drawing.Point(340, 27);
            this.decryptPlaintextBox.Name = "decryptPlaintextBox";
            this.decryptPlaintextBox.ReadOnly = true;
            this.decryptPlaintextBox.Size = new System.Drawing.Size(100, 20);
            this.decryptPlaintextBox.TabIndex = 19;
            // 
            // decryptPlaintextLabel
            // 
            this.decryptPlaintextLabel.Location = new System.Drawing.Point(340, 11);
            this.decryptPlaintextLabel.Name = "decryptPlaintextLabel";
            this.decryptPlaintextLabel.Size = new System.Drawing.Size(100, 13);
            this.decryptPlaintextLabel.TabIndex = 24;
            this.decryptPlaintextLabel.Text = "Plaintext Byte";
            this.decryptPlaintextLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SDESForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 614);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.encryptDecryptFileLabel);
            this.Controls.Add(this.encryptDecryptFilePanel);
            this.Controls.Add(this.encryptDecryptByteLabel);
            this.Controls.Add(this.encryptDecryptBytePanel);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "SDESForm";
            this.Text = "SDES";
            this.encryptPanel.ResumeLayout(false);
            this.encryptPanel.PerformLayout();
            this.decryptPanel.ResumeLayout(false);
            this.decryptPanel.PerformLayout();
            this.encryptDecryptBytePanel.ResumeLayout(false);
            this.encryptDecryptBytePanel.PerformLayout();
            this.encryptDecryptFilePanel.ResumeLayout(false);
            this.encryptDecryptFilePanel.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.encryptBytePanel.ResumeLayout(false);
            this.encryptBytePanel.PerformLayout();
            this.decryptBytePanel.ResumeLayout(false);
            this.decryptBytePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogBox;
        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.Label fileLocLabel;
        private System.Windows.Forms.TextBox encryptKeyBox;
        private System.Windows.Forms.TextBox subKey1Box;
        private System.Windows.Forms.TextBox subKey2Box;
        private System.Windows.Forms.Label keyInputEncryptFileLabel;
        private System.Windows.Forms.Label subkey1Label;
        private System.Windows.Forms.Label subkey2Label;
        private System.Windows.Forms.Button encryptFileButton;
        private System.Windows.Forms.Panel encryptPanel;
        private System.Windows.Forms.Label encryptLabel;
        private System.Windows.Forms.Panel decryptPanel;
        private System.Windows.Forms.TextBox decryptKeyBox;
        private System.Windows.Forms.Label keyInputDecryptFileLabel;
        private System.Windows.Forms.Label decryptLabel;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.CheckBox sameEncryptionSoftwareCheckBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox byteKeyTextBox;
        private System.Windows.Forms.TextBox encryptPlaintextBox;
        private System.Windows.Forms.Label keyInputBinaryEncryptDecryptLabel;
        private System.Windows.Forms.TextBox encryptCipherTextBox;
        private System.Windows.Forms.Button encryptByteButton;
        private System.Windows.Forms.Label encryptPlaintextLabel;
        private System.Windows.Forms.Label encryptCiphertextLabel;
        private System.Windows.Forms.Label encryptDecryptByteLabel;
        private System.Windows.Forms.Panel encryptDecryptBytePanel;
        private System.Windows.Forms.Panel encryptDecryptFilePanel;
        private System.Windows.Forms.Label encryptDecryptFileLabel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byLarryEmersonJohnsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forCS485SP2023ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label encryptFileDecimalNotificationLabel;
        private System.Windows.Forms.Label encryptByteBinaryNotificationLabel;
        private System.Windows.Forms.Panel decryptBytePanel;
        private System.Windows.Forms.Label decryptBytePanelLabel;
        private System.Windows.Forms.Label decryptCiphertextLabel;
        private System.Windows.Forms.Button decryptByteButton;
        private System.Windows.Forms.TextBox decryptCiphertextBox;
        private System.Windows.Forms.TextBox decryptPlaintextBox;
        private System.Windows.Forms.Label decryptPlaintextLabel;
        private System.Windows.Forms.Panel encryptBytePanel;
        private System.Windows.Forms.Label encryptBytePanelLabel;
    }
}

