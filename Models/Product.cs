using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManager.Models
{
    public class Product
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public double Cost { get; set; }


        public int ProviderId {get; set; }
             
            
        

        public Product( string name,double cost)
        {

            Name= name;

            Cost= cost;

            
            
        }
    }
}
