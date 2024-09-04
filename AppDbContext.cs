using Microsoft.EntityFrameworkCore;

namespace ProductCatalogApi
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet プロパティをここに追加
        // 例: public DbSet<Product> Products { get; set; }
    }
}