using System;

namespace Calculator
{
    public class Calculator
    {
        private Calculator LeftSide { get; set; }
        private Calculator RightSide { get; set; }
        private char Operator { get; set; }
        private int Value;

        private int ConvertToDigit(string exp)
        {
            string digit = string.Empty;
            int index = 0;

            while (index < exp.Length && exp[index] <= '9' && exp[index] >= '0')
                digit += exp[index++];

            int result = int.Parse(digit);
            return result;
        }

        public void Partition(string exp)
        {
            int operatorIndex = FindOperatorIndex(exp);
            if (operatorIndex != -1)
            {
                Operator = exp[operatorIndex];

                LeftSide = new Calculator();
                LeftSide.Partition(exp.Substring(0, operatorIndex));

                RightSide = new Calculator();
                RightSide.Partition(exp.Substring(operatorIndex + 1));
            }
            else
            {
                Operator = 'v';
                Value = ConvertToDigit(exp);
            }
        }

        private int FindOperatorIndex(string equation)
        {
            for (int i = equation.Length - 1; i >= 0; i--)
            {
                char currentChar = equation[i];

                if (currentChar == '+' || currentChar == '-' || currentChar == '*' || currentChar == '/')
                {
                    return i;
                }
            }

            return -1;
        }

        public int Calculating()
        {
            switch (Operator)
            {
                case 'v':
                    break;
                case '+':
                    Value = LeftSide.Calculating() + RightSide.Calculating();
                    break;
                case '-':
                    Value = LeftSide.Calculating() - RightSide.Calculating();
                    break;
                case '*':
                    Value = LeftSide.Calculating() * RightSide.Calculating();
                    break;
                case '/':
                    if (RightSide.Calculating() == 0)
                    {
                        Console.WriteLine("Error");
                    }
                    Value = LeftSide.Calculating() / RightSide.Calculating();
                    break;

            }

            return Value;
        }

        public int Calculate(string exp)
        {
            exp = exp.Replace(" ", "");
            Calculator root = new Calculator();
            root.Partition(exp);
            return root.Calculating();
        }

    }
}


