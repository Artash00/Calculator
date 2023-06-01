using System;

namespace Calculator
{
    public class Calculator
    {
        public int Calculate(string exp)
        {
            exp = exp.Replace(" ", "");
            Tree<int> root = new Tree<int>
            {
                _root = new TreeNode<int>()
            };
            root._root = root.Partition(exp, root._root);
            return root.Calculating(root._root);
        }
    }

    public class TreeNode<T>
    {
        public TreeNode<T> _leftSide { get; set; }
        public TreeNode<T> _rightSide { get; set; }
        public char _operator { get; set; }
        public T _value;
    }



    public class Tree<T>
    {
        public TreeNode<T> _root;
        public TreeNode<T> Partition(string exp, TreeNode<T> node)
        {
            int operatorIndex;
            operatorIndex = FindSumSubIndex(exp);

            if (operatorIndex == -1)
                operatorIndex = FindMulDivIndex(exp);

            if (operatorIndex != -1)
            {
                node._operator = exp[operatorIndex];

                node._leftSide = new TreeNode<T>();
                Partition(exp.Substring(0, operatorIndex), node._leftSide);

                node._rightSide = new TreeNode<T>();
                Partition(exp.Substring(operatorIndex + 1), node._rightSide);
            }
            else
            {
                node._operator = 'v';
                node._value = ConvertToDigit(exp);
            }

            return node;
        }

        private T ConvertToDigit(string exp)
        {
            string digit = string.Empty;
            int index = 0;

            while (index < exp.Length && exp[index] <= '9' && exp[index] >= '0')
                digit += exp[index++];

            T result = (T)Convert.ChangeType(digit, typeof(T));
            return result;
        }

        private int FindSumSubIndex(string equation)
        {
            for (int i = equation.Length - 1; i >= 0; i--)
            {
                char currentChar = equation[i];

                if (currentChar == '+' || currentChar == '-')
                {
                    return i;
                }
            }

            return -1;
        }

        private int FindMulDivIndex(string equation)
        {
            for (int i = equation.Length - 1; i >= 0; i--)
            {
                char currentChar = equation[i];

                if (currentChar == '*' || currentChar == '/')
                {
                    return i;
                }
            }

            return -1;
        }

        public T Calculating(TreeNode<T> node)
        {
            switch (node._operator)
            {
                case 'v':
                    break;
                case '+':
                    node._value = Add(Calculating(node._leftSide), Calculating(node._rightSide));
                    break;
                case '-':
                    node._value = Subtract(Calculating(node._leftSide), Calculating(node._rightSide));
                    break;
                case '*':
                    node._value = Multiply(Calculating(node._leftSide), Calculating(node._rightSide));
                    break;
                case '/':
                    if (Convert.ToDouble(node._rightSide._value) == 0)
                    {
                        Console.WriteLine("Error");
                    }
                    node._value = Divide(Calculating(node._leftSide), Calculating(node._rightSide));
                    break;

            }

            return node._value;
        }

        private T Add(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;
            return x + y;
        }

        private T Subtract(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;
            return x - y;
        }

        private T Multiply(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;
            return x * y;
        }

        private T Divide(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;
            return x / y;
        }

    }
}
