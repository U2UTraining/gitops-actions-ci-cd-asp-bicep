namespace U2U.BoardGames.Configurations;

internal class GameImageConfiguration : IEntityTypeConfiguration<GameImage>
{
  public void Configure(EntityTypeBuilder<GameImage> builder)
  {
    builder.HasKey(gi => gi.Id);

    builder.Property(gi => gi.ImageLocation)
      .HasMaxLength(1024)
      .IsRequired();
  }
}
