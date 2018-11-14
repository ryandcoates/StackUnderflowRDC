using Microsoft.EntityFrameworkCore;
using StackUnderflowRDC.Entities;
namespace StackUnderflowRDC.Data
{
	public class DataContext : DbContext
	{
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Response> Responses { get; set; }
		public DbSet<Question> Questions { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"
                Data Source= den1.mssql7.gear.host ;
                Initial Catalog=surdc;
                User ID=surdc;
                Password=Vs1yxRKm~I~R;
                ");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Ignore<QuestionForCreation>();
		}
	}
}