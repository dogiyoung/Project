using System;
using System.Drawing;
using System.Windows.Forms;

namespace LottoProject
{
    public partial class Form1 : Form
    {
        private TextBox[] textBoxes;
        private CheckBox[] checkBoxes;
        DataList dataList = new DataList();
        public Form1()
        {
            SetInitialButtons setInitialButtons = new SetInitialButtons();
            InitializeComponent();
            this.MinimumSize = new Size(800, 800);
            this.KeyPreview = true; 
            timer1.Start();
            setInitialButtons.InitialButtons(this); // 버튼 초기설정 false
            dataList.SetInitialDataList(lvwDataList);
            textBoxes = new TextBox[] { txt1, txt2, txt3, txt4, txt5, txt6 };
            checkBoxes = new CheckBox[] { chk1, chk2, chk3, chk4, chk5, chk6 };
        }
        internal ListView MyListView    // 다른 class에서 사용할 버튼
        {
            get { return lvwDataList; }
        }
        internal Button MyAddButton
        {
            get { return btnAddList; }
        }
        internal Button MyCopyButton
        {
            get { return btnCopy; }
        }
        internal Button MyExportButton
        {
            get { return btnExport; }
        }
        internal Button MyRemoveListallButton
        {
            get { return btnRemoveListall; }
        }
        internal Button MyRemoveListitemButton
        {
            get { return btnRemoveListitem; }
        }
        internal Button MyRunButton
        {
            get { return btnRun; }
        }

        private void ClickEvent(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss");
        }

        MessageBoxHandler messageBoxHandler = new MessageBoxHandler();
        private void btnExit_Click(object sender, EventArgs e)
        {
            messageBoxHandler.ExitMessage();
        }

        private void tnmExit_Click(object sender, EventArgs e)
        {
            messageBoxHandler.ExitMessage();
        }

        private void btnRun_Click(object sender, EventArgs e)   
        {
            btnCopy.Enabled = true;
            btnExport.Enabled = true;
            btnRemoveListall.Enabled = true;
            btnRemoveListitem.Enabled = true;

            ClickRunBtn clickRunBtn = new ClickRunBtn();
            if (!clickRunBtn.ExceededValues(textBoxes)) // 1~45 범위의 수 일 경우
            {
                clickRunBtn.onRunButtonClicked(textBoxes,this);
            }
        }
        private void btnClearNum_Click(object sender, EventArgs e)
        {
            CelarRandomValue celarRandomValue = new CelarRandomValue();
            celarRandomValue.CelarRandomValues(textBoxes, checkBoxes);
        }

        FixCheckBox fixCheckBox = new FixCheckBox();
        private void chk1_CheckedChanged_1(object sender, EventArgs e)
        {
            fixCheckBox.FixValue(textBoxes[0], checkBoxes[0]);
        }

        private void chk2_CheckedChanged(object sender, EventArgs e)
        {
            fixCheckBox.FixValue(textBoxes[1], checkBoxes[1]);
        }

        private void chk3_CheckedChanged(object sender, EventArgs e)
        {
            fixCheckBox.FixValue(textBoxes[2], checkBoxes[2]);
        }

        private void chk4_CheckedChanged(object sender, EventArgs e)
        {
            fixCheckBox.FixValue(textBoxes[3], checkBoxes[3]);
        }

        private void chk5_CheckedChanged(object sender, EventArgs e)
        {
            fixCheckBox.FixValue(textBoxes[4], checkBoxes[4]);
        }

        private void chk6_CheckedChanged(object sender, EventArgs e)
        {
            fixCheckBox.FixValue(textBoxes[5], checkBoxes[5]);
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            ClickCopyBtn clickCopyBtn = new ClickCopyBtn();
            clickCopyBtn.onCopyButtonClicked(lvwDataList);
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            ClickExportBtn clickExportBtn = new ClickExportBtn();
            clickExportBtn.onExportButtonClicked(lvwDataList);
        }
        private void btnRemoveListall_Click(object sender, EventArgs e)
        {
            dataList.RemoveAllDataList(lvwDataList);

        }
        private void btnRemoveListitem_Click(object sender, EventArgs e)
        {
            dataList.RemoveRowData(lvwDataList);
        }
        private void btnAddList_Click(object sender, EventArgs e)
        {
            if (!dataList.FindDuplicateListValue(lvwDataList, textBoxes))
            {
                dataList.AddDataList(lvwDataList, textBoxes);
            }
            else
            {
                Form2 form2 = new Form2(this);  
                form2.ShowDialog();
            }

        }

        private void lvwDataList_Resize(object sender, EventArgs e)
        {
            dataList.SizeAutoChange(lvwDataList);   // 창 크기 조절시 size 변환
        }

        private void From1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.X)
            {
                messageBoxHandler.ExitMessage();
            }
        }

    }
}
