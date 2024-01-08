using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LottoProject
{
    internal class ClickRunBtn
    {
        MessageBoxHandler messageList = new MessageBoxHandler();
        Form1 parentForm;
        public void onRunButtonClicked(TextBox[] textBoxes,Form1 parentForm)
        {
            this.parentForm = parentForm;
            bool isDuplicate = false;
            Random rand = new Random();
            HashSet<int> numbers = new HashSet<int>(); 

            for (int i = 0; i < textBoxes.Length; i++)  // 중복 값 비교
            {
                int currentNumber;
                if (int.TryParse(textBoxes[i].Text, out currentNumber))
                {
                    if (!numbers.Add(currentNumber))    // numbers에 같은 값 작성시 false 반환
                    {
                        textBoxes[i].Focus();
                        isDuplicate = true;
                        break;
                    }
                }
            }
           
            if (!isDuplicate)   // 중복 값이 아닐경우 1~45의 랜덤 수 textBox에 추가
            {
                foreach (TextBox textBox in textBoxes)
                {
                    int randNum = rand.Next(1, 45);
                    if (textBox.Enabled)
                    {
                        textBox.Text = randNum.ToString();
                    }
                }
                parentForm.MyAddButton.Enabled = true;
            }
            else
            {
                messageList.RandomValueMessage();
                parentForm.MyAddButton.Enabled = false; 
            }
        }
        public bool ExceededValues(TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
            {
                int exccedNumber;
                if (int.TryParse(textBox.Text, out exccedNumber))   //string값 int로 변환
                {
                    if (exccedNumber < 1 || exccedNumber > 45)
                    {
                        if (exccedNumber < 1)
                        {
                            messageList.MinValueMessage();
                            return true;
                        }
                        else
                        {
                            messageList.MaxValueMessage();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
