using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLinq.Examples
{
    public static class Example4
    {
        /// <summary>
        /// В этом примере создается выборка ТОЛЬКО имен обьектов (проекция)
        /// т.е. от списка с обьктами будет только масив имен обьектов из списка
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Example #4:");

            List<Customer> list = new List<Customer>()
            {
                new Customer() {Name = "Bob"},
                new Customer() {Name = "Jack"},
                new Customer() {Name = "Yasolda"},
                new Customer() {Name = "Carl"},
                new Customer() {Name = "Merigan"},
                new Customer() {Name = "Morigan"},
                new Customer() {Name = "Bob"},
                new Customer() {Name = "Bob"},
                new Customer() {Name = "John"},
                new Customer() {Name = "Johnatan"},
                new Customer() {Name = "Piter"},
                new Customer() {Name = "Pablo"},
                new Customer() {Name = "Jesicca"},
                new Customer() {Name = "Julia"},
                new Customer() {Name = "Jack"},
                new Customer() {Name = "Richard"}
            };

            var selected = from item in list            //Проходимся по списку
                           select item.Name;            //Выбираем только имена, таким образом создается выборка из имен
                                                        //т.е. обычный строковый масив содержащий имена всех обьектов списка

            foreach (var item in selected)
                Console.WriteLine(item);
        }
    }
}
