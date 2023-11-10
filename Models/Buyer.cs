using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManager.Models
{
    public class Buyer
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BuyerId { get; set; }

        public string Name { get; set; }

        public int Consumption { get; set; }

       

        public Buyer( string name, int consumption)
        {
            
            Name = name;
            Consumption = consumption;
            

        }
        
    }
}
