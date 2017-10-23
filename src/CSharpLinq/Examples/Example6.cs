using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLinq.Examples
{
    public static class Example6
    {
        /// <summary>
        /// В этом примере используется операотр LET для создания промежуточных переменных
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Example #6:");

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

            var selected = from item in list                    //проходим по списку
                           let name = $"Mr. {item.Name}"        //создаем перменнуи записываем в нее значения вида "Mr. " + item.Name
                           select new Customer()                //создаем новый обьект customer и присваиваем ему новое имя name
                           {
                               Name = name,
                               Age = item.Age,
                               Language = item.Language
                           };

            foreach (var item in selected)
                Console.WriteLine(item);
        }
    }
}
