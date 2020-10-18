using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrisonFinance.Shared.DataModel.Inventory
{
    public class dtInvTransactions
    {
        [Key]
        public long ID { get; set; }
        public long VID { get; set; }
        public decimal? SlNo { get; set; }
        public int ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Qty { get; set; }
        public string FOCQty { get; set; }
        public decimal Rate { get; set; }
        public string Unit { get; set; }
        public decimal Factor { get; set; }
        public bool? IsComplex { get; set; }
        public int WHID { get; set; }
        public long? ParentID { get; set; }
        public long? RefID { get; set; }
        public string BatchNo { get; set; }
        public DateTime? ExpDate { get; set; }
        public string Description { get; set; }
        public decimal? Addition { get; set; }
        public decimal? Discount { get; set; }
        public decimal? CBM { get; set; }
        public bool? Active { get; set; }
        public decimal? BasicQty { get; set; }
        public int? RowType { get; set; }
        public int? InvoiceType { get; set; }
        public bool? IsReturn { get; set; }
        public long? AvgCostID { get; set; }
        public int? DrAccountID { get; set; }
        public int? CrAccountID { get; set; }
        public int? PostAccountID { get; set; }
        public int? MgntID { get; set; }
        public string TempQty { get; set; }
        public string TempUnit { get; set; }
        public string VarField1 { get; set; }
        public string VarField2 { get; set; }
        public string VarField3 { get; set; }
        public decimal? NumField1 { get; set; }
        public decimal? NumField2 { get; set; }
        public decimal? NumField3 { get; set; }
        public string TBarCode { get; set; }
        public decimal? AvgCost { get; set; }
        public decimal? LastRate { get; set; }
        public decimal? VAT { get; set; }
        public decimal? Excise { get; set; }
        public decimal? VATPer { get; set; }
        public decimal? ExcisePer { get; set; }
        public decimal? Amount { get; set; }
        public decimal VRate { get; set; }
        public bool? VATRefundable { get; set; }
        public string VATPurpose { get; set; }
        public decimal? VATPerItem { get; set; }
        public decimal? Profit { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal? TAmt { get; set; }
    }
}
