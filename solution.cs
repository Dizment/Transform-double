using System;
using System.Globalization;
using System.Text;

namespace TransformToWords
{
    public class Transformer
    {
        public string TransformToWords(double number)
        {
            string[] words = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Point", "Minus", "E", "Plus" };
            char[] digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '-', 'E', '+' };
            StringBuilder stroka = new StringBuilder();
            stroka.Append(number.ToString(CultureInfo.GetCultureInfo("en-US")));
            StringBuilder newstr = new StringBuilder();
            int count = number.ToString(CultureInfo.GetCultureInfo("en-US")).Length;

            if (number is double.Epsilon)
            {
                return "Double Epsilon";
            }

            if (number is double.PositiveInfinity)
            {
                return "Positive Infinity";
            }

            if (number is double.NegativeInfinity)
            {
                return "Negative Infinity";
            }

            if (number is double.NaN)
            {
                return "NaN";
            }
            
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    if (stroka[i] == digits[j] && i == 0)
                    {
                        if (count == 1)
                        {
                            newstr.Append(words[j]);
                            break;
                        }

                        newstr.Append(words[j] + " ");
                        break;
                    }

                    if (stroka[i] == digits[j] && i == count - 1)
                    {
                        newstr.Append(words[j].ToLower(CultureInfo.GetCultureInfo("en-US")));
                        break;
                    }

                    if (stroka[i] == digits[j])
                    {
                        if (stroka[i] != 'E')
                        {
                            newstr.Append(words[j].ToLower(CultureInfo.GetCultureInfo("en-US")) + " ");
                            break;
                        }

                        newstr.Append(words[j].ToUpper(CultureInfo.GetCultureInfo("en-US")) + " ");
                        break;
                    }
                }
            }

            return newstr.ToString();
        }
        
        static void Main(string[] args)
        {
            double digit = double.MinValue;
            
            Console.Write(TransformToWords(digit));
        }
    }
}
