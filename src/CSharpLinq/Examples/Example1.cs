using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLinq.Examples
{
    public static class Example1
    {
        /// <summary>
        /// В этом примере выбираем все города, которые начинаются на букву М и сортируем их по возрастанию
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Example #1:");

            List<string> list = new List<string>()
            {
                "Харьков",
                "Киев",
                "Мариуполь",
                "Минск",
                "Москва",
                "Львов",
                "Симферополь",
                "Донецк",
                "Днепр",
                "Кропивницкий",
                "Токио",
                "Пхеньян"
            };

            var selected = from item in list                        //проходим по каждому элементу списка и присваивает им имя item и передает его далее
                           where item.ToUpper().StartsWith("М")     //происходит фильтрация, если item соответствует фильтру передает его дальше
                           orderby item                             //Сортируем по возрастанию переданые ранее item'ы
                           select item;                             //перадет item'ы в переменную selected

            foreach (var item in selected)
                Console.WriteLine(item);
        }
    }
}
