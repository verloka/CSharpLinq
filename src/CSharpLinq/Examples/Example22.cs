using System;
using System.Linq;
using System.Xml.Linq;

namespace CSharpLinq.Examples
{
    public static class Example22
    {
        /// <summary>
        /// В этом примере отображена работа методов Descendants и Ancestors, а также пример сложнго запроса
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Example #21:");

            XDocument xDoc = new XDocument(new XElement("Employees", new XElement("Employee", new XAttribute("type", "Programmer"),
                                                                                              new XElement("FirstName", "Alex"),
                                                                                              new XElement("LastName", "Erohin")),
                                                                     new XElement("Employee", new XAttribute("type", "Editor"),
                                                                                              new XElement("FirstName", "Elena"),
                                                                                              new XElement("LastName", "Volkova"))));

            //Descendants возвращает всех потомков
            //Ancestors возвращает всех предков
            //если в аргументах указать имя то будут возваржены только 
            //равные этому времени
            foreach (var item in xDoc.Descendants("Employee"))
                Console.WriteLine($"Name - {item.Name.ToString()}, Value - {item.Value}");

            #region xml
            XDocument users = XDocument.Parse(@"<users> <user_tuple> <userid>U01</userid> <name>TomJones</name> <rating>B</rating> </user_tuple> <user_tuple> <userid>U02</userid> <name>MaryDoe</name> <rating>A</rating> </user_tuple> <user_tuple> <userid>U03</userid> <name>DeeLinquent</name> <rating>D</rating> </user_tuple> <user_tuple> <userid>U04</userid> <name>RogerSmith</name> <rating>C</rating> </user_tuple> <user_tuple> <userid>U05</userid> <name>JackSprat</name> <rating>B</rating> </user_tuple> <user_tuple> <userid>U06</userid> <name>RipVanWinkle</name> <rating>B</rating> </user_tuple> </users>");
            XDocument items = XDocument.Parse(@"<items><item_tuple><itemno>1001</itemno><description>RedBicycle</description><offered_by>U01</offered_by><start_date>1999-01-05</start_date><end_date>1999-01-20</end_date><reserve_price>40</reserve_price></item_tuple><item_tuple><itemno>1002</itemno><description>Motorcycle</description><offered_by>U02</offered_by><start_date>1999-02-11</start_date><end_date>1999-03-15</end_date><reserve_price>500</reserve_price></item_tuple><item_tuple><itemno>1003</itemno><description>OldBicycle</description><offered_by>U02</offered_by><start_date>1999-01-10</start_date><end_date>1999-02-20</end_date><reserve_price>25</reserve_price></item_tuple><item_tuple><itemno>1004</itemno><description>Tricycle</description><offered_by>U01</offered_by><start_date>1999-02-25</start_date><end_date>1999-03-08</end_date><reserve_price>15</reserve_price></item_tuple><item_tuple><itemno>1005</itemno><description>TennisRacket</description><offered_by>U03</offered_by><start_date>1999-03-19</start_date><end_date>1999-04-30</end_date><reserve_price>20</reserve_price></item_tuple><item_tuple><itemno>1006</itemno><description>Helicopter</description><offered_by>U03</offered_by><start_date>1999-05-05</start_date><end_date>1999-05-25</end_date><reserve_price>50000</reserve_price></item_tuple><item_tuple><itemno>1007</itemno><description>RacingBicycle</description><offered_by>U04</offered_by><start_date>1999-01-20</start_date><end_date>1999-02-20</end_date><reserve_price>200</reserve_price></item_tuple><item_tuple><itemno>1008</itemno><description>BrokenBicycle</description><offered_by>U01</offered_by><start_date>1999-02-05</start_date><end_date>1999-03-06</end_date><reserve_price>25</reserve_price></item_tuple></items>");
            XDocument bids = XDocument.Parse(@"<bids><bid_tuple><userid>U02</userid><itemno>1001</itemno><bid>35</bid><bid_date>1999-01-07</bid_date></bid_tuple><bid_tuple><userid>U04</userid><itemno>1001</itemno><bid>40</bid><bid_date>1999-01-08</bid_date></bid_tuple><bid_tuple><userid>U02</userid><itemno>1001</itemno><bid>45</bid><bid_date>1999-01-11</bid_date></bid_tuple><bid_tuple><userid>U04</userid><itemno>1001</itemno><bid>50</bid><bid_date>1999-01-13</bid_date></bid_tuple><bid_tuple><userid>U02</userid><itemno>1001</itemno><bid>55</bid><bid_date>1999-01-15</bid_date></bid_tuple><bid_tuple><userid>U01</userid><itemno>1002</itemno><bid>400</bid><bid_date>1999-02-14</bid_date></bid_tuple><bid_tuple><userid>U02</userid><itemno>1002</itemno><bid>600</bid><bid_date>1999-02-16</bid_date></bid_tuple><bid_tuple><userid>U03</userid><itemno>1002</itemno><bid>800</bid><bid_date>1999-02-17</bid_date></bid_tuple><bid_tuple><userid>U04</userid><itemno>1002</itemno><bid>1000</bid><bid_date>1999-02-25</bid_date></bid_tuple><bid_tuple><userid>U02</userid><itemno>1002</itemno><bid>1200</bid><bid_date>1999-03-02</bid_date></bid_tuple><bid_tuple><userid>U04</userid><itemno>1003</itemno><bid>15</bid><bid_date>1999-01-22</bid_date></bid_tuple><bid_tuple><userid>U05</userid><itemno>1003</itemno><bid>20</bid><bid_date>1999-02-03</bid_date></bid_tuple><bid_tuple><userid>U01</userid><itemno>1004</itemno><bid>40</bid><bid_date>1999-03-05</bid_date></bid_tuple><bid_tuple><userid>U03</userid><itemno>1007</itemno><bid>175</bid><bid_date>1999-01-25</bid_date></bid_tuple><bid_tuple><userid>U05</userid><itemno>1007</itemno><bid>200</bid><bid_date>1999-02-08</bid_date></bid_tuple><bid_tuple><userid>U04</userid><itemno>1007</itemno><bid>225</bid><bid_date>1999-02-12</bid_date></bid_tuple></bids>");
            #endregion

            /*
             * В данном примере собирается информация из трех разных xml файлов
             * 
             * необходимо предоставить информацию о товарах цена которых больше 50
             * на ряду с этим предоставить информаци о пользователе, дате и найменование
             * и описание товара
             */

            var data = from bit in bids.Descendants("bid_tuple")
                       where ((double)bit.Element("bid")) > 50                              //берем товары только выше 50$
                       join user in users.Descendants("user_tuple")                         
                       on bit.Element("userid").Value equals user.Element("userid").Value   //обьеденяем пользователей и информаци о ценах
                       join item in items.Descendants("item_tuple")
                       on bit.Element("itemno").Value equals item.Element("itemno").Value   //обьеденяем цены с товарами
                       select new                                                           
                       {                                                                    //создаем новый анонимный обьект
                           Item = bit.Element("itemno").Value,                              //содержащий нужную информацию
                           Description = item.Element("description").Value,
                           User = user.Element("name").Value,
                           Date = bit.Element("bid_date").Value,
                           Price = bit.Element("bid").Value
                       };

            Console.WriteLine("\n==========================================================");
            Console.WriteLine("{0,-12} {1,-12} {2,-6} {3,-14} {4,10}",
                              "Date", "User", "Item", "Description", "Price$");
            Console.WriteLine("==========================================================\n");

            foreach (var item in data)
            {
                Console.WriteLine("{0,-12} {1,-12} {2,-6} {3,-14} {4,10}$",
                item.Date,
                item.User,
                item.Item,
                item.Description,
                item.Price);
            }
        }
    }
}
