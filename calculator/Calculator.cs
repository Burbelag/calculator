using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace calculator
{
    public class Calculator
    {
        private List<char> _mathChars;
        private List<double> _numbers;

        public Calculator()
        {
            _numbers = new List<double>();
            _mathChars = new List<char>();
            string input = InputMethod();
            Console.WriteLine(Calculation(input));
        }

        private string InputMethod()
        {
            string value= Console.ReadLine();
            return value;
        }

        private string Calculation(string input)
        {
            double answer = Double.NaN;

            string[] numbers = Regex.Split(input, @"\D+"); //как я понимаю, здесь не получается 
                                                                //вставить дробное число и я не понимаю как сделать нужное регулярное выражение
                                                                
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


            do
            {
                for (int i = 0; i < _mathChars.Count; i++)
                {
                    if (_mathChars[i].Equals('/') || _mathChars[i].Equals('*'))
                    {
                        switch (_mathChars[i])
                        {
                            case '/':
                                answer = _numbers[i] / _numbers[i + 1];
                                RemoveInsert(i, answer);
                                break;
                            case '*':
                                answer = _numbers[i] * _numbers[i + 1];
                                RemoveInsert(i, answer);
                                break;
                        }
                    }

                    else if (_mathChars[i].Equals('+') || _mathChars[i].Equals('-'))
                    {
                        if (_mathChars.Contains('*') || _mathChars.Contains('/')) continue;

                        switch (_mathChars[i])
                        {
                            case '+':
                                answer = _numbers[i] + _numbers[i+1];
                                RemoveInsert(i, answer);
                                break;
                            case '-':
                                answer = _numbers[i] - _numbers[i + 1];
                                RemoveInsert(i, answer);
                                break;
                        }
                    }
                }
            } while (_numbers.Count() != 1);


            return answer.ToString();
        }

        private void RemoveInsert(int i, double answer)
        {
            _numbers.RemoveAt(i);
            _numbers.RemoveAt(i);
            _numbers.Insert(i, answer);
            _mathChars.RemoveAt(i);
        }
    }
}