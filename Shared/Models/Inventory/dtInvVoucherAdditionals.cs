using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrisonFinance.Shared.DataModel.Inventory
{
    public class dtInvVoucherAdditionals
    {
        [Key]
        public long VID { get; set; }
        public string Keyword { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public bool? VDefault { get; set; }
        public int? DiscountID { get; set; }
        public decimal? Discount { get; set; }
        public decimal? AmountPaid { get; set; }
        public string PartyName { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string HeaderText { get; set; }
        public string FooterText { get; set; }
        public int? ProjectID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int? CostPhaseID { get; set; }
        public string CostPhase { get; set; }
        public int? CostUnitID { get; set; }
        public string CostUnit { get; set; }
        public int? DefaultWHID { get; set; }
        public string WHCODE { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
        public string Field6 { get; set; }
        public string Field7 { get; set; }
        public string Field8 { get; set; }
        public string Field9 { get; set; }
        public string Field10 { get; set; }
        public int? ProjectIDTo { get; set; }
        public string CodeTo { get; set; }
        public string DescriptionTo { get; set; }
        public int? CostPhaseIDTo { get; set; }
        public string CostPhaseTo { get; set; }
        public int? CostUnitIDTo { get; set; }
        public string CostUnitTo { get; set; }
        public int? DefaultWHIDTo { get; set; }
        public string WHCODETo { get; set; }
        public string ClientName { get; set; }
        public DateTime? Date2 { get; set; }
        public string TRNNo { get; set; }
        public string Place { get; set; }
        public string Emirates { get; set; }
        public string VATPurpose { get; set; }
        public string VATType { get; set; }
        public string TAXCode { get; set; }

    }
}
