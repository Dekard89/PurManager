using PurchaseManager.Models;
using PurchaseManager.Service;

var IsOver = false;

var dataService=new DataService();
dataService.DataHandler+= (string messege)=> Console.WriteLine(messege);

int choice;

do
{
    Console.WriteLine("Введите 0 для выхода, введите 1 для ввода поставщика, введите 2 для ввода товара");
    choice=Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 0:
            IsOver = true;
            break;
        case 1:
            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();
            dataService.AddProvider(name);
            break;
        case 2:
            Console.WriteLine("Введите имя");
            string name1 = Console.ReadLine();
            Console.WriteLine("Введите стомость");
            double cost = Convert.ToDouble(Console.ReadLine());
            dataService.AddProduct(name1,cost);
            break;

    }

} while (IsOver == false);