using Microsoft.EntityFrameworkCore;
 
namespace Restaurant.Models
{
    public class RestaurantContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }
        public DbSet<RReview> RestaurantReview{get;set;}
    }
}