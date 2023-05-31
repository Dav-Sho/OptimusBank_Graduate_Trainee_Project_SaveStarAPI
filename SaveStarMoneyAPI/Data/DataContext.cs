
namespace SaveStarMoneyAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        //public DbSet<FixedSaving> FixedSavings => Set<FixedSaving>();
        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<FixedSavingsEntity> FixedSavings => Set<FixedSavingsEntity>();
        public DbSet<PercentageSaving> PercentageSavings => Set<PercentageSaving>();
    }
}
