namespace MiniAccounting.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MiniAccountingContext : DbContext
    {
        public MiniAccountingContext()
            : base("name=MiniAccountingContext")
        {
            Database.SetInitializer<MiniAccountingContext>(new DbInitializer());
        }

        public virtual DbSet<CardStock> CardStock { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryType> CategoryType { get; set; }
        public virtual DbSet<MeasurementUnit> MeasurementUnit { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TaxRate> TaxRate { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<CardCustomer> CardCustomer { get; set; }
        public virtual DbSet<City> City { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}