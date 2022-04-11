using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;
using U2U.BoardGames;
using U2U.BoardGames.Entities;

namespace BoardGamesInventory.Tests
{
  public static class FakeBoardGamesDb
  {
    public static DbSet<T> CreateDbSet<T>(IQueryable<T> data)
      where T : class
    {
      var moq = new Mock<DbSet<T>>();
      moq.As<IQueryable<T>>()
        .Setup(m => m.Provider)
        .Returns(data.Provider);
      moq.As<IQueryable<T>>()
        .Setup(m => m.Expression)
        .Returns(data.Expression);
      moq.As<IQueryable<T>>()
        .Setup(m => m.ElementType)
        .Returns(data.ElementType);
      moq.As<IQueryable<T>>()
        .Setup(m => m.GetEnumerator())
        .Returns(data.GetEnumerator());
      return moq.Object;
    }

    public static BoardGamesDb CreateGamesDb()
    {
      Mock<BoardGamesDb> moq = new();

      DbSet<Game> games = CreateDbSet(Fake.Games);
      moq.Setup(m => m.Games)
        .Returns(games);
      DbSet<Publisher> publishers = CreateDbSet(Fake.Publishers);
      moq.Setup(m => m.Publishers)
        .Returns(publishers);
      return moq.Object;
    }
  }
}
