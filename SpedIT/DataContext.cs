using Microsoft.EntityFrameworkCore;
using SpedIT.Models;
using SpedIT_Domain.Models;

namespace SpedIT_Domain
{
	public class DataContext : DbContext
	{
		public virtual DbSet<Complain> Complains { get; set; }
		public virtual DbSet<Department> Departments { get; set; }
		public virtual DbSet<Employee> Employees { get; set; }
		public virtual DbSet<Invoice> Invoices { get; set; }
		public virtual DbSet<Package> Packages { get; set; }
		public virtual DbSet<Position> Positions { get; set; }
		public virtual DbSet<Vehicle> Vehicles { get; set; }
	}
}
