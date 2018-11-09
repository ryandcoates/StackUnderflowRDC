using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StackUnderflowRDC.Entities;

namespace StackUnderflowRDC.Data
{
    public class ApplicationDbContext : IdentityDbContext
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

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		    : base(options)
	    {
	    }
	}
}
