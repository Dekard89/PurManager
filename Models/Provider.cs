using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PurchaseManager.Models
{
    public class Provider
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProviderId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public Provider(string name)
        {
            Name = name;
            IsActive = true;
        }
    }
}
