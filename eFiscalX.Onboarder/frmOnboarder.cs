using System.Xml.Linq;

namespace eFiscalX.Onboarder
{
    public partial class frmOnboarder : Form
    {
        public frmOnboarder()
        {
            InitializeComponent();
        }

        private async void btnOnboard_Click(object sender, EventArgs e)
        {
            if (!ValidateAllFields())
                return;

            bool isProdEnv = rdbProdEnv.Checked;
            var onBoardModel = new OnboardRequest
            {
                NUI = ulong.Parse(txtNui.Text.Trim()),
                FiscalizationNo = txtFiscalizationNo.Text.Trim(),
                PosId = ulong.Parse(txtPosId.Text.Trim()),
                BranchNo = ulong.Parse(txtBranchId.Text.Trim()),
                ApplicationId = ulong.Parse(txtAppId.Text.Trim())
            };

            var httpClient = new HttpClient();
            var taxAuthorityClient = new TaxAuthorityClient(httpClient, isProdEnv);

            try
            {
                var verificationCode = await taxAuthorityClient.GetVerificationCodeAsync(onBoardModel);
                MessageBox.Show($"Verification Code: {verificationCode.VerificationCode}, Business: {verificationCode.BusinessName}");

                // Step 1: Generate ECDSA P-256 Key
                var factory = new CertificateFactory();
                using var ecdsa = factory.GenerateEcdsaKey();

                // Step 2: Create CSR
                var csrRequest = new CsrRequest
                {
                    BusinessId = onBoardModel.NUI,
                    BusinessName = verificationCode.BusinessName,
                    Country = "RKS",
                    BranchId = onBoardModel.BranchNo,
                    PosId = onBoardModel.PosId,
                };

                var csrBytes = factory.CreateCertificateSigningRequest(ecdsa, csrRequest);

                // Step 3: Save CSR and Private Key
                factory.SaveCsrToPem($"{csrRequest.BusinessId}_csr.pem", csrBytes);
                factory.SavePrivateKeyToPem($"{csrRequest.BusinessId}private_key.pem", ecdsa);

                Console.WriteLine("CSR and private key generated using ECDSA P-256.");

                var request = new SignCsrRequest
                {
                    BusinessName = verificationCode.BusinessName,
                    BusinessId = onBoardModel.NUI,
                    BranchId = onBoardModel.BranchNo,
                    VerificationNo = verificationCode.VerificationCode,
                    PosId = onBoardModel.PosId,
                    ApplicationId = onBoardModel.ApplicationId,
                    Csr = File.ReadAllText("path/to/your/request.csr.pem")
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

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
    }
}
