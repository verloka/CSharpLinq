using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace CSharpLinq.Examples
{
    public static class Example18
    {
        /// <summary>
        /// В этом примере показано наглядно введение в Linq to Xml (создание, сохранение, загрузка)
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Example #18:");

            //Простой элемент
            XElement emploee1 = new XElement("emploee", new XElement("FirstName", "Sergey"),
                                                       new XElement("SecondName", "Petrov"));

            Console.WriteLine("#1:");
            Console.WriteLine(emploee1);

            //Элемент с дочерними элементами котрые имеют какието атрибуты
            XElement emploees = new XElement("Emploees", new XElement("Emploee", new XAttribute("type", "Programmer"),
                                                                                 new XElement("FirstName", "Petro"),
                                                                                 new XElement("SecondName", "Semenov")),
                                                         new XElement("Emploee", new XAttribute("type", "Manager"),
                                                                                 new XElement("FirstName", "Igor"),
                                                                                 new XElement("SecondName", "Petrov")));

            Console.WriteLine("#2:");
            Console.WriteLine(emploees);

            //Элемнет с пространством имен => emploee xmlns="Verloka"

            /*
             * Этот код эвивалентен коду ниже, не обязательно создавать элемент XNamespace
             * 
             * XElement emploee2 = new XElement("{Verloka}" + "emploee", new XElement("FirstName", "Ivan"),
             *                                                 new XElement("SecondName", "Sidorov"));
             */


            XNamespace nspc = "Verloka";
            XElement emploee2 = new XElement(nspc + "emploee", new XElement("FirstName", "Ivan"),
                                                               new XElement("SecondName", "Sidorov"));

            Console.WriteLine("#3:");
            Console.WriteLine(emploee2);

            //Указания пространства имен с префиксом
            XElement emploee3 = new XElement("emploee", new XAttribute(XNamespace.Xmlns + "prefix", nspc), new XElement("FirstName", "Irina"),
                                                                                                           new XElement("SecondName", "Petrenko"));

            Console.WriteLine("#4:");
            Console.WriteLine(emploee3);

            List<Customer> cust = new List<Customer>()
            {
                new Customer() { Name = "Bob", Age = 33, Language = "EN" },
                new Customer() { Name = "Jack", Age = 23, Language = "EN" },
                new Customer() { Name = "Maria", Age = 23, Language = "EN" },
                new Customer() { Name = "John", Age = 76, Language = "UA" },
                new Customer() { Name = "Bill", Age = 21, Language = "RU" }
            };

            //Генерация дерева использую Linq запрос
            XElement customner = new XElement("Customers",
                                             from item in cust
                                             select new XElement("Customer", new XElement("Name", item.Name),
                                                                             new XElement("Age", item.Age),
                                                                             new XAttribute("Language",item.Language)));


            Console.WriteLine("#5:");
            Console.WriteLine(customner);

            //Создает пустой документ
            XDocument doc = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),                              //декларация
                                          new XDocumentType("DocumentName", null, "DocumentName.dtd", null),    //тип документа
                                          new XProcessingInstruction("DocumentWorker", "arg for worker"),       //инструмент оброботки
                                          new XElement("Contents"));                                            //контент

            Console.WriteLine("#6:");
            Console.WriteLine(doc);

            //Создаем документ для сохранения
            XDocument docForSave = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),                              //декларация
                                                 new XDocumentType("DocumentName", null, "DocumentName.dtd", null),    //тип документа
                                                 new XProcessingInstruction("DocumentWorker", "arg for worker"),       //инструмент оброботки
                                                 customner);                                                           //контент

            //Сохраняме
            docForSave.Save("file.xml", SaveOptions.None);
            Console.WriteLine("Document was saved in application's folder.");

            Console.WriteLine("Document was loaded from file.xml:");

            //Загрузка xml с файла
            Console.WriteLine(XDocument.Load("file.xml"));

            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><Employees><Employee type=\"Programmer\" language=\"Russian\"><FirstName>Alex</FirstName><LastName>Erohin</LastName></Employee></Employees>";

            Console.WriteLine("Parsing from string:");

            //Парсим xml из строки
            Console.WriteLine(XDocument.Parse(xml));
        }
    }
}
