using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CSharpLinq.Examples
{
    public static class Example19
    {
        /// <summary>
        /// В этом примере разобрано чтение документа xml, свойства и методы для обхода узлов
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Example #19:");

            List<Customer> customers = new List<Customer>()
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

            List<Phone> phones = new List<Phone>
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

            XDocument document = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
                                               new XDocumentType("DocumentName", null, "DocumentName.dtd", null),
                                               new XProcessingInstruction("DocumentWorker", "arg for worker"),
                                               new XComment("List of customers"),
                                               new XElement("Content", new XElement("Customers", from cs in customers
                                                                                                  select new XElement("Customer", new XElement("Age", cs.Age),
                                                                                                                                  new XElement("Language", cs.Language))),
                                                                       new XComment("List of phones"),
                                                                       new XElement("Phones", from ph in phones
                                                                                              select new XElement("Phone", new XElement("Model", ph.Model),
                                                                                                                           new XElement("Company", ph.Company)))));


            Console.WriteLine("All document:");
            Console.WriteLine(document);

            //Извлекает следующую и придыдущую ноду
            //это могут быть элементы, комментарии, тип документа или инструмент процесинга
            Console.WriteLine("NextNode and PreviousNode:");
            Console.WriteLine(document.FirstNode.NextNode);
            Console.WriteLine(document.FirstNode.NextNode.NextNode.NextNode.PreviousNode);

            //Свойство Document в любой ноде ссылается на весь документ
            //Console.WriteLine(document.Document);

            //Parent возвращает ноду предка
            Console.WriteLine("Parent:");
            Console.WriteLine((document.FirstNode.NextNode.NextNode.NextNode as XElement).FirstNode.Parent);

            Console.WriteLine("Nodes():");

            //Циклом проходим по всем нодам
            foreach (var item in document.Nodes())
                Console.WriteLine(item);

            Console.WriteLine("Nodes().OfType<XElement>():");

            //OfType<XElement> вернет только ноды типа XElement
            foreach (var item in document.Nodes().OfType<XElement>())
                Console.WriteLine(item);

            //element.Attributes();         //Коллекция атрибутов ноды
            //element.Elements();           //Коллекция елементов ноды
            //element.Elements("Name");     //В этом варианте можно передать имя искомого элемента

            Console.WriteLine("Ancestors():");

            //Ancestors выводит предков элемента
            //предок
            //предок предка
            //предок предка предка
            foreach (var item in ((document.Root.FirstNode as XElement).FirstNode as XElement).Ancestors())
                Console.WriteLine(item.Name);

            //AncestorsAndSelf выводит предков элемента и сам элемент
            //сам элемент
            //предок
            //предок предка
            //предок предка предка

            Console.WriteLine("Descendants():");

            //Descendants выводит потомков элемента
            //потомок
            //потомок потомка
            //потомок потомка потомка
            foreach (var item in document.Element("Content").Descendants())
                Console.WriteLine(item.Name);

            //DescendantsAndSelf выводит потомков элемента и сам элемент
            //сам элемент
            //потомок
            //потомок потомка
            //потомок потомка потомка

            Console.WriteLine("NodesAfterSelf():");

            //NodesAfterSelf показывает соседние ноды, на одном уровне которые идут после
            //ElementsAfterSelf показыает только элементы
            foreach (var item in document.Element("Content").Element("Customers").NodesAfterSelf().OfType<XElement>())
                Console.WriteLine(item.Name);

            Console.WriteLine("NodesBeforeSelf():");

            //NodesBeforeSelf возвращает ноды расположение до текущей на этом уровне
            //ElementsBeforeSelf тоже самое только возвращает элементы
            foreach (var item in document.Element("Content").Element("Phones").NodesBeforeSelf().OfType<XElement>())
                Console.WriteLine(item.Name);
        }
    }
}
