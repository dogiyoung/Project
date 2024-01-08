using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LottoProject
{
    internal class DataList
    {
        public void SetInitialDataList(ListView listView)
        {
            int dateTimenWidth = listView.Width / 4;
            int listValueWidth = listView.Width / 8;
            listView.View = View.Details;
            listView.GridLines = true;
            listView.FullRowSelect = true;
            listView.BorderStyle = BorderStyle.FixedSingle;
            listView.Columns.Add("Datetime", dateTimenWidth);
            listView.Columns.Add("1", listValueWidth);
            listView.Columns.Add("2", listValueWidth);
            listView.Columns.Add("3", listValueWidth);
            listView.Columns.Add("4", listValueWidth);
            listView.Columns.Add("5", listValueWidth);
            listView.Columns.Add("6", listValueWidth);
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, listView.Width / 20);
            listView.SmallImageList = imgList;
        }
        public void SizeAutoChange(ListView listView)
        {
            listView.BeginUpdate();
            int dateTimenWidth = listView.Width / 4;
            int listValueWidth = listView.Width / 8;
            if (listView.Columns.Count > 0)
            {
                listView.Columns[0].Width = dateTimenWidth;
            }
            for (int i = 1; i < listView.Columns.Count; i++)
            {
                listView.Columns[i].Width = listValueWidth;
            }
            listView.EndUpdate();
        }
        public class StringAsNumericComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                if (int.TryParse(x, out int xNum) && int.TryParse(y, out int yNum))
                // x,y가 정수로 구성되어있는건지 확인
                {
                    return xNum.CompareTo(yNum);
                }
                else
                {
                    return string.Compare(x, y);
                }
            }
        }
        public void AddDataList(ListView listView, TextBox[] textBoxes)
        {
            string dateTime = DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss");
            string[] row1 = new string[textBoxes.Length + 1];
            row1[0] = dateTime;

            string[] sortedTextBoxes = textBoxes.Select(tb => tb.Text).ToArray();
            // TextBox[] 의 값을 string 배열로 변환
            Array.Sort(sortedTextBoxes, new StringAsNumericComparer());

            for (int i = 0; i < sortedTextBoxes.Length; i++)
            {
                row1[i + 1] = sortedTextBoxes[i];
            }
            ListViewItem addItem = new ListViewItem(row1);
            listView.Items.Add(addItem);
        }
        public bool FindDuplicateListValue(ListView listView, TextBox[] textBoxes)
        {
            HashSet<int> lvwNumbers = new HashSet<int>();
            List<int> txtNumbers = new List<int>();
            foreach (ListViewItem item in listView.Items)
            {
                ListViewItem lastAddedItem = listView.Items[listView.Items.Count - 1];
                for (int i = 1; i < listView.Columns.Count; i++)
                {
                    int lvwNumber;
                    if (int.TryParse(lastAddedItem.SubItems[i].Text, out lvwNumber)) 
                    {
                        lvwNumbers.Add(lvwNumber);
                    }
                }
            }
            for (int i = 0; i < textBoxes.Length; i++)
            {
                int txtNumber;
                if (int.TryParse(textBoxes[i].Text, out txtNumber)) 
                {
                    txtNumbers.Add(txtNumber);
                }
            }
            if (lvwNumbers.SetEquals(txtNumbers))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void RemoveAllDataList(ListView listView)
        {
            listView.Items.Clear();
        }
        public void RemoveRowData(ListView listView)
        {
            if (listView.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    listView.Items.Remove(item);
                }
            }
        }
    }
}
