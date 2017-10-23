using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLinq.Examples
{
    public static class Example7
    {
        /// <summary>
        /// В этом примере происходит выборка из двух источников
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Example #7:");

            List<Customer> listCustomer = new List<Customer>()
            {
                new Customer() { Name = "Bob", Age = 34, Language = "Russian"},
                new Customer() { Name = "Sam", Age = 24, Language = "English"},
                new Customer() { Name = "Jack", Age = 54, Language = "Ukranian"}
            };

            List<Phone> listPhone = new List<Phone>()
            {
                new Phone() { Company = "Microsoft", Model = "Lumia 520" },
                new Phone() { Company = "Nokia", Model = "Nokia 3" },
                new Phone() { Company = "Samsung", Model = "Note 8" }
            };

            var selected = from customer in listCustomer                            //проходим по списку listCustomer
                           from phone in listPhone                                  //проходим по списку listPhone
                           select new { Customer = customer, Phone = phone };       //создаем анонимный обьект с полями Customer и Phone
            //в данном случае к каждому обьекту listCustomer применяется обькт из listPhone т.е. получится 3*3=9 анонимных обьектов

            foreach (var item in selected)
                Console.WriteLine($"Customer: {item.Customer}; Phone: {item.Phone}");
        }
    }
}
