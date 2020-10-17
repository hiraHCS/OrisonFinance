using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrisonFinance.Shared.DataModel.Inventory
{
    public class dtInvAccounts
    {

        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        [Key]
        public int ID { get; set; }
        public string TRNNo { get; set; }
        public string AccCategory { get; set; }
        public string SubGroup { get; set; }
        public string AccountGroup { get; set; }
        public bool VoucherEntry { get; set; }
        public string GroupType { get; set; }
        public int ParentID { get; set; }
        public string Parent { get; set; }
        public string Address1 { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
        public string Category { get; set; }
        public int StaffID { get; set; }
        public string StaffName { get; set; }
        public string Price { get; set; }
        public string PBNo { get; set; }
        public bool IsDefault { get; set; }
        public string Country { get; set; }
        public string Emirates { get; set; }
    }
}
