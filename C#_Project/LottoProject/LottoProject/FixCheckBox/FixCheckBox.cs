using System.Windows.Forms;

namespace LottoProject
{
    internal class FixCheckBox
    {
        public void FixValue(TextBox textBox, CheckBox checkBox)
        {
            if (checkBox.Checked)
            {
                textBox.Enabled = false; // 체크되면 TextBox 비활성화
            }
            else
            {
                textBox.Enabled = true; // 체크 해제되면 TextBox 활성화
            }
        }
    }
}
