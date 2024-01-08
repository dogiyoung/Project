using System.Text;
using System.Windows.Forms;

namespace LottoProject
{
    internal class ClickCopyBtn
    {
        public void onCopyButtonClicked(ListView listView)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (ListViewItem item in listView.SelectedItems)
            {
                if (item != null)
                {
                    int count = 0;
                    foreach (ListViewItem.ListViewSubItem sub in item.SubItems)
                    {
                        stringBuilder.Append(sub.Text);
                        count++;
                        if (count < item.SubItems.Count)    // 마지막 문자 전까지 "," 추가
                        {
                            stringBuilder.Append(", ");
                        }
                    }
                }
                stringBuilder.AppendLine();
            }
            Clipboard.SetDataObject(stringBuilder.ToString().Trim());
        }
        //ListViewItem은 행 ListViewSubItem을 열을 나타냄
    }
}
