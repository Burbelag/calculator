using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            string[] input = InputMethod();
            Console.WriteLine(Calculation(input));
        }

        private string[] InputMethod()
        {
            string[] value = Console.ReadLine()?.Split();
            return value;
        }

        private string Calculation(string[] input)
        {
            foreach (var str in input)
            {
                if (IsNumCheck(str))
                    _numbers.Add(double.Parse(str));

                if (IsCharCheck(str))
                    _mathChars.Add(char.Parse(str));
            }

            double answer = Double.NaN;
            do
            {
                if (_mathChars.Count + 1 != _numbers.Count)
                {
                    Console.WriteLine("Error v uslovii");
                    break;
                }

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
                                answer = _numbers[i] + _numbers[i + 1];
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

        private bool IsNumCheck(string value)
        {
            int intValue;
            float floatValue;
            return int.TryParse(value, out intValue) ||
                   float.TryParse(value, out floatValue);
        }

        private bool IsCharCheck(string value)
        {
            //БАГ ГДЕТА ЗДЕСЬ
            //РАБОТАЕТ С 10+ ЧИСЛАМИ
            // НЕ РАБОТАЕТ С 0-9
            //Я ЕБАЛИ МЕНЯ СОСАЛИ
            
            foreach (var charValue in value)
            {
                char temp = Convert.ToChar(value);
                if (char.IsSymbol('-') || char.IsSymbol('+') ||
                    char.IsSymbol('*') || char.IsSymbol('/'))
                    return char.TryParse();
            }

            return false;
        }
    }
}