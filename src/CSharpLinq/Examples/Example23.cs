using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace CSharpLinq.Examples
{
    public static class Example23
    {
        /// <summary>
        /// Пример демонстрирует работу над валидацией файла xml
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Example #23:");

            Console.WriteLine("Create:");

            //Создаем исходник на основе которого будет создана валидационная схема
            //В жанном оригинале присутствуют и элементы, если в другом файле который будет
            //валидоватся схемой на основе этого документа БУДЕТ ПУСТО в одной из веток
            //(в данном документе в каждой ветке присутствуют элементы)
            //документ провалит валидацию
            XDocument source2 = new XDocument(new XElement("Content", new XElement("Employees",
                                                                                  new XElement("Employee",
                                                                                               new XAttribute("type", "Programmer"),
                                                                                               new XElement("FirstName", "Alex"),
                                                                                               new XElement("LastName", "Erohin")),
                                                                                  new XElement("Employee",
                                                                                               new XAttribute("type", "Editor"),
                                                                                               new XElement("FirstName", "Elena"),
                                                                                               new XElement("LastName", "Volkova"))),
                                                                     new XElement("Cusomers",
                                                                                  new XElement("Customer",
                                                                                                new XElement("Name", "Test")))));

            //Если валидовать схемой на основе этого документа содержимое веток не важно
            //главное начальная структуру веток должна сохранятся!
            XDocument source = new XDocument(new XElement("Content", new XElement("Employees"),
                                                                      new XElement("Cusomers")));

            //сохраняем оригинал
            source.Save("Source.xml");

            //считываем оригинал для создания схемы
            XmlSchemaInference inner = new XmlSchemaInference();
            XmlSchemaSet set = inner.InferSchema(new XmlTextReader("Source.xml"));

            XmlWriter xw = XmlWriter.Create("Source.xsd");
            foreach (XmlSchema schema in set.Schemas())
                schema.Write(xw);

            xw.Close();

            XDocument valid = XDocument.Load("Source.xsd");

            Console.WriteLine("\nSource:");
            Console.WriteLine(source.ToString());
            Console.WriteLine("\nValid:");
            Console.WriteLine(valid.ToString());


            Console.WriteLine("\nValidation:");

            XDocument test1 = new XDocument(new XElement("Content", new XElement("Employees",
                                                                                 new XElement("Employee",
                                                                                              new XAttribute("type", "Programmer"),
                                                                                              new XElement("FirstName", "Alex"),
                                                                                              new XElement("Age", 22),
                                                                                              new XElement("LastName", "Erohin")),
                                                                                 new XElement("Employee",
                                                                                              new XAttribute("type", "Editor"),
                                                                                              new XElement("FirstName", "Elena"),
                                                                                              new XElement("LastName", "Volkova"))),
                                                                    new XElement("Cusomers",
                                                                                 new XElement("Customer",
                                                                                               new XElement("Name", "Test")))));

            XDocument test2 = new XDocument(new XElement("Content", new XElement("Employees"),
                                                                    new XElement("Cusomers")));

            XDocument test3 = new XDocument(new XElement("Content", new XElement("Employees",
                                                                                 new XElement("Employee",
                                                                                              new XAttribute("type", "Programmer"),
                                                                                              new XElement("FirstName", "Alex"),
                                                                                              new XElement("LastName", "Erohin")),
                                                                                 new XElement("Employee",
                                                                                              new XAttribute("type", "Editor"),
                                                                                              new XElement("FirstName", "Elena"),
                                                                                              new XElement("LastName", "Volkova")),
                                                                                 new XElement("Employee",
                                                                                              new XAttribute("type", "Editor"),
                                                                                              new XElement("FirstName", "Elena2"),
                                                                                              new XElement("LastName", "Volkova2"))),
                                                                    new XElement("Cusomers",
                                                                                 new XElement("Customer",
                                                                                               new XElement("Name", "Test")))));

            XDocument test4 = new XDocument(new XElement("Content", new XElement("Employees",
                                                                                 new XElement("Employee",
                                                                                              new XAttribute("type", "Programmer"),
                                                                                              new XElement("FirstName", "Alex"),
                                                                                              new XElement("LastName", "Erohin")),
                                                                                 new XElement("Employee",
                                                                                              new XAttribute("type", "Editor"),
                                                                                              new XElement("FirstName", "Elena"),
                                                                                              new XElement("LastName", "Volkova")),
                                                                                 new XElement("Employee",
                                                                                              new XAttribute("type", "Editor"),
                                                                                              new XElement("FirstName", "Elena2"),
                                                                                              new XElement("LastName", "Volkova2"))),
                                                                    new XElement("Cusomers")));


            //Проверяем на валидость
            try
            {
                test1.Validate(set, null);
                Console.WriteLine("test1 is valid");
            }
            catch (XmlSchemaValidationException e)
            {
                Console.WriteLine($"test1 is'n valid - {e.Message}");
            }

            try
            {
                test2.Validate(set, null);
                Console.WriteLine("test2 is valid");
            }
            catch (XmlSchemaValidationException e)
            {
                Console.WriteLine($"test2 is'n valid - {e.Message}");
            }

            try
            {
                test3.Validate(set, null);
                Console.WriteLine("test3 is valid");
            }
            catch (XmlSchemaValidationException e)
            {
                Console.WriteLine($"test3 is'n valid - {e.Message}");
            }

            try
            {
                test4.Validate(set, null);
                Console.WriteLine("test4 is valid");
            }
            catch (XmlSchemaValidationException e)
            {
                Console.WriteLine($"test4 is'n valid - {e.Message}");
            }
        }
    }
}
