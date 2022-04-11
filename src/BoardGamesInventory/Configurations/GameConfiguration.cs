namespace U2U.BoardGames.Configurations;

  internal class GameConfiguration : IEntityTypeConfiguration<Game>
  {
    public void Configure(EntityTypeBuilder<Game> builder)
    {
      builder.HasKey(g => g.Id);

      builder.HasIndex(g => g.Name)
        .IsUnique();
      builder.Property(g => g.Name)
        .HasMaxLength(128)
        .IsRequired();

      builder
        .HasOne<GameImage>(g => g.Image)
        .WithOne()    // No need for inverse property
        .HasForeignKey<GameImage>(gi => gi.Id);

      builder
        .HasOne(g => g.Publisher)
        .WithMany(p => p.Games);

      builder.Property<int>("PublisherId")
        .IsRequired();

      OwnedNavigationBuilder<Game, Money>? priceNavBuilder = builder.OwnsOne(g => g.Price);
      priceNavBuilder.Property(p => p.Amount)
        .HasColumnType("decimal(4,2)")
        .IsRequired();
      priceNavBuilder.Property(p => p.Currency)
        .HasConversion<string>()
        .HasMaxLength(3)
        .IsRequired();

      builder.HasMaintenance();
    }
  }
