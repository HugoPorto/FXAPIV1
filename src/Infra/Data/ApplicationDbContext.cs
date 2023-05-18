using FXAPIV1.Domain.Orders;

namespace FXAPIV1.Infra.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public DbSet<Order> Orders { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    { }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Ignore<Notification>();

        builder.Entity<Product>().Property(p => p.Name).IsRequired();

        builder.Entity<Product>().Property(p => p.Description).HasMaxLength(255);

        // É não csongio adicionar registro obrigatorio se já existem registros obrigatórios no banco de dados.
        // Preciso apagar tudo antes de fazer esse tipo de mudança.
        // Adicionar essa linha antes de rodar o dotnet ef migration add ...
        builder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(10,2)").IsRequired();

        builder.Entity<Category>().Property(c => c.Name).IsRequired();

        builder.Entity<Order>()
            .Property(o => o.ClientId).IsRequired();

        builder.Entity<Order>()
            .Property(o => o.DeliveryAddress).IsRequired();

        builder.Entity<Order>().Property(o => o.Total).HasColumnType("decimal(10,2)").IsRequired();

        builder.Entity<Order>()
            .HasMany(o => o.Products)
            .WithMany(p => p.Orders)
            .UsingEntity(x => x.ToTable("OrderProducts"));
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>().HaveMaxLength(100);
    }
}
