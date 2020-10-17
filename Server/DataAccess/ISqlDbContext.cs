using Microsoft.EntityFrameworkCore;
using OrisonFinance.Shared.DataModel.Inventory;

namespace OrisonFinance.Server.Data
{
    public interface ISqlDbContext
    {
        DbSet<dtInvAccounts> dtInvAccounts { get; set; }
        DbSet<dtInvTransactions> dtInvTransactions { get; set; }
        DbSet<dtInvVoucher> dtInvVoucher { get; set; }
        DbSet<dtInvVoucherAdditionals> dtInvVoucherAdditionals { get; set; }
        DbSet<dtInvVoucherEntry> dtInvVoucherEntry { get; set; }
        DbSet<dtItems> dtItems { get; set; }
    }
}