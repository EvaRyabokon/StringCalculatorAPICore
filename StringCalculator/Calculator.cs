using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public static char[] AvailableOperations = new char[] { '-', '+' };

        private struct NumbersAndOperations
        {
            public List<int> numbers;
            public List<char> operations;

            public NumbersAndOperations(List<int> numbers, List<char> operations)
            {
                this.numbers = numbers;
                this.operations = operations;
            }
        }

        private NumbersAndOperations Parse(string input)
        {
            var numbers = new List<int>();
            var operations = new List<char>();

            numbers = input.Split(AvailableOperations, StringSplitOptions.None).Select(Int32.Parse).ToList();

            foreach (var item in input)
            {
                if (item == '+' || item == '-')
                {
                    operations.Add(item);
                }
            }

            return new NumbersAndOperations(numbers, operations);
        }

        public int CalculateString(string input)
        {
            return Sum(Parse(input));
        }

        private int Sum(NumbersAndOperations splittedStrings)
        {
            var sum = splittedStrings.numbers[0];

            for (int i = 1; i < splittedStrings.numbers.Count; i++)
            {
                if (splittedStrings.operations[i - 1] == '+')
                {
                    sum += splittedStrings.numbers[i];
                }
                if (splittedStrings.operations[i - 1] == '-')
                {
                    sum -= splittedStrings.numbers[i];
                }
            }

            return sum;
        }
    }
}

