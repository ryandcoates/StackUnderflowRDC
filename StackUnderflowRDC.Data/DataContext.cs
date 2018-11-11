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
                Data Source=(localdb)\mssqllocaldb; 
                Initial Catalog=StackUnderflowRDC;
                Integrated Security=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Ignore<QuestionForCreation>();
		}
	}
}