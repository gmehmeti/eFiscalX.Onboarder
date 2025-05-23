using eFiscalX.Onboarder.Services;
using System.Windows.Forms;
using System.Xml.Linq;

namespace eFiscalX.Onboarder
{
    public partial class frmOnboarder : Form
    {
        public frmOnboarder()
        {
            InitializeComponent();
        }

        #region Onboard Click

        private async void btnOnboard_Click(object sender, EventArgs e)
        {
            if (!ValidateAllFields())
                return;

            this.lblTitle.Text = lblStatus.Text = string.Empty;
            this.rtxtSignedCertificate.Text = this.rtxtCertificate.Text = this.rtxtPrivateKey.Text = string.Empty;

            bool isProdEnv = rdbProdEnv.Checked;
            var onBoardRequest = new OnboardRequest
            {
                NUI = ulong.Parse(txtNui.Text.Trim()),
                FiscalizationNo = txtFiscalizationNo.Text.Trim(),
                PosId = ulong.Parse(txtPosId.Text.Trim()),
                BranchId = ulong.Parse(txtBranchId.Text.Trim()),
                ApplicationId = ulong.Parse(txtAppId.Text.Trim())
            };

            var httpClient = new HttpClient();
            var taxAuthorityClient = new TaxAuthorityClient(httpClient, isProdEnv);

            try
            {
                var verificationCode = await taxAuthorityClient.GetVerificationCodeAsync(onBoardRequest);
                LogMessage($"Verification Code: {verificationCode.VerificationCode}, Business: {verificationCode.BusinessName}");
                lblTitle.Text = verificationCode.BusinessName;

                // Step 1: Initialize CertificateFactory
                var certFactory = new CertificateFactory();

                // Step 2: Create CSR
                var csrRequest = new CsrRequest
                {
                    BusinessId = onBoardRequest.NUI,
                    BusinessName = verificationCode.BusinessName,
                    Country = "XK",
                    BranchId = onBoardRequest.BranchId,
                    PosId = onBoardRequest.PosId,
                };

                var (privateKeyPem, csrPem) = certFactory.CreateCertificateSigningRequest(csrRequest);
                LogMessage("Private Key and CSR generated successfully (ECDSA P-256).");
                rtxtPrivateKey.Text = privateKeyPem;
                rtxtCertificate.Text = csrPem;

                var signCsrRequest = new SignCsrRequest
                {
                    BusinessName = verificationCode.BusinessName,
                    BusinessId = onBoardRequest.NUI,
                    BranchId = onBoardRequest.BranchId,
                    VerificationCode = verificationCode.VerificationCode,
                    PosId = onBoardRequest.PosId,
                    ApplicationId = onBoardRequest.ApplicationId,
                    Csr = csrPem
                };

                var signedCert = await taxAuthorityClient.SignCsrAsync(signCsrRequest);
                LogMessage($"Received signed certificate from Fiscalization Service.");
                rtxtSignedCertificate.Text = signedCert.SignedCertificate;

                certFactory.SaveSignedCertificate($"{onBoardRequest.NUI}_signed_certificate.pem", signedCert.SignedCertificate);
                LogMessage($"Saved signed certificate to PEM format.");

                certFactory.SaveSignedCertificatePfx($"{onBoardRequest.NUI}_signed_certificate.pfx", privateKeyPem, signedCert.SignedCertificate);
                LogMessage($"Exported signed certificate and private key to PFX.");

                lblStatus.Text = "Fiscalization onboarding finalized";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                LogMessage($"Error: {ex.Message}");
            }
        } 

        #endregion

        #region ValidateAllFields

        private bool ValidateAllFields()
        {
            if (!ValidateField(txtNui.Text, lblNui.Text))
                return false;

            if (!ValidateField(txtFiscalizationNo.Text, lblFiscalizationNo.Text))
                return false;

            if (!ValidateField(txtPosId.Text, lblPosId.Text))
                return false;

            if (!ValidateField(txtBranchId.Text, lblBranchId.Text))
                return false;

            if (!ValidateField(txtAppId.Text, lblAppId.Text))
                return false;

            return true;
        }

        #endregion

        #region ValidateField

        private bool ValidateField(string input, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show($"{fieldName} cannot be empty.");
                return false;
            }

            if (!input.All(char.IsDigit))
            {
                MessageBox.Show($"{fieldName} must contain only numbers.");
                return false;
            }

            return true;
        }

        #endregion

        #region LogMessage

        private void LogMessage(string message)
        {
            this.rtxtLog.AppendText(message + Environment.NewLine);
        } 

        #endregion
    }
}
