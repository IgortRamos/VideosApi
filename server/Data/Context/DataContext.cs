using Microsoft.EntityFrameworkCore;
using Domain.Entities.Videos;

namespace Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //Database.SetCommandTimeout(180);
        }

        //protected DataContext() => Database.SetCommandTimeout(180);

        public DbSet<Video> Videos { get; set; }
    }
}