using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLinq.Examples
{
    public static class Example13
    {
        /// <summary>
        /// Тут происходит обьединение обьектов по общему свойству или просто последовательное обьединение (первый с первым и тд)
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Example #13:");

            List<Team> teams = new List<Team>()
            {
                new Team { Name = "Бавария", Country ="Германия" },
                new Team { Name = "Барселона", Country ="Испания" }
            };
            List<Player> players = new List<Player>()
            {
                new Player {Name="Месси", Team="Барселона"},
                new Player {Name="Неймар", Team="Барселона"},
                new Player {Name="Роббен", Team="Бавария"}
            };

            var selected1 = from pl in players                                      //проходим по списку
                            join tm in teams on pl.Team equals tm.Name              //указываем, что будем соеденять список игроков со списком команд
                            select new                                              //оператором equals указываем обьщее поле по которому будет происходить
                            {                                                       //обьеденение
                                Name = pl.Name,                                     //создаем анонимный метод со всеми полями двух обьектов
                                Team = pl.Team,                                     //и одним общим
                                Country = tm.Country
                            };

            Console.WriteLine("#1:");

            foreach (var item in selected1)
                Console.WriteLine($"{item.Name} from {item.Team} ({item.Country})");

            //аналогичный предыдущему парианту
            var selected2 = players.Join(teams,                     //второй список с которым будем обьеденять
                                         p => p.Team,               //общее поле с первго списка
                                         t => t.Name,               //общее поле со второго списка
                                         (p, t) => new              //новый анонимный обьект, как в пред. примере
                                         {
                                            Name = p.Name,                                     
                                            Team = p.Team,                                    
                                            Country = t.Country
                                         });


            Console.WriteLine("#2:");

            foreach (var item in selected2)
                Console.WriteLine($"{item.Name} from {item.Team} ({item.Country})");

            //Join соеденяет обьекты, GroupJoin - соеденет еще и групирует эти элементы
            var selected3 = teams.GroupJoin(players,                                            //второй список с обьектами для обьединения
                                            t => t.Name,                                        //общее поле
                                            p => p.Team,                                        //общее поле
                                            (team, player) => new                               //обьект, команда с группой игроков
                                            {
                                                Name = team.Name,
                                                Country = team.Country,
                                                Players = from item in player select item.Name
                                            });

            Console.WriteLine("#3:");

            foreach (var item in selected3)
            {
                Console.WriteLine($"{item.Name} ({item.Country}):");
                foreach (var pl in item.Players)
                    Console.WriteLine($"\t{pl}");
            }

            List<Customer> customers = new List<Customer>()
            {
                new Customer() { Name = "Bob", Age = 33 },
                new Customer() { Name = "Jack", Age = 23 },
                new Customer() { Name = "Maria", Age = 63 }
            };

            List<Phone> phones = new List<Phone>()
            {
                new Phone() { Model = "Lumia 520" },
                new Phone() { Model = "IPhone 7" },
                new Phone() { Model = "Redmi 4 Pro" }
            };

            //Последовательно обьеденяет колекции
            //первый с первым
            //второй с вторым
            //и тд
            var selected4 = customers.Zip(phones,                   //колекция с которой происходить обьединение
                                          (c, p) => new             //новый обьект с нужными полями
                                          {
                                              Name = c.Name,
                                              Age = c.Age,
                                              Phone = p.Model
                                          });


            Console.WriteLine("#4:");

            foreach (var item in selected4)
                Console.WriteLine($"Customer - {item.Name} ({item.Age}) with phone {item.Phone}");
        }
    }
}
