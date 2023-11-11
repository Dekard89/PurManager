using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManager.Models
{
    public class DataService
    {
        public event Action<string> DataHandler;

        public DataService()
        {
            
        }


        public void AddProduct( string name,double cost)
        {
            using (var db = new Context())
            {


                

                
                var result = new Product(name,cost);
                db.products.Add(result);
                db.SaveChanges();

                DataHandler?.Invoke($"товар {name} добавлен");
               
                
            }
        }

        public Provider GetProvider(string name)
        {
            Provider provider=null;
            using (var db = new Context())
            {

                var x = db.providers.Any(p => p.Name == name);
                if (x == true)
                {
                    provider = db.providers.FirstOrDefault(p => p.Name == name);
                    

                }
                if (x == false)
                {
                    DataHandler?.Invoke($"поставщик {name} не найден");

                }
            }

            return provider;
        }
        
        public void DeleteProduct(string name)
        {
            using(var db = new Context())
            {
                var p = db.products.FirstOrDefault(x => x.Name == name);
                db.products.Remove(p);
                db.SaveChanges();
                DataHandler?.Invoke($"Товар {name} удален");
            }
        }
        public void AddProvider(string providerName)
        {
            using(var db=new Context())
            {
                var p = new Provider(providerName);
                db.providers.Add(p);
              
                db.SaveChanges();
                DataHandler?.Invoke($"поставщик {providerName} добавлен");

            }
        }
        public Product? GetProduct(string name)
        {
            Product? result = null;
            using (var db = new Context())
            {
                result = db.products.FirstOrDefault(x=>x.Name==name);
            }
            return result;
        }
        public void AddBuyer(string buyerName, int consuption)
        {
            using (var db = new Context())
            {

                var b = new Buyer(buyerName, consuption);

                db.buyers.Add(b);
                db.SaveChanges();
                DataHandler?.Invoke($"Покупатель {b} добавлен");
                
            }
        }
        public void DeleteBuyer(string buyerName)
        {
            using(var db=new Context())
            {
                var b=db.buyers.FirstOrDefault(x=> x.Name == buyerName);
                db.buyers.Add(b);
                db.SaveChanges() ;
                DataHandler?.Invoke($"Покупатель {b} удален");
            }
        }
        public List<Product> GetAllRange()
        {
            using(var db=new Context())
            {
                var p = db.products.ToList();
                return p;
            }
        }
        public Buyer GetBuyer(string buyerName)
        {
            
            using (var db = new Context())
            {
               var result = db.buyers.FirstOrDefault(x=>x.Name==buyerName);

                return result;
            }
            
        }
       

    }    
}
