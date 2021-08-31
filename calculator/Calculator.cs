using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class Calculator
    {
        private List<int> _numbers;
        private List<char> _mathChars;

        public Calculator()
        {
            _numbers = new List<int>();
            _mathChars = new List<char>();
            string input = InputMethod();
            // Console.WriteLine("Penis\n\n" + DeleteWhiteSpaces(input));
            Console.WriteLine(Calculation(input));
        }

        private string DeleteWhiteSpaces(string deleteInput)
        {
            var src = deleteInput.ToCharArray();
            int dstIdx = 0;
            for (int i = 0; i < deleteInput.Length; i++)
            {
                var ch = src[i];
                if (!isWhiteSpace(ch))
                    src[dstIdx++] = ch;
            }

            return new string(src, 0, dstIdx);
        }

        private bool isWhiteSpace(char ch)
        {
            switch (ch)
            {
                case '\u0009':
                case '\u000A':
                case '\u000B':
                case '\u000C':
                case '\u000D':
                case '\u0020':
                case '\u0085':
                case '\u00A0':
                case '\u1680':
                case '\u2000':
                case '\u2001':
                case '\u2002':
                case '\u2003':
                case '\u2004':
                case '\u2005':
                case '\u2006':
                case '\u2007':
                case '\u2008':
                case '\u2009':
                case '\u200A':
                case '\u2028':
                case '\u2029':
                case '\u202F':
                case '\u205F':
                case '\u3000':
                    return true;
                default:
                    return false;
            }
        }

        private string InputMethod()
        {
            string value;

            value = Console.ReadLine();
            for (int c = 0; c < value.Length; ++c)
            {
                if (Char.IsLetter(value[c]))
                {
                    /* удалять символ из строки */
                }
            }

            return value;
        }

        private string Calculation(string input)
        {
            double answer = Double.NaN;

            string[] numbers = Regex.Split(input, @"\D+");
            foreach (string value in numbers)
            {
                _numbers.Add(int.Parse(value));
            }

            foreach (var c in input)
            {
                if (c.ToString().Contains("+"))
                    _mathChars.Add(c);
                else if (c.ToString().Contains("-"))
                    _mathChars.Add(c);
                else if (c.ToString().Contains("*"))
                    _mathChars.Add(c);
                else if (c.ToString().Contains("/"))
                    _mathChars.Add(c);
            }

            for (int i = 1; i < _mathChars.Count; i++)
            {
                if (_mathChars[i].Equals('/') || _mathChars[i].Equals('*'))
                {
                    switch (_mathChars[i])
                    {
                        case '/':
                            answer = _mathChars[i - 1] / _mathChars[i + 1];
                            break;
                        case '*':
                            answer = _mathChars[i - 1] * _mathChars[i + 1];
                            break;
                    }

                    if (_mathChars[i].Equals('+') || _mathChars[i].Equals('-'))
                    {
                        switch (_mathChars[i])
                        {
                            case '-':
                                answer = _mathChars[i - 1] / _mathChars[i + 1];
                                break;
                            case '+':
                                answer = _mathChars[i - 1] * _mathChars[i + 1];
                                break;
                        }
                    }
                }

                Console.Read();
                return answer.ToString();
            }
        }
    }
}