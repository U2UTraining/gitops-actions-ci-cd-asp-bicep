namespace U2U.BoardGames.ValueObjects;

public class Address : IEquatable<Address>
{
  public string Street { get; }

  public string City { get; }

  public Address(string street, string city)
  {
    Street = street;
    City = city;
  }

  public override bool Equals(object? obj) 
    => ValueObjectComparer<Address>.Instance.Equals(this, obj);

  public bool Equals(Address? other)
    => ValueObjectComparer<Address>.Instance.Equals(this, other);

  public static bool operator ==(Address left, Address right)
  => ValueObjectComparer<Address>.Instance.Equals(left, right);

  public static bool operator !=(Address left, Address right)
    => !(left == right);

  public override int GetHashCode()
  => ValueObjectComparer<Address>.Instance.GetHashCode(this);
}
