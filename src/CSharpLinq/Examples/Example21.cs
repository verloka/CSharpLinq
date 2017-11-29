using System;
using System.Xml.Linq;

namespace CSharpLinq.Examples
{
    public static class Example21
    {
        /// <summary>
        /// В этом примере показаны работы с аннотациями
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Example #21:");

            XDocument xDocument = new XDocument(new XElement("Employees", new XElement("Employee", new XAttribute("type", "Programmer"),
                                                                                                   new XAttribute("experience", "first-time"),
                                                                                                   new XAttribute("language", "Russian"),
                                                                                                   new XElement("FirstName", "Alex"),
                                                                                                   new XElement("LastName", "Erohin")),
                                                                          new XElement("Employee", new XAttribute("type", "Editor"),
                                                                                                   new XElement("FirstName", "Elena"),
                                                                                                   new XElement("LastName", "Volkova"))));

            Console.WriteLine(xDocument);
            Console.WriteLine("Add anotations:");

            xDocument.Element("Employees").FirstNode.AddAnnotation(new ProgrammerHandler());
            xDocument.Element("Employees").FirstNode.NextNode.AddAnnotation(new EditorHandler());

            Console.WriteLine(xDocument);

            Console.WriteLine("After add anotations:");
            foreach (var item in xDocument.Element("Employees").Elements())
            {
                var anotation = item.Annotation<Handler>();
                if (anotation != null)
                    anotation.Display(item);
            }
        }
    }
}
