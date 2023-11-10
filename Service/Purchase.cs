using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseManager.Models;

namespace PurchaseManager.Service
{
    public class Purchase
    {
        public Product product { get; private set; }

        public int Quantity { get; set; }

       public double Total
        {
            get => Total;
            set => Total = Quantity * product.Cost;
            
        }
        
           
        
        public Purchase(Product product, int quantity)         {
            this.product = product;
            Quantity = quantity;
        }

        public string ShowPurchse()
        {
            return $"{product.Name} : {product.Cost} : {Quantity} - {Total}\n";
        }

    }
}
