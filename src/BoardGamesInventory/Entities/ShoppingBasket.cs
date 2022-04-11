using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2U.BoardGames.Entities
{
  public class ShoppingBasket : EntityBase
  {
    public ShoppingBasket(int id) : base(id) { }

    public Customer Customer { get; private set; } = default!;

    public int? CustomerId { get; set; }

    public void AssignCustomer(string firstName, string lastName, string street, string city)
    {
      Customer = new Customer(0, firstName, lastName);
      Address address = new Address(street, city);
      Customer.MoveToNewAddress(address);
    }

    public void CheckOut()
    {
      // this.RegisterDomainEvent(new ShoppingBasketHasCheckedOut(this));
    }

    public void AddGame(Game game)
    {
      GetBasket().Add(game);
    }

    public void Remove(Game game)
    {
      GetBasket().Remove(game);
    }

    private ICollection<Game> GetBasket()
      => games ??= new List<Game>();

    public IEnumerable<Game> Games
      => games;

    private ICollection<Game> games = default!;
  }

}
