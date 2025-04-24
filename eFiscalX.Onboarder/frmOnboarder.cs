using System.Xml.Linq;

namespace eFiscalX.Onboarder
{
    public partial class frmOnboarder : Form
    {
        public frmOnboarder()
        {
            InitializeComponent();
        }

        private void btnOnboard_Click(object sender, EventArgs e)
        {
            if (!ValidateAllFields())
                return;

            var onBoardModel = new Onboard
            {
                FiscalizationNo = txtFiscalizationNo.Text.Trim(),
                PosId = ulong.Parse(txtPosId.Text.Trim()),
                BranchNo = ulong.Parse(txtBranchId.Text.Trim()),
                ApplicationId = ulong.Parse(txtAppId.Text.Trim())
            };

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
