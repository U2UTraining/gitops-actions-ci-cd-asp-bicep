namespace U2U.BoardGames.Configurations;

internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
  public void Configure(EntityTypeBuilder<Customer> customer)
  {
    customer.HasKey(c => c.Id);

    customer.Property(c => c.FirstName)
      .HasMaxLength(100)
      .IsRequired();

    customer.Property(c => c.LastName)
      .HasMaxLength(100)
      .IsRequired();

    OwnedNavigationBuilder<Customer, Address>? addressNavBuilder 
      = customer.OwnsOne(c => c.Address);
    addressNavBuilder.Property(a => a!.Street)
      .HasMaxLength(100);
    addressNavBuilder.Property(a => a!.City)
      .HasMaxLength(100);

    customer.HasOne(c => c.ShoppingBasket)
            .WithOne(sb => sb.Customer)
            .HasForeignKey<ShoppingBasket>(sb => sb.CustomerId)
            .IsRequired(false);
  }
}

