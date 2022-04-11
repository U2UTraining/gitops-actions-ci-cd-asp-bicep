using BoardGamesInventory.Controllers;
using BoardGamesInventory.ViewModels.Games;
using Microsoft.AspNetCore.Mvc;
using U2U.BoardGames;
using Xunit;

namespace BoardGamesInventory.Tests
{
  public class GamesControllerShould
  {
    [Fact]
    public void ReturnDetailViewModelForDetail()
    {
      BoardGamesDb db = FakeBoardGamesDb.CreateGamesDb();
      GamesController sut = new(db);

      IActionResult result = sut.Details(1);
      ViewResult view = 
        Assert.IsAssignableFrom<ViewResult>(result);
      GameDetailViewModel vm =
        Assert.IsAssignableFrom<GameDetailViewModel>(view.Model);
      Assert.Equal(Fake.Quirkle.Name, vm.Name);
      Assert.Equal(Fake.Quirkle.Price.Amount, vm.Price);
    }
  }
}