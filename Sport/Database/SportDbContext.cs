using Microsoft.EntityFrameworkCore;

public class SportDbContext : DbContext
{
    private readonly string connection = "SERVER = KENZ; DATABASE = Sport; Trusted_Connection = True; TrustServerCertificate = True;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connection);
    }

    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<User> Users { get; set; }
}