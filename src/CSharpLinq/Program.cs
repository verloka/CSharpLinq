using System;

namespace CSharpLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Title = "LINQ";

            Console.Write("Enter number of example: ");
            int.TryParse(Console.ReadLine(), out int num);

            switch (num)
            {
                case 0:
                default:
                    Console.WriteLine("Wrong number");
                    break;
                case 1:
                    Examples.Example1.Show();
                    break;
                case 2:
                    Examples.Example2.Show();
                    break;
                case 3:
                    Examples.Example3.Show();
                    break;
                case 4:
                    Examples.Example4.Show();
                    break;
                case 5:
                    Examples.Example5.Show();
                    break;
                case 6:
                    Examples.Example6.Show();
                    break;
                case 7:
                    Examples.Example7.Show();
                    break;
                case 8:
                    Examples.Example8.Show();
                    break;
                case 9:
                    Examples.Example9.Show();
                    break;
                case 10:
                    Examples.Example10.Show();
                    break;
                case 11:
                    Examples.Example11.Show();
                    break;
                case 12:
                    Examples.Example12.Show();
                    break;
                case 13:
                    Examples.Example13.Show();
                    break;
                case 14:
                    Examples.Example14.Show();
                    break;
                case 15:
                    Examples.Example15.Show();
                    break;
                case 16:
                    Examples.Example16.Show();
                    break;
                case 17:
                    Examples.Example17.Show();
                    break;
                case 18:
                    Examples.Example18.Show();
                    break;
                case 19:
                    Examples.Example19.Show();
                    break;
                case 20:
                    Examples.Example20.Show();
                    break;
                case 21:
                    Examples.Example21.Show();
                    break;
                case 22:
                    Examples.Example22.Show();
                    break;
            }

            Console.Read();
        }
    }
}
