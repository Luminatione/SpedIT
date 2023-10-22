using Microsoft.EntityFrameworkCore;
using SpedIT.Models;
using SpedIT_Domain.Models;
using System.Reflection.Metadata;

namespace SpedIT_Domain
{
    public class DataContext : DbContext
    {
        static DataContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public virtual DbSet<Complain> Complains { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        public DataContext() { }

        public DataContext(string connectionString) { }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Password=password;Username=postgres;Database=postgres;Include Error Detail=True;Port=5432");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
