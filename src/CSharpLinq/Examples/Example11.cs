using System;
using System.Linq;

namespace CSharpLinq.Examples
{
    public static class Example11
    {
        //В этом примере используются методы Skip, Take, TakeWhile, SkipWhile
        public static void Show()
        {
            Console.WriteLine("Example #11:");

            int[] numbers = { -3, -2, -1, 0, 1, 2, 3 };

            Console.WriteLine("Skip:");

            //Метод Skip, в данном случае пропускает первые три элемента, остальные выводим
            //на экран
            foreach (var item in numbers.Skip(3))
                Console.WriteLine(item);

            Console.WriteLine("Take:");

            //Метод Take, в данном случае берет в коллекцию только первые три элемента
            foreach (var item in numbers.Take(3))
                Console.WriteLine(item);

            Console.WriteLine("Paginator:");

            //В данном случае пропускается первые три элемента и берутся
            //елементы номер 4,5,6, "пагинатор"
            foreach (var item in numbers.Skip(3).Take(3))
                Console.WriteLine(item);

            string[] teams = { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };

            Console.WriteLine("TakeWhile:");

            //TakeWhile будет брать команды которые, в данном случае, начинатся на 
            //букву Б, если же последовательность нчинается словом не на букву Б
            //то TakeWhile возвратит 0, если же в первых элементах есть слова с нужной буквой
            //то метод будет брать их пока не попадется слово не на букву Б
            //тогда он прекратит работать, даже если дальше есть еще слова на Б
            foreach (var item in teams.TakeWhile(x => x.StartsWith("Б")))
                Console.WriteLine(item);

            Console.WriteLine("SkipWhile:");

            //SkipWhile работает аналогично TakeWhile, только не берет обьекты, а пропускает их
            foreach (var item in teams.SkipWhile(x => x.StartsWith("Б")))
                Console.WriteLine(item);
        }
    }
}
