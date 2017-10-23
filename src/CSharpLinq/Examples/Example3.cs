using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLinq.Examples
{
    public static class Example3
    {
        /// <summary>
        /// В этом примере из колекции customer'ов сложным фильтром выбираются старше 20 лет и говорящие на Ukranian
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Example #3:");

            List<Customer> list = new List<Customer>()
            {
                new Customer() {Age = 12, Language = "Russian"},
                new Customer() {Age = 23, Language = "English"},
                new Customer() {Age = 24, Language = "Russian"},
                new Customer() {Age = 51, Language = "English"},
                new Customer() {Age = 11, Language = "Russian"},
                new Customer() {Age = 55, Language = "Russian"},
                new Customer() {Age = 64, Language = "English"},
                new Customer() {Age = 23, Language = "English"},
                new Customer() {Age = 32, Language = "English"},
                new Customer() {Age = 43, Language = "Russian"},
                new Customer() {Age = 41, Language = "English"},
                new Customer() {Age = 12, Language = "Ukranian"},
                new Customer() {Age = 21, Language = "Ukranian"},
                new Customer() {Age = 66, Language = "Ukranian"}
            };

            var selected = from item in list                    //проходим по list
                           where item.Age > 20                  //сложным фильтром определяем customer'a старше 20 лет и говорящим на Ukranian
                           where item.Language == "Ukranian"
                           select item;                         //возвращаем колецию customer'ов

            foreach (var item in selected)
                Console.WriteLine(item);
        }
    }
}
