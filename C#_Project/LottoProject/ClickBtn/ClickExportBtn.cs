using System;
using System.IO;
using System.Windows.Forms;

namespace LottoProject
{
    internal class ClickExportBtn
    {
        public void onExportButtonClicked(ListView listView)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "텍스트 파일|*.txt|모든 파일|*.*";
            saveFileDialog.Title = "파일 저장";
            saveFileDialog.FilterIndex = 1;     // txt 파일 필터
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (ListViewItem item in listView.Items)
                    {
                        string line = "";
                        if (item != null)
                        {
                            int count = 0;
                            foreach (ListViewItem.ListViewSubItem sub in item.SubItems)
                            {
                                line += sub.Text;
                                count++;
                                if (count < item.SubItems.Count)
                                {
                                    line += (", ");
                                }
                            }
                        }
                        sw.WriteLine(line.Trim()); // 각 줄을 파일에 씁니다.
                    }
                }
            }
        }
    }
}
