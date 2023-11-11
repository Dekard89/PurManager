using PurchaseManager.Models;
using PurchaseManager.Service;

var IsOver = false;

var stock=new Stock();

stock.StockHandler +=(messege) => ConsoleHelper.ForEvent(messege);

stock.dataService.DataHandler += ConsoleHelper.ForEvent;


var order = new List<Purchase>();
var buyer=new List<Purchase>();

stock.dataService.AddBuyer("Вася", 2);
var buyer1 = stock.dataService.GetBuyer("Вася");
var bl1=new List<Purchase>();
stock.BuyerList.Add(buyer1, bl1);

while (IsOver != true)
{
    int choice = ConsoleHelper.MainMenu();
    switch (choice)
    {
        case 0:
            stock.report.NewDay();
            stock.EndOfDay();
            stock.ClearPurchase(stock.Purhses);
            stock.report.ExportToJson(stock.report);
            break;
        case 1:
            stock.dataService.AddProduct(ConsoleHelper.InputName(),ConsoleHelper.InputPrice());
            break;
        case 2:
            stock.dataService.AddProvider(ConsoleHelper.InputName());
            break;
        case 3:
            stock.AddPurchase(ConsoleHelper.InputName(), ConsoleHelper.InputQuantity());
            break;
        case 4:
            stock.GetBalance(stock.Purhses);
            break;
        case 5:
            var name=ConsoleHelper.InputName();
            var list =stock.GerOrder(stock.GetBuyerStock(ConsoleHelper.InputName()));
            order.AddRange(list);
            stock.ClearPurchase(stock.GetBuyerStock(name));
            stock.ShowAllPurchses(order);
            break;

        case 6:
            stock.BuyAllRange(ConsoleHelper.InputQuantity());
            break;
        case 7:
            var bs=stock.GetBuyerStock(ConsoleHelper.InputName());
            buyer.AddRange(bs);
            stock.SaleForOrder(bs,order);
            break;
        case 8:
            stock.Sale(buyer,stock.GetPurchase(ConsoleHelper.InputName()));
            break;
        case 9:
            stock.EndOfDay();
            break;

    }
}
