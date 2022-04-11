namespace U2U.BoardGames.Configurations;

internal class ShoppingBasketConfiguration : IEntityTypeConfiguration<ShoppingBasket>
{
  public void Configure(EntityTypeBuilder<ShoppingBasket> shoppingBasket)
  {
    shoppingBasket.HasKey(sb => sb.Id);

    shoppingBasket
      .HasMany(sb => sb.Games);

    Microsoft.EntityFrameworkCore.Metadata.IMutableNavigation gamesNav =
      shoppingBasket.Metadata.FindNavigation(nameof(ShoppingBasket.Games))!;
    gamesNav.SetPropertyAccessMode(PropertyAccessMode.Field);
    gamesNav.SetField("games");
  }
}

