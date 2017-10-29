using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpLinq.Examples
{
    public static class Example17
    {
        /// <summary>
        /// Обработка исключений и пример работы с CancellationToken (прерываение операции)
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Example #17:");


            object[] numbers = new object[] { 1, 2, 3, 4, 5, "hello" };

            var fac = from item in numbers.AsParallel()         //Проходим по списку, указав, что нужно распаралелить его
                      let x = (int)item                         //приволим все элементы к int
                      select Helper.Factorial(x);               //щем факториал числа

            Console.WriteLine("#1:");

            //Тут обрабатываем ошику, так как последний элемент не является числом и его невозможно
            try
            {
                fac.ForAll(x => Console.WriteLine(x));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            int[] numbers2 = new int[] { 1, 2, 3, 4, 5, 7, 6, 7, 8, 9, 10, 34, 3, 11, 23, 42, 13, 53, 13, 52 };

            CancellationTokenSource canel = new CancellationTokenSource();

            new Task(() =>
            {
                Thread.Sleep(500);
                canel.Cancel();
            }).Start();

            //В данном случае присутствует возможность отметить операцию, если этого требубт временные рамки
            //или пользователь
            //Выше в таске через полсекунды сработает метод Cancel() в токене и операция прервется, сработает исключение OperationCanceledException
            try
            {
                var fac2 = from item in numbers2.AsParallel().WithCancellation(canel.Token)
                           select Helper.FactorialWithSleep(item, 50);

                Console.WriteLine("#2:");

                foreach (var item in fac2)
                    Console.WriteLine(item);
            }
            catch (OperationCanceledException e2)
            {
                Console.WriteLine(e2.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                canel.Dispose();
            }
        }
    }
}
