using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrisonFinance.Shared.DataModel
{
    
        public class VoucherMaster
        {
            [Key]
            public long ID { get; set; }
            public string VNo { get; set; }
            public int VType { get; set; }
            public decimal? Amount { get; set; }
            public DateTime Vdate { get; set; }
            public bool Posted { get; set; }
            public string RefNo { get; set; }
            public bool? IsCanceled { get; set; }
            public decimal? Discount { get; set; }
            public decimal? NetAmt { get; set; }
            public string Field5 { get; set; }
            public string VNoInt { get; set; }
            public long AccountId { get; set; }
            public string AccountCode { get; set; }
            public string AccountName { get; set; }

        }
    }
