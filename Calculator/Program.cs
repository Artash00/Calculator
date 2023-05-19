using System;

namespace Calculator
{       
    class Program
    {  
        static void Main(string[] args)
        {
            string exp;
            exp = Console.ReadLine();
            
            Calculator calculator = new Calculator();
            Console.WriteLine(calculator.Calculate(exp));
        }
    }
}
