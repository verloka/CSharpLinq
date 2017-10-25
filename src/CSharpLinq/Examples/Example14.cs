using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLinq.Examples
{
    public static class Example14
    {
        /// <summary>
        /// В этом примере показана работы методов All и Any
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Example #14:");

            List<Customer> customers = new List<Customer>()
            {
                new Customer() { Name = "Bob", Age = 33 },
                new Customer() { Name = "Jack", Age = 23 },
                new Customer() { Name = "Maria", Age = 23 },
                new Customer() { Name = "John", Age = 76 },
                new Customer() { Name = "Bill", Age = 21 }
            };

            var old = customers.All(c => c.Age > 20);                   //Метод All проверяет соответствуют ли все елементы последовательности критерию
            var name = customers.Any(c => c.Name.StartsWith("T"));      //Метод Any проверяет соответствует ли критерию хотябы один элемент 

            Console.WriteLine($"In collection all cusomters older then 20: {old}");
            Console.WriteLine($"In collection any cusomter have name that starts with T: {name}");
        }
    }
}
