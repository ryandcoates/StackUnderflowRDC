using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StackUnderflowRDC.Entities;

namespace StackUnderflowRDC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //public DbSet<Comment> Comments { get; set; }
        //public DbSet<Response> Responses { get; set; }
        //public DbSet<Question> Questions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
                Data Source= den1.mssql7.gear.host ;
                Initial Catalog=surdcusers;
                User ID=surdcusers;
                Password=Zi0M02Y!_65b;
                ");
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		    : base(options)
	    {
	    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<QuestionForCreation>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
