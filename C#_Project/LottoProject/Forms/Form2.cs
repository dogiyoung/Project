using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LottoProject
{

    internal partial class Form2 : Form
    {
        Form1 parentForm;
        private TextBox[] textBoxes;
        public Form2(Form1 parentForm)
        {
            InitializeComponent();
            this.MinimumSize = new Size(400, 300);
            this.MaximumSize = new Size(400, 300);
            textBoxes = new TextBox[] { txt1, txt2, txt3, txt4, txt5, txt6 };
            this.parentForm = parentForm;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ClickRunBtn clickRunBtn = new ClickRunBtn();
            ListView lvwFromparentForm = parentForm.MyListView;
            if (!clickRunBtn.ExceededValues(textBoxes)) // 1~45 범위의 수 일 경우
            {
                bool isDuplicate = false;
                HashSet<int> numbers = new HashSet<int>();
                for (int i = 0; i < textBoxes.Length; i++)
                {
                    int currentNumber;
                    if (int.TryParse(textBoxes[i].Text, out currentNumber))
                    {
                        if (!numbers.Add(currentNumber))
                        {
                            textBoxes[i].Focus();
                            isDuplicate = true;
                            break;
                        }
                    }
                }
                if (!isDuplicate)
                {
                    DataList dataList = new DataList();
                    dataList.AddDataList(lvwFromparentForm, textBoxes);
                    this.Close();
                }
                else
                {
                    MessageBoxHandler messageBoxHandler = new MessageBoxHandler();
                    messageBoxHandler.RandomValueMessage();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }
    }
}
