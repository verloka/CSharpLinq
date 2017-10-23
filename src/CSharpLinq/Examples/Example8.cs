using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLinq.Examples
{
    public static class Example8
    {
        /// <summary>
        /// В этом примере происходит сортировка по нескольким критериям
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Example #8:");

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

            var selected = from item in list                //проходим по списку
                           orderby item.Name, item.Age      //сортируем по параметрам, параметры указываем через запитую, по порядку главности
                           select item;                     //возвращаем отсортированую колекцию обьектов

            foreach (var item in selected)
                Console.WriteLine(item);
        }
    }
}
