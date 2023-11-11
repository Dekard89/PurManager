using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManager.Service
{
    public static class ConsoleHelper
    {
        public static void ForEvent(string massege)
        {
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine(massege);
        }
        public static int MainMenu()
        {
            int result=0;
            Console.WriteLine("0-завершить");
            Console.WriteLine("1-добавить товар");
            Console.WriteLine("2-добавить поставщика");
            Console.WriteLine("3-добавить покупку");
            Console.WriteLine("4-посмотреть остатки");
            Console.WriteLine("5-получить заказ");
            Console.WriteLine("6-закупить всё");
            Console.WriteLine("7-продать по заказу");
            Console.WriteLine("8-продать 1 товар");
            Console.WriteLine("9-завершить день");
            try
            {

                 result= Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                
            }
            return result;
        }
        public static string InputName()
        {
            string name;

            Console.WriteLine("Введите имя");

            name= Console.ReadLine();

            return name;
        }
        public static int InputQuantity()
        {
            int result = 1;
            Console.WriteLine("Введите количество");
            try
            {
                result = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
            return result;
        }
        public static double InputPrice()
        {
            double result = 1;
            Console.WriteLine("Введите цену");
            try
            {
                result = Convert.ToDouble(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
