using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_Kaushan
{
    public partial class Form1 : Form
    {
        private NumberSystemsTest test;
        private bool answered;

        public Form1()
        {
            InitializeComponent();
            test = new NumberSystemsTest();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            test.Reset();
            ShowQuestion();
            btnStart.Visible = false;
            pnlQuestions.Visible = true;
            pnlResults.Visible = false;
            answered = false;
        }

        private void ShowQuestion()
        {
            Question question = test.GetCurrentQuestion();
            if (question == null)
            {
                ShowResults();
                return;
            }

            answered = false;
            lblExplanation.Text = "";
            ClearRadioButtons();

            lblQuestionNumber.Text = $"Вопрос {test.GetCurrentQuestionNumber()} из {test.GetTotalQuestions()}";
            lblQuestion.Text = question.Text;
            rdoOption1.Text = question.Options[0];
            rdoOption2.Text = question.Options[1];
            rdoOption3.Text = question.Options[2];
            rdoOption4.Text = question.Options[3];

            btnNext.Enabled = false;
        }

        private void ClearRadioButtons()
        {
            rdoOption1.Checked = false;
            rdoOption2.Checked = false;
            rdoOption3.Checked = false;
            rdoOption4.Checked = false;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (answered)
                return;

            RadioButton radio = (RadioButton)sender;
            if (radio.Checked)
            {
                int selectedIndex = -1;
                if (rdoOption1.Checked) selectedIndex = 0;
                else if (rdoOption2.Checked) selectedIndex = 1;
                else if (rdoOption3.Checked) selectedIndex = 2;
                else if (rdoOption4.Checked) selectedIndex = 3;

                bool isCorrect = test.CheckAnswer(selectedIndex);
                answered = true;

                Question question = test.GetCurrentQuestion();
                if (isCorrect)
                {
                    lblExplanation.Text = "✓ Правильно! " + question.Explanation;
                    lblExplanation.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblExplanation.Text = "✗ Неправильно! " + question.Explanation;
                    lblExplanation.ForeColor = System.Drawing.Color.Red;
                }

                btnNext.Enabled = true;
                DisableRadioButtons();
            }
        }

        private void DisableRadioButtons()
        {
            rdoOption1.Enabled = false;
            rdoOption2.Enabled = false;
            rdoOption3.Enabled = false;
            rdoOption4.Enabled = false;
        }

        private void EnableRadioButtons()
        {
            rdoOption1.Enabled = true;
            rdoOption2.Enabled = true;
            rdoOption3.Enabled = true;
            rdoOption4.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (test.HasNextQuestion())
            {
                test.NextQuestion();
                EnableRadioButtons();
                ShowQuestion();
            }
            else
            {
                ShowResults();
            }
        }

        private void ShowResults()
        {
            pnlQuestions.Visible = false;
            pnlResults.Visible = true;

            int score = test.GetScore();
            double percentage = test.GetScorePercentage();
            int total = test.GetTotalQuestions();

            string resultText = $"Тест завершен!\n\n" +
                               $"Правильных ответов: {score} из {total}\n" +
                               $"Процент правильных: {percentage:F1}%\n\n";

            if (percentage == 100)
                resultText += "Отлично! Вы отлично знаете системы счисления!";
            else if (percentage >= 80)
                resultText += "Хорошо! Вы хорошо знаете системы счисления.";
            else if (percentage >= 60)
                resultText += "Удовлетворительно. Нужно еще потренироваться.";
            else
                resultText += "Нужно больше учиться. Повторите теорию систем счисления.";

            lblResult.Text = resultText;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            btnStart.Visible = true;
            pnlQuestions.Visible = false;
            pnlResults.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rdoOption1.CheckedChanged += RadioButton_CheckedChanged;
            rdoOption2.CheckedChanged += RadioButton_CheckedChanged;
            rdoOption3.CheckedChanged += RadioButton_CheckedChanged;
            rdoOption4.CheckedChanged += RadioButton_CheckedChanged;
        }
    }
}
