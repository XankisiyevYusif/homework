using System;

namespace c__task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static int Add(int num1, int num2)
            {
                return num1 + num2;
            }

            static int Multiply(int num1, int num2) 
            {
                return num1 * num2;
            }

            static int Divide(int num1, int num2)
            {
                return num1 / num2;
            }

            static int Substrance(int num1, int num2)
            {
                return num1 - num2;
            }

            Console.WriteLine("Caculator");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Multiply");
            Console.WriteLine("3. Divide");
            Console.WriteLine("4. Substrance");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter first number: ");
            int number1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int number2 = Convert.ToInt32(Console.ReadLine());


            switch (choice)
            {
                case 1:
                    Console.WriteLine(Add(number1, number2));
                    break;
                case 2:
                    Console.WriteLine(Multiply(number1, number2));
                    break;
                case 3:
                    Console.WriteLine(Divide(number1, number2));
                    break;
                case 4:
                    Console.WriteLine(Substrance(number1, number2));
                    break;
            }
        }
    }
}
