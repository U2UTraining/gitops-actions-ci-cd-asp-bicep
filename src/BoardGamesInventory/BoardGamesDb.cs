namespace U2U.BoardGames;

public class BoardGamesDb : DbContext
{
  public BoardGamesDb() { }

  public BoardGamesDb(DbContextOptions<BoardGamesDb> options)
    : base(options) { }

  // virtual for easy stubbing with MOQ
  public virtual DbSet<Currency> Currencies { get; set; } = default!;
  public virtual DbSet<Game> Games { get; set; } = default!;
  public virtual DbSet<Publisher> Publishers { get; set; } = default!;
  public virtual DbSet<Customer> Customers { get; set; } = default!;

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
    modelBuilder.ApplyConfiguration(new GameImageConfiguration());
    modelBuilder.ApplyConfiguration(new GameConfiguration());
    modelBuilder.ApplyConfiguration(new PublisherConfiguration());
    modelBuilder.ApplyConfiguration(new CustomerConfiguration());
    modelBuilder.ApplyConfiguration(new ShoppingBasketConfiguration());

    // Data Seeds

    modelBuilder.HasData(new CurrencyData());
    modelBuilder.HasData(new GameImageData());
    modelBuilder.HasData(new GameData());
    modelBuilder.HasData(new PublisherData());
  }
}
