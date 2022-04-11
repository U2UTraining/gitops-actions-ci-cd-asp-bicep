namespace U2U.BoardGames.Configurations;

internal class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
  public void Configure(EntityTypeBuilder<Publisher> builder)
  {
    builder.HasKey(pub => pub.Id);
    builder.HasAlternateKey(p => p.Name);

    builder.HasMany(p => p.Games)
      .WithOne(g => g.Publisher)
      .IsRequired();

    // Use the games field instead of the property, because the property has side-effects
    var gamesNav = builder.Metadata
                          .FindNavigation(nameof(Publisher.Games));
    gamesNav!.SetPropertyAccessMode(PropertyAccessMode.Field);
  }
}