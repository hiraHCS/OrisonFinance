using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrisonFinance.Shared.DataModel;
using OrisonFinance.Shared.DataModel.Inventory;
namespace OrisonFinance.Server.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext()
        {
        }
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }
        public DbSet<VoucherMaster> VoucherMaster { get; set; }
        public DbSet<OrisonFinance.Shared.DataModel.Inventory.dtInvVoucher> dtInvVoucher { get; set; }
        public DbSet<OrisonFinance.Shared.DataModel.Inventory.dtInvVoucherEntry> dtInvVoucherEntry { get; set; }
        public DbSet<OrisonFinance.Shared.DataModel.Inventory.dtInvVoucherAdditionals> dtInvVoucherAdditionals { get; set; }
        public DbSet<OrisonFinance.Shared.DataModel.Inventory.dtInvTransactions> dtInvTransactions { get; set; }
        public DbSet<OrisonFinance.Shared.DataModel.Inventory.dtItems> dtItems { get; set; }
        public DbSet<OrisonFinance.Shared.DataModel.Inventory.dtInvAccounts> dtInvAccounts { get; set; }


    }
}
