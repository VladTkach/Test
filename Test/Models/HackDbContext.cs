using Microsoft.EntityFrameworkCore;
namespace Test.Models
{
    public class HackDbContext: DbContext
    {
        public HackDbContext(DbContextOptions<HackDbContext> options) : base(options)
        {

        }

        public DbSet<Meal> Meal { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<MealPlan> MealPlan { get; set; }
    }
}
