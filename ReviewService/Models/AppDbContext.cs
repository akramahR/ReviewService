using Microsoft.EntityFrameworkCore;

namespace ReviewService.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<GuestReview> GuestReviews { get; set; }
    }
}
