using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrisonFinance.Shared.DataModel.Inventory
{
    public class dtItems
    {

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string BarCode { get; set; }
        [Key]
        public int ID { get; set; }
        public string SellingPrice { get; set; }
        public int Stock { get; set; }
        public string Unit { get; set; }
        public decimal LastCost { get; set; }
        public decimal AvgCost { get; set; }
        public decimal Factor { get; set; }
        public bool IsComplex { get; set; }
        public int InvAccountID { get; set; }
        public int CostAccountID { get; set; }
        public int PurchaseAccountID { get; set; }
        public int SalesAccountID { get; set; }
        public decimal AStock { get; set; }
        public bool IsGroup { get; set; }
        public bool StockItem { get; set; }
        public string NoSpaceItemCode { get; set; }
        public string Category { get; set; }
        public decimal CashPrice { get; set; }
        public decimal CreditPrice { get; set; }
        public string Location { get; set; }
        public string VATPer { get; set; }
        public decimal ExcisePercen { get; set; }
    }
}
