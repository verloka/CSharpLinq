using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }

            Console.Read();
        }
    }
}
