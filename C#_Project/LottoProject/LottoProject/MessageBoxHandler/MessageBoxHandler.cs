using System;
using System.Windows.Forms;

namespace LottoProject
{
    internal class MessageBoxHandler
    {
        public void ExitMessage()
        {
            // 사용자 입력 받는 메시지 박스
            DialogResult result = MessageBox.Show("종료 하시겠습니까?", "경고", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // 사용자의 선택에 따른 처리
            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }
        public void RandomValueMessage()
        {
            DialogResult result = MessageBox.Show("중복된 숫자입니다 다시 입력해주세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        public void MaxValueMessage()
        {
            DialogResult result = MessageBox.Show("45보다 큰 숫자를 입력했습니다. \n 다시 입력해주세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        public void MinValueMessage()
        {
            DialogResult result = MessageBox.Show("1보다 작을 숫자를 입력했습니다. \n다시 입력해주세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}


