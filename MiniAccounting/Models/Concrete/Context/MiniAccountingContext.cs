namespace MiniAccounting.Models.Context
{
    using MiniAccounting.Models.Concrete;
    using System.Data.Entity;

    public partial class MiniAccountingContext : DbContext
    {
        public MiniAccountingContext()
            : base("name=MiniAccountingContext")
        {
            Database.SetInitializer<MiniAccountingContext>(new DbInitializer());
        }

        public virtual DbSet<Stock> CardStock { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryType> CategoryType { get; set; }
        public virtual DbSet<MeasurementUnit> MeasurementUnit { get; set; }
        public virtual DbSet<TaxRate> TaxRate { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<Customer> CardCustomer { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}