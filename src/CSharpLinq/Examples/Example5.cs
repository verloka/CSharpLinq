using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLinq.Examples
{
    public static class Example5
    {
        /// <summary>
        /// В этом примере оператор SELECT создает анонимный обьект (можно не анонимный) на основе обькта cusomter
        /// с добавлением своих, отличных полей
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Example #5:");

            List<Customer> list = new List<Customer>()
            {
                new Customer() {Name = "Bob", Age = 44},
                new Customer() {Name = "Jack", Age = 12},
                new Customer() {Name = "Yasolda", Age = 21},
                new Customer() {Name = "Carl", Age = 22},
                new Customer() {Name = "Merigan", Age = 64},
                new Customer() {Name = "Morigan", Age = 44},
                new Customer() {Name = "Bob", Age = 12},
                new Customer() {Name = "Bob", Age = 32},
                new Customer() {Name = "John", Age = 21},
                new Customer() {Name = "Johnatan", Age = 11},
                new Customer() {Name = "Piter", Age = 15},
                new Customer() {Name = "Pablo", Age = 19},
                new Customer() {Name = "Jesicca", Age = 92},
                new Customer() {Name = "Julia", Age = 104},
                new Customer() {Name = "Jack", Age = 15},
                new Customer() {Name = "Richard", Age = 28}
            };

            var selected = from item in list                                    //проходим по списку
                           select new                                           //создаем анонимный обьект на основе customer 
                           {                                                    //с полями Name и YearOfBirth
                               Name = item.Name,
                               YearOfBirth = DateTime.Now.Year - item.Age
                           };

            foreach (var item in selected)
                Console.WriteLine($"Name - {item.Name}, Year of birth - {item.YearOfBirth}");
        }
    }
}
