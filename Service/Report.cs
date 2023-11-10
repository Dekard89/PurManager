using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PurchaseManager.Service
{
    public class Report
    {
        public int DayCounter { get; set; }

        public double Bank { get; set; }

        public int PurchaseCount { get; set; }

        public int SaleCount { get; set; }

       

        public Report()
        {
            DayCounter= 0;
            Bank= 100;
            PurchaseCount= 0;
            SaleCount= 0;
        }

        public string ShowReport()
        {
            return $"день - {DayCounter} закупка- {PurchaseCount} проданно- {SaleCount} на счету : {Bank}";
        }
        public void NewDay()
        {
            DayCounter++;
        }
        public void ExportToJson(Report report)
        {
            var path = @"C:\Users\Asus\source\repos\PurchaseManager\PurchaseManager\Service\report.json";
            var json= JsonSerializer.Serialize<Report>(report);
            File.WriteAllText(path,json);
        }
        
    }
}
