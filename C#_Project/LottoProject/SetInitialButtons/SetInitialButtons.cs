using System.Windows.Forms;
namespace LottoProject
{
    internal class SetInitialButtons
    {
        Form1 parentForm;
        public void InitialButtons(Form1 parentForm)
        {
            this.parentForm = parentForm;
            parentForm.MyAddButton.Enabled = false;
            parentForm.MyCopyButton.Enabled = false;
            parentForm.MyExportButton.Enabled = false;
            parentForm.MyRemoveListallButton.Enabled = false;
            parentForm.MyRemoveListitemButton.Enabled = false;
        }
    }
}
