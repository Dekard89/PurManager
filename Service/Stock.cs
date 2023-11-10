using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PurchaseManager.Models;

namespace PurchaseManager.Service
{
    public class Stock
    {
        DataService dataService { get; set; }
        public List<Purchase> Purhses { get; }
        
        public Dictionary<Buyer,List<Purchase>> BuyerList { get; }

        public event Action<string> StockHandler;

        public Report report;

        public Stock()
        {
            Purhses = new List<Purchase>();
            dataService = new DataService();
            BuyerList = new Dictionary<Buyer, List<Purchase>>();
            report=new Report();
        }   

        public void ShowAllPurchses(List<Purchase> list)
        {
            foreach (var pur in list)
                StockHandler?.Invoke(pur.ShowPurchse());
            
        }

        public void AddPurchase(Purchase purchase)
        {
            var isCopy=Purhses.Any(x=>x.product.Name==purchase.product.Name);

            if (isCopy == true)
            {
                var p = Purhses.FirstOrDefault(p => p.product.Name == purchase.product.Name);
                p.Quantity += purchase.Quantity;
                report.Bank -= purchase.Total;
            }
            else
            {
                Purhses.Add(purchase);
                report.Bank -= purchase.Total;
            }

        }
        private void DeletePurchase(Purchase purchase)
        {
            Purhses.Remove(purchase);
            report.Bank += purchase.Total;
        }
        public Purchase? CreatePurchase(Product product, int quantity=1)
        {
            return new Purchase(product,quantity);
        }
        
        
        private Purchase? GetPurchase(string name)
        {
            var p = Purhses.FirstOrDefault(p => p.product.Name == name);

            return p;
        }
        public void InstallBayerList()
        {
            var bayer1 = dataService.AddBuyer("Покупатель1", 2);

            var bl1 = new List<Purchase>();

            using(var bd =new Context())
            {
                var list1 = bd.products.Where(x => x.ProductId < 5).ToList();
                foreach(var prod in list1)
                {
                    bl1.Add(CreatePurchase(prod, 2));
                }
                BuyerList.Add(bayer1, bl1);
            }
            var bayer2 = dataService.AddBuyer("Покупатель2", 1);

            var bl2 = new List<Purchase>();

            using (var bd = new Context())
            {
                var list2 = bd.products.Where(x => x.ProductId > 5).ToList();
                foreach (var prod in list2)
                {
                    bl1.Add(CreatePurchase(prod, 1));
                }
                BuyerList.Add(bayer2, bl2);
            }

        }

        public void GetBalance(List<Purchase> purchaseList)
        {
            var list = purchaseList.Where(x => x.Quantity > 0).ToList();
           
            ShowAllPurchses(list);
            
        }
        public void ClearPurchase(List<Purchase>purchases)
        {
            foreach(var p in purchases)
            {
                if(p.Quantity<=0)  purchases.Remove(p);
                StockHandler?.Invoke($"Товар {p} закончился");
            }
        }
        public List<Purchase>? GerOrder(List<Purchase> purchaseList)
        {
            var order=purchaseList.Where(x=>x.Quantity<=0).ToList();
            ShowAllPurchses(order);
            return order;
        }
        public List<Purchase>? GetBuyerStock(string name)
        {
            var result = BuyerList.FirstOrDefault(x=>x.Key.Name==name).Value.ToList();
            return result;
            
        }
        public void Sale(List<Purchase> purchaseList, Purchase purchase)
        {
            Purhses.Remove(purchase);
            var isCopy=purchaseList.Any(x=>x.product.Name==purchase.product.Name);
            if(isCopy==true)
            {
                var pur = purchaseList.FirstOrDefault(x => x.product.Name == purchase.product.Name);
                pur.Quantity += purchase.Quantity;

            }
            else
              purchaseList.Add(purchase);
        }
        public void SaleForOrder(List<Purchase> purchseList, List<Purchase> order)
        {
            purchseList.AddRange(order);
            foreach (var p in Purhses)
                foreach(var o in order)
                {
                    if (p.product.Name == o.product.Name)
                        if (p.Quantity > o.Quantity)
                        {
                            p.Quantity -= o.Quantity;
                            report.Bank += o.Total;
                        }
                        else
                            DeletePurchase(p);
                }
            
        }
        public void EndOfDay()
        {
            foreach(var buyer in BuyerList)
                foreach(var p in buyer.Value)
                {
                    p.Quantity -= buyer.Key.Consumption;
                }
            report.ExportToJson(report);
        }

      
    }
}
