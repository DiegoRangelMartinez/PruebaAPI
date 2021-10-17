using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
	public class PruebaAPIDBContext : DbContext
	{
		public PruebaAPIDBContext() { }
		public PruebaAPIDBContext(DbContextOptions<PruebaAPIDBContext> options)
			: base(options) { }
		public virtual DbSet<Country> Countries { get; set; }
		public virtual DbSet<Department> Departments { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Country>().HasKey(x => x.Code);
			modelBuilder.Entity<Department>().HasKey(x => x.Code);
			modelBuilder.Entity<Department>(entity => {
				entity.HasOne(obj => obj.Country).WithMany().OnDelete(DeleteBehavior.Cascade);
			});
		}
	}
}
