using System;
using System.Linq;
using System.Xml.Linq;

namespace CSharpLinq.Examples
{
    public static class Example20
    {
        public static void Show()
        {
            Console.WriteLine("Example #20:");

            XElement xml = new XElement("Customers", new XElement("Customer", new XAttribute("Age", 29),
                                                                              new XAttribute("Lang", "En"),
                                                                              new XElement("FirstName", "Vadim"),
                                                                              new XElement("SecondName", "Petrov")),
                                                     new XElement("Customer", new XAttribute("Age", 19),
                                                                              new XAttribute("Lang", "Ru"),
                                                                              new XElement("FirstName", "Ivan"),
                                                                              new XElement("SecondName", "Sidorov")),
                                                     new XElement("Customer", new XAttribute("Age", 49),
                                                                              new XAttribute("Lang", "Ua"),
                                                                              new XElement("FirstName", "Petr"),
                                                                              new XElement("SecondName", "Ivanov")),
                                                     new XElement("Customer", new XAttribute("Age", 15),
                                                                              new XAttribute("Lang", "Ua"),
                                                                              new XElement("FirstName", "Maria"),
                                                                              new XElement("SecondName", "Petrenko")),
                                                     new XElement("Customer", new XAttribute("Age", 17),
                                                                              new XAttribute("Lang", "En"),
                                                                              new XElement("FirstName", "Jack"),
                                                                              new XElement("SecondName", "Sparow")));

            Console.WriteLine(xml);

            //Добавляет дочерние элементы, в конец списка
            //AddFirst тоже что и просто Add но добавляет в начало списка
            xml.Add(new XElement("Customer", new XAttribute("Age", 22),
                                             new XAttribute("Lang", "En"),
                                             new XElement("FirstName", "Jhon"),
                                             new XElement("SecondName", "Smith")));

            xml.Element("Customer").Add(new XElement("PhoneNumber", 989238983234));

            //AddBeforeSelf добавляет элементы, на тот же уровень, перед текущем
            //AddAfterSelf тоже что и предыдущее но добавляет после себя
            xml.LastNode.AddBeforeSelf(new XElement("Customer", new XAttribute("Age", 18),
                                                                new XAttribute("Lang", "Ua"),
                                                                new XElement("FirstName", "Anna"),
                                                                new XElement("SecondName", "Shults")));

            Console.WriteLine("Adding:");
            Console.WriteLine(xml);

            //Удаляет текущую ноду
            xml.FirstNode.Remove();

            var enumerable = from item in xml.Descendants().OfType<XElement>()
                             where item.Name == "Customer"
                             where (int)item.Attribute("Age") < 18
                             select item;

            //Remove можно применить к колекции узлов
            //в данном случае берутся узлы с атрибутом Age меньше 18
            //и удаляются
            enumerable.Remove();

            Console.WriteLine("Removing:");
            Console.WriteLine(xml);

            //Изменяя свойство Value в елементах мы изменяем их значение
            (xml.FirstNode as XElement).Element("FirstName").Value = "Sergjio";
            (xml.FirstNode as XElement).Element("SecondName").Value = "Poliu";
            (xml.FirstNode as XElement).Attribute("Age").Value = "77";

            Console.WriteLine("Updating:");
            Console.WriteLine(xml);

            //ReplaceAll заменяет все содержимое элемента, ноды и атрибуты
            //ReplaceAttribute заменяет только атрибуты
            //ReplaceNodes заменяет только ноды
            (xml.LastNode as XElement).ReplaceAll(new XAttribute("Age", 48),
                                                  new XAttribute("Lang", "Ru"),
                                                  new XElement("FirstName", "Olga"),
                                                  new XElement("SecondName", "Smihu"));

            Console.WriteLine("Replacing:");
            Console.WriteLine(xml);

            //SetElementValue - универсальный метод. Работает на дочерних элементов текущего
            //1. Если елемент по указаному имени находится то метод заменяет его содержимое на указаное
            //2. Если указаного элемента не нашлось то добавляется тот, что указан в методе
            //3. Если передать null то найденый элемент удалится

            (xml.FirstNode as XElement).SetElementValue("FirstName", "Semen");      //изменяет
            (xml.FirstNode as XElement).SetElementValue("PhoneNumber", 123456);     //добавляет
            (xml.FirstNode as XElement).SetElementValue("SecondName", null);        //удаляет
            (xml.FirstNode as XElement).SetElementValue("SecondName2", null);       //ничего не произойдет, т.к. такого 
                                                                                    //элемента нет, значит удалятьнечего
            Console.WriteLine("SetElementValue():");
            Console.WriteLine(xml);
        }
    }
}
