using Microsoft.EntityFrameworkCore;

namespace CoreAndFood.DATA.Models
{
    public class Context :DbContext
    {
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MUHAMMET; database=DBCoreFood; integrated security=true;");
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
