using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace EDU.Models
{
    public class Exercise
    {
        public int XCount;
        public double X1, X2;
        public int A, B, C;
        public int Score, QuestionNumber;
        public string QuadraticEquation;
        private Random r;
        private NumberStyles style;
        private CultureInfo culture;

        public Exercise()
        {
            r = new Random();
            Score = 0;
            QuestionNumber = 0;
            RandomValues();
            QuadraticEquation = Builder(A, B, C);
            style = NumberStyles.Any;
            culture = CultureInfo.InvariantCulture;
        }
        public void IncScore()
        {
            Score++;
        }
        public void IncQuestionNumber()
        {
            QuestionNumber++;
        }
        private int RandomValues()
        {
            return r.Next(-10, 10);
        }
        public void RandomExercise()
        {
            A = RandomValues();
            B = RandomValues();
            C = RandomValues();
            X1 = Double.NaN;
            X2 = Double.NaN;
            GetRightAnswer();
            QuadraticEquation = Builder(A, B, C);
        }
        private void GetRightAnswer()
        {
            if (A == 0 && B == 0 && C == 0)
            {
                XCount = -1;
            }
            else if (A == 0 && B == 0)
            {
                XCount = 0;
            }
            else if (A == 0)
            {
                XCount = 1;
                X1 = -C * 1.0 / B;
                X1 = Math.Round(X1, 3);
            }
            else
            {
                int D = B * B - 4 * A * C;
                if (D < 0)
                {
                    XCount = 0;
                }
                else if (D == 0)
                {
                    XCount = 1;
                    X1 = -B / (2 * A);
                    X1 = Math.Round(X1, 3);
                }
                else
                {
                    XCount = 2;
                    X1 = (-B - Math.Sqrt(D)) / (2 * A);
                    X1 = Math.Round(X1, 3);
                    X2 = (-B + Math.Sqrt(D)) / (2 * A);
                    X2 = Math.Round(X2, 3);
                }
            }
        }
        public bool CompareTo(string studentAnswer)
        {
            string[] answers = studentAnswer.Split(' ');
            double a1 = 0, a2 = 0, a = 0;
            bool isCorrect1 = false, isCorrect2 = false, isCorrect = false;
            int answersLength = answers.Length;
            if (answersLength == 2)
            {
                answers[0] = answers[0].Replace(',', '.');
                answers[1] = answers[1].Replace(',', '.');
                isCorrect1 = double.TryParse(answers[0], style, culture, out a1);
                isCorrect2 = double.TryParse(answers[1], style, culture, out a2);
                a1 = Math.Round(a1, 3);
                a2 = Math.Round(a2, 3);
            }
            else if (answersLength == 1)
            {
                studentAnswer = studentAnswer.Replace(',', '.');
                isCorrect = double.TryParse(studentAnswer, style, culture, out a);
                a = Math.Round(a, 3);
            }

            if (studentAnswer.Trim().Equals("NOROOTS") && XCount == 0)
            {
                return true;
            }
            if (studentAnswer.Trim().Equals("INFINITY") && XCount == -1)
            {
                return true;
            }
            if (answersLength == 1 && XCount == 1 && isCorrect)
            {
                if (a == X1 || a == X2)
                {
                    return true;
                }
            }
            if (answersLength == 2 && XCount == 2 && isCorrect1 && isCorrect2)
            {
                if (a1 == X1 && a2 == X2 || a2 == X1 && a1 == X2)
                {
                    return true;
                }
            }
            return false;
        }

        private static string Builder(int a, int b, int c)
        {
            string s = "";
            if (a == 0 && b == 0 && c == 0)
            {
                s += 0;
            }
            s += GetA(a, b, c);
            s += GetB(a, b, c);
            s += GetC(a, b, c);
            s += " = 0";

            return s;
        }
        private static string GetA(int a, int b, int c)
        {
            return First(a, "x<sup>2</sup>");
        }
        private static string GetB(int a, int b, int c)
        {
            string s = "";
            if (a == 0)
            {
                return First(b, "x");
            }
            if (b != 0)
            {
                if (b < 0)
                {
                    s += " - ";
                    b = -b;
                }
                else
                {
                    s += " + ";
                }
                if (b != 1)
                {
                    s += b;
                }
                s += "x";
            }
            return s;
        }
        private static string GetC(int a, int b, int c)
        {
            if (a == 0 && b == 0)
            {
                return First(c, "");
            }
            string s = "";
            if (c != 0)
            {
                if (c < 0)
                {
                    s += " - ";
                    c = -c;
                }
                else
                {
                    s += " + ";
                }
                s += c;
            }
            return s;
        }
        private static string First(int d, string x)
        {
            string s = "";
            if (d != 0)
            {
                if (d < 0)
                {
                    s += "-";
                    d = -d;
                }
                if (d != 1)
                {
                    s += d;
                }
                if (d == 1 && x == "")
                {
                    s += 1;
                }
                s += x;
            }
            return s;
        }
    }
    
}