using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLinq.Examples
{
    public static class Example12
    {
        /// <summary>
        /// В данном примере продемонстрировано групироание обьектов из списка
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Example #12:");

            List<Phone> list = new List<Phone>
            {
                new Phone {Model="Lumia 430", Company="Microsoft" },
                new Phone {Model="Mi 5", Company="Xiaomi" },
                new Phone {Model="LG G 3", Company="LG" },
                new Phone {Model="iPhone 5", Company="Apple" },
                new Phone {Model="Lumia 930", Company="Microsoft" },
                new Phone {Model="iPhone 6", Company="Apple" },
                new Phone {Model="Lumia 630", Company="Microsoft" },
                new Phone {Model="LG G 4", Company="LG" }
            };

            var groups = from item in list                  //Проходим по списку
                         group item by item.Company;        //Групируем телефоны но свойству Company
                                                            //group что by по какому свойству
                                                            //select не надо!

            Console.WriteLine("#1:");

            foreach (var item in groups)
            {
                Console.WriteLine($"{item.Key}:");
                foreach (var phone in item)
                    Console.WriteLine($"\t{phone.Model}");
            }

            Console.WriteLine("#2:");

            var groups2 = from item in list                                     //проходим по списку
                          group item by item.Company                            //групируем
                          into g                                                //создаем переменную в которой храним группу
                          select new { Company = g.Key, Count = g.Count() };    //создаем новый обьект с названием компании и количеством моделей
                                                                                //into немного похож на let, только он переопределяет переменную если та 
                                                                                //уже была сосздана ранее оператором into

            foreach (var item in groups2)
                Console.WriteLine($"{item.Company}: {item.Count}");

            var groups3 = from item in list                         //проходим по списку
                          group item by item.Company into g         //записываем группу в перменную
                          select new                                //создаем новый обьект
                          {                                         //с названием компании
                              Company = g.Key,                      //с количеством моделей в групе
                              Count = g.Count(),                    //с самимы телефонами
                              Phones = from item in g
                                       select item
                          };


            Console.WriteLine("#3:");

            foreach (var item in groups3)
            {
                Console.WriteLine($"{item.Company}: {item.Count}. Phones:");
                foreach (var phone in item.Phones)
                    Console.WriteLine($"\t{phone.Model}");
            }
        }
    }
}
