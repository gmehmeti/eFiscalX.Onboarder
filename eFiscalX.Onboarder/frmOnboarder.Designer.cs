namespace eFiscalX.Onboarder
{
    partial class frmOnboarder
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabOnboarding = new TabPage();
            rtxtLog = new RichTextBox();
            rdbProdEnv = new RadioButton();
            rdbTestEnv = new RadioButton();
            lblTitle = new Label();
            txtNui = new TextBox();
            txtFiscalizationNo = new TextBox();
            txtPosId = new TextBox();
            txtBranchId = new TextBox();
            txtAppId = new TextBox();
            lblNui = new Label();
            lblFiscalizationNo = new Label();
            lblPosId = new Label();
            lblBranchId = new Label();
            lblAppId = new Label();
            btnReset = new Button();
            btnOnboard = new Button();
            lblStatus = new Label();
            tabCertificate = new TabPage();
            label1 = new Label();
            lblCertificate = new Label();
            rtxtPrivateKey = new RichTextBox();
            rtxtCertificate = new RichTextBox();
            tabSignature = new TabPage();
            label2 = new Label();
            rtxtSignedCertificate = new RichTextBox();
            statusStrip1 = new StatusStrip();
            tsslName = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            tabControl.SuspendLayout();
            tabOnboarding.SuspendLayout();
            tabCertificate.SuspendLayout();
            tabSignature.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.Controls.Add(tabOnboarding);
            tabControl.Controls.Add(tabCertificate);
            tabControl.Controls.Add(tabSignature);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.Padding = new Point(50, 3);
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1212, 574);
            tabControl.TabIndex = 0;
            // 
            // tabOnboarding
            // 
            tabOnboarding.Controls.Add(rtxtLog);
            tabOnboarding.Controls.Add(rdbProdEnv);
            tabOnboarding.Controls.Add(rdbTestEnv);
            tabOnboarding.Controls.Add(lblTitle);
            tabOnboarding.Controls.Add(txtNui);
            tabOnboarding.Controls.Add(txtFiscalizationNo);
            tabOnboarding.Controls.Add(txtPosId);
            tabOnboarding.Controls.Add(txtBranchId);
            tabOnboarding.Controls.Add(txtAppId);
            tabOnboarding.Controls.Add(lblNui);
            tabOnboarding.Controls.Add(lblFiscalizationNo);
            tabOnboarding.Controls.Add(lblPosId);
            tabOnboarding.Controls.Add(lblBranchId);
            tabOnboarding.Controls.Add(lblAppId);
            tabOnboarding.Controls.Add(btnReset);
            tabOnboarding.Controls.Add(btnOnboard);
            tabOnboarding.Controls.Add(lblStatus);
            tabOnboarding.Location = new Point(4, 32);
            tabOnboarding.Name = "tabOnboarding";
            tabOnboarding.Size = new Size(1204, 538);
            tabOnboarding.TabIndex = 0;
            tabOnboarding.Text = "Onboarding";
            // 
            // rtxtLog
            // 
            rtxtLog.BorderStyle = BorderStyle.None;
            rtxtLog.Location = new Point(819, 87);
            rtxtLog.Name = "rtxtLog";
            rtxtLog.Size = new Size(366, 390);
            rtxtLog.TabIndex = 16;
            rtxtLog.Text = "";
            // 
            // rdbProdEnv
            // 
            rdbProdEnv.AutoSize = true;
            rdbProdEnv.Location = new Point(382, 314);
            rdbProdEnv.Name = "rdbProdEnv";
            rdbProdEnv.Size = new Size(96, 24);
            rdbProdEnv.TabIndex = 15;
            rdbProdEnv.Text = "PROD Env";
            rdbProdEnv.UseVisualStyleBackColor = true;
            // 
            // rdbTestEnv
            // 
            rdbTestEnv.AutoSize = true;
            rdbTestEnv.Checked = true;
            rdbTestEnv.Location = new Point(253, 314);
            rdbTestEnv.Name = "rdbTestEnv";
            rdbTestEnv.Size = new Size(89, 24);
            rdbTestEnv.TabIndex = 14;
            rdbTestEnv.TabStop = true;
            rdbTestEnv.Text = "TEST Env";
            rdbTestEnv.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Blue;
            lblTitle.Location = new Point(25, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1084, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "--";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNui
            // 
            txtNui.Location = new Point(250, 87);
            txtNui.Name = "txtNui";
            txtNui.Size = new Size(509, 27);
            txtNui.TabIndex = 1;
            // 
            // txtFiscalizationNo
            // 
            txtFiscalizationNo.Location = new Point(250, 133);
            txtFiscalizationNo.Name = "txtFiscalizationNo";
            txtFiscalizationNo.Size = new Size(509, 27);
            txtFiscalizationNo.TabIndex = 2;
            // 
            // txtPosId
            // 
            txtPosId.Location = new Point(250, 179);
            txtPosId.Name = "txtPosId";
            txtPosId.Size = new Size(509, 27);
            txtPosId.TabIndex = 3;
            // 
            // txtBranchId
            // 
            txtBranchId.Location = new Point(250, 225);
            txtBranchId.Name = "txtBranchId";
            txtBranchId.Size = new Size(509, 27);
            txtBranchId.TabIndex = 4;
            // 
            // txtAppId
            // 
            txtAppId.Location = new Point(250, 271);
            txtAppId.Name = "txtAppId";
            txtAppId.Size = new Size(509, 27);
            txtAppId.TabIndex = 5;
            // 
            // lblNui
            // 
            lblNui.AutoSize = true;
            lblNui.Location = new Point(59, 90);
            lblNui.Name = "lblNui";
            lblNui.Size = new Size(37, 20);
            lblNui.TabIndex = 6;
            lblNui.Text = "NUI:";
            // 
            // lblFiscalizationNo
            // 
            lblFiscalizationNo.AutoSize = true;
            lblFiscalizationNo.Location = new Point(59, 136);
            lblFiscalizationNo.Name = "lblFiscalizationNo";
            lblFiscalizationNo.Size = new Size(151, 20);
            lblFiscalizationNo.TabIndex = 7;
            lblFiscalizationNo.Text = "Fiscalization Number:";
            // 
            // lblPosId
            // 
            lblPosId.AutoSize = true;
            lblPosId.Location = new Point(59, 182);
            lblPosId.Name = "lblPosId";
            lblPosId.Size = new Size(58, 20);
            lblPosId.TabIndex = 8;
            lblPosId.Text = "POS ID:";
            // 
            // lblBranchId
            // 
            lblBranchId.AutoSize = true;
            lblBranchId.Location = new Point(59, 228);
            lblBranchId.Name = "lblBranchId";
            lblBranchId.Size = new Size(76, 20);
            lblBranchId.TabIndex = 9;
            lblBranchId.Text = "Branch ID:";
            // 
            // lblAppId
            // 
            lblAppId.AutoSize = true;
            lblAppId.Location = new Point(59, 274);
            lblAppId.Name = "lblAppId";
            lblAppId.Size = new Size(108, 20);
            lblAppId.TabIndex = 10;
            lblAppId.Text = "Application ID:";
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.Orange;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(488, 389);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(125, 40);
            btnReset.TabIndex = 11;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = false;
            // 
            // btnOnboard
            // 
            btnOnboard.BackColor = Color.DodgerBlue;
            btnOnboard.FlatStyle = FlatStyle.Flat;
            btnOnboard.ForeColor = Color.White;
            btnOnboard.Location = new Point(634, 389);
            btnOnboard.Name = "btnOnboard";
            btnOnboard.Size = new Size(125, 40);
            btnOnboard.TabIndex = 12;
            btnOnboard.Text = "Onboard";
            btnOnboard.UseVisualStyleBackColor = false;
            btnOnboard.Click += btnOnboard_Click;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.Green;
            lblStatus.Location = new Point(8, 444);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(805, 33);
            lblStatus.TabIndex = 13;
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabCertificate
            // 
            tabCertificate.Controls.Add(label1);
            tabCertificate.Controls.Add(lblCertificate);
            tabCertificate.Controls.Add(rtxtPrivateKey);
            tabCertificate.Controls.Add(rtxtCertificate);
            tabCertificate.Location = new Point(4, 32);
            tabCertificate.Name = "tabCertificate";
            tabCertificate.Size = new Size(1204, 538);
            tabCertificate.TabIndex = 1;
            tabCertificate.Text = "Certificate";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(616, 28);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 3;
            label1.Text = "Private Key";
            // 
            // lblCertificate
            // 
            lblCertificate.AutoSize = true;
            lblCertificate.Location = new Point(23, 28);
            lblCertificate.Name = "lblCertificate";
            lblCertificate.Size = new Size(134, 20);
            lblCertificate.TabIndex = 2;
            lblCertificate.Text = "Certificate Request";
            // 
            // rtxtPrivateKey
            // 
            rtxtPrivateKey.BorderStyle = BorderStyle.None;
            rtxtPrivateKey.Location = new Point(616, 58);
            rtxtPrivateKey.Name = "rtxtPrivateKey";
            rtxtPrivateKey.Size = new Size(561, 374);
            rtxtPrivateKey.TabIndex = 1;
            rtxtPrivateKey.Text = "";
            // 
            // rtxtCertificate
            // 
            rtxtCertificate.BackColor = SystemColors.Window;
            rtxtCertificate.BorderStyle = BorderStyle.None;
            rtxtCertificate.Location = new Point(23, 58);
            rtxtCertificate.Name = "rtxtCertificate";
            rtxtCertificate.ReadOnly = true;
            rtxtCertificate.Size = new Size(561, 374);
            rtxtCertificate.TabIndex = 0;
            rtxtCertificate.Text = "";
            // 
            // tabSignature
            // 
            tabSignature.Controls.Add(label2);
            tabSignature.Controls.Add(rtxtSignedCertificate);
            tabSignature.Location = new Point(4, 32);
            tabSignature.Name = "tabSignature";
            tabSignature.Size = new Size(1204, 538);
            tabSignature.TabIndex = 2;
            tabSignature.Text = "Signed Certificate";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(148, 26);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 4;
            label2.Text = "Signed Certificate";
            // 
            // rtxtSignedCertificate
            // 
            rtxtSignedCertificate.BackColor = SystemColors.Window;
            rtxtSignedCertificate.BorderStyle = BorderStyle.None;
            rtxtSignedCertificate.Location = new Point(148, 59);
            rtxtSignedCertificate.Name = "rtxtSignedCertificate";
            rtxtSignedCertificate.ReadOnly = true;
            rtxtSignedCertificate.Size = new Size(897, 365);
            rtxtSignedCertificate.TabIndex = 3;
            rtxtSignedCertificate.Text = "";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsslName, toolStripStatusLabel2 });
            statusStrip1.Location = new Point(0, 521);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1212, 53);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsslName
            // 
            tsslName.BorderSides = ToolStripStatusLabelBorderSides.Right;
            tsslName.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tsslName.Name = "tsslName";
            tsslName.Padding = new Padding(50, 10, 50, 10);
            tsslName.Size = new Size(261, 47);
            tsslName.Text = "Gazmend Mehmeti";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            toolStripStatusLabel2.ForeColor = SystemColors.HotTrack;
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Padding = new Padding(50, 10, 50, 10);
            toolStripStatusLabel2.Size = new Size(357, 47);
            toolStripStatusLabel2.Text = "gazmendmehmeti@gmail.com";
            // 
            // frmOnboarder
            // 
            ClientSize = new Size(1212, 574);
            Controls.Add(statusStrip1);
            Controls.Add(tabControl);
            Name = "frmOnboarder";
            Text = "eFiscalX Onboarder";
            tabControl.ResumeLayout(false);
            tabOnboarding.ResumeLayout(false);
            tabOnboarding.PerformLayout();
            tabCertificate.ResumeLayout(false);
            tabCertificate.PerformLayout();
            tabSignature.ResumeLayout(false);
            tabSignature.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabOnboarding;
        private TabPage tabCertificate;
        private TabPage tabSignature;
        private Label lblTitle;
        private Label lblNui;
        private Label lblFiscalizationNo;
        private Label lblPosId;
        private Label lblBranchId;
        private Label lblAppId;
        private TextBox txtNui;
        private TextBox txtFiscalizationNo;
        private TextBox txtPosId;
        private TextBox txtBranchId;
        private TextBox txtAppId;
        private Button btnReset;
        private Button btnOnboard;
        private Label lblStatus;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsslName;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private RadioButton rdbProdEnv;
        private RadioButton rdbTestEnv;
        private RichTextBox rtxtLog;
        private RichTextBox rtxtPrivateKey;
        private RichTextBox rtxtCertificate;
        private Label label1;
        private Label lblCertificate;
        private Label label2;
        private RichTextBox rtxtSignedCertificate;
    }
}
