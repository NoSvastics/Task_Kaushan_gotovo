using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_Kaushan
{
    public class Question
    {
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public int CorrectAnswerIndex { get; set; }
        public string Explanation { get; set; }
    }

    public class NumberSystemsTest
    {
        private List<Question> questions;
        private int currentQuestionIndex;
        private int score;

        public NumberSystemsTest()
        {
            currentQuestionIndex = 0;
            score = 0;
            InitializeQuestions();
        }

        private void InitializeQuestions()
        {
            questions = new List<Question>
            {
                new Question
                {
                    Text = "Какое число в двоичной системе соответствует десятичному числу 10?",
                    Options = new List<string> { "101", "1010", "1100", "1000" },
                    CorrectAnswerIndex = 1,
                    Explanation = "10₁₀ = 1010₂ (8+2=10)"
                },
                new Question
                {
                    Text = "Какое число в десятичной системе соответствует двоичному числу 1111?",
                    Options = new List<string> { "12", "15", "14", "16" },
                    CorrectAnswerIndex = 1,
                    Explanation = "1111₂ = 15₁₀ (8+4+2+1=15)"
                },
                new Question
                {
                    Text = "Какое число в шестнадцатеричной системе соответствует десятичному числу 255?",
                    Options = new List<string> { "FF", "F0", "AF", "F5" },
                    CorrectAnswerIndex = 0,
                    Explanation = "255₁₀ = FF₁₆ (15*16+15=255)"
                },
                new Question
                {
                    Text = "Сколько цифр используется в восьмеричной системе счисления?",
                    Options = new List<string> { "7", "8", "9", "10" },
                    CorrectAnswerIndex = 1,
                    Explanation = "Восьмеричная система использует цифры 0-7 (всего 8 цифр)"
                },
                new Question
                {
                    Text = "Какое число в восьмеричной системе соответствует десятичному числу 64?",
                    Options = new List<string> { "100", "64", "128", "40" },
                    CorrectAnswerIndex = 0,
                    Explanation = "64₁₀ = 100₈ (1*64+0*8+0=64)"
                },
                new Question
                {
                    Text = "Что означает система счисления?",
                    Options = new List<string> 
                    { 
                        "Способ учета денег",
                        "Символическая запись чисел и правила действий над ними",
                        "Таблица умножения",
                        "Способ письма"
                    },
                    CorrectAnswerIndex = 1,
                    Explanation = "Система счисления - это символический способ записи чисел и правила выполнения операций над ними"
                },
                new Question
                {
                    Text = "Какая система счисления используется в компьютерах?",
                    Options = new List<string> { "Десятичная", "Двоичная", "Восьмеричная", "Шестнадцатеричная" },
                    CorrectAnswerIndex = 1,
                    Explanation = "В компьютерах используется двоичная система счисления, так как в электронике есть два состояния: 0 и 1"
                },
                new Question
                {
                    Text = "Какое число в двоичной системе соответствует десятичному числу 7?",
                    Options = new List<string> { "111", "101", "110", "100" },
                    CorrectAnswerIndex = 0,
                    Explanation = "7₁₀ = 111₂ (4+2+1=7)"
                }
            };
        }

        public Question GetCurrentQuestion()
        {
            if (currentQuestionIndex < questions.Count)
                return questions[currentQuestionIndex];
            return null;
        }

        public bool CheckAnswer(int selectedAnswerIndex)
        {
            if (currentQuestionIndex < questions.Count)
            {
                bool isCorrect = selectedAnswerIndex == questions[currentQuestionIndex].CorrectAnswerIndex;
                if (isCorrect)
                    score++;
                return isCorrect;
            }
            return false;
        }

        public void NextQuestion()
        {
            if (currentQuestionIndex < questions.Count - 1)
                currentQuestionIndex++;
        }

        public bool HasNextQuestion()
        {
            return currentQuestionIndex < questions.Count - 1;
        }

        public int GetTotalQuestions()
        {
            return questions.Count;
        }

        public int GetCurrentQuestionNumber()
        {
            return currentQuestionIndex + 1;
        }

        public int GetScore()
        {
            return score;
        }

        public double GetScorePercentage()
        {
            return (double)score / questions.Count * 100;
        }

        public void Reset()
        {
            currentQuestionIndex = 0;
            score = 0;
        }
    }
}
