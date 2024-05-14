using FXAPIV1.Domain.Orders;
using FXAPIV1.Domain.SoyReport;
using FXAPIV1.Domain.CornReport;
using FXAPIV1.Domain.OrderService;

namespace FXAPIV1.Infra.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<SoyReport> SoyReports { get; set; }
    public DbSet<CornReport> CornReport { get; set; }
    public DbSet<OrderService> OrderService { get; set; }
    #pragma warning disable CS8618
    public ApplicationDbContext(DbContextOptions options) : base(options) {}
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Ignore<Notification>();
        builder.Entity<Product>().Property(p => p.Name).IsRequired();
        builder.Entity<Product>().Property(p => p.Description).HasMaxLength(255);
        builder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(10,2)").IsRequired();
        builder.Entity<Category>().Property(c => c.Name).IsRequired();
        builder.Entity<Order>().Property(o => o.ClientId).IsRequired();
        builder.Entity<Order>().Property(o => o.DeliveryAddress).IsRequired();
        builder.Entity<Order>().Property(o => o.Total).HasColumnType("decimal(10,2)").IsRequired();
        builder.Entity<Order>()
            .HasMany(o => o.Products)
            .WithMany(p => p.Orders)
            .UsingEntity(x => x.ToTable("OrderProducts"));
        builder.Entity<SoyReport>().Property(s => s.OrderServiceId).IsRequired();
        builder.Entity<CornReport>().Property(c => c.OrderServiceId).IsRequired();
        builder.Entity<OrderService>().Property(os => os.ClientId).IsRequired();

    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>().HaveMaxLength(100);
    }
}
