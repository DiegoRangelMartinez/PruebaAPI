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
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=DIEGO-PC\\SQLEXPRESS;Database=PruebaAPI;Persist Security Info=True;Integrated Security=SSPI;");
			}
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Country>().HasKey(x => x.Code);
			modelBuilder.Entity<Department>().HasKey(x => x.Code);
			modelBuilder.Entity<Department>(entity => {
				entity.HasOne(obj => obj.Country).WithMany().HasForeignKey(fk => fk.CountryCode).OnDelete(DeleteBehavior.Cascade);
			});
		}
	}
}
