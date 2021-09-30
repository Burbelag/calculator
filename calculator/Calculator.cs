using System;
using System.Collections.Generic;
using System.Linq;

namespace calculator
{
    public class Calculator
    {
        private readonly List<char> _mathChars;
        private readonly List<double> _numbers;
        private double _answer = Double.NaN;

        public Calculator()
        {
            _numbers = new List<double>();
            _mathChars = new List<char>();

            HelloMsg();

            string[] input = InputMethod();
            Calculation(input);
        }

        //reads input and split it if it's float or int
        private string[] InputMethod()
        {
            string[] value = Console.ReadLine()?.Split();
            return value;
        }

        private void Calculation(string[] input)
        {
            //add values into arrays of chars and numbers
            foreach (var str in input)
            {
                if (IsNumCheck(str))
                    _numbers.Add(double.Parse(str));
                else if (IsCharCheck(str))
                    _mathChars.Add(char.Parse(str));
            }

            do
            {
                //check is input correct
                if (_mathChars.Count + 1 != _numbers.Count)
                {
                    throw new Exception("Invalid input");
                }

                //calculation logic
                for (int i = 0; i < _mathChars.Count; i++)
                {
                    if (_mathChars[i].Equals('/') || _mathChars[i].Equals('*'))
                    {
                        switch (_mathChars[i])
                        {
                            case '/':
                                _answer = _numbers[i] / _numbers[i + 1];
                                RemoveInsert(i, _answer);
                                break;
                            case '*':
                                _answer = _numbers[i] * _numbers[i + 1];
                                RemoveInsert(i, _answer);
                                break;
                        }
                    }

                    else if (_mathChars[i].Equals('+') || _mathChars[i].Equals('-'))
                    {
                        if (_mathChars.Contains('*') || _mathChars.Contains('/')) continue;

                        switch (_mathChars[i])
                        {
                            case '+':
                                _answer = _numbers[i] + _numbers[i + 1];
                                RemoveInsert(i, _answer);
                                break;
                            case '-':
                                _answer = _numbers[i] - _numbers[i + 1];
                                RemoveInsert(i, _answer);
                                break;
                        }
                    }
                }
            } while (_numbers.Count() != 1);
        }


        //removing 2 nums and replace it by answer
        //remove 1 mathchar from array
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
            return value.Contains("*") || value.Contains("+") || value.Contains("-") || value.Contains("/");
        }

        public void HelloMsg()
        {
            Console.WriteLine("Write down your example");
        }

        public string GetAnswer()
        {
            Console.WriteLine("Answer : " + _answer);
            return base.ToString();
        }
    }
}