using System.Windows.Forms;

namespace LottoProject
{
    internal class CelarRandomValue
    {
        public void CelarRandomValues(TextBox[] textBoxes, CheckBox[] checkBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Text = "1~45";
                textBox.Enabled = true;

            }
            foreach (CheckBox checkBox in checkBoxes)
            {
                checkBox.Checked = false;
                
            }
        }
    }
}
