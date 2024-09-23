using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Shop> Shops { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // テーブルを小文字にする
        modelBuilder.Entity<Product>().ToTable("products");
        modelBuilder.Entity<Shop>(entity =>
        {
            entity.ToTable("shops");  // テーブル名を指定
            entity.Property(e => e.Id).HasColumnName("id");  // スネークケースに変更
            entity.Property(e => e.Name).HasColumnName("name");  // スネークケースに変更
        });
    }
}
