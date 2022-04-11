namespace U2U.BoardGames.Entities;

public class Publisher : EntityBase
{
  /// <summary>
  /// Ctor for use by EF Core
  /// </summary>
  /// <param name="id">id</param>
  /// <param name="name">name</param>
  public Publisher(int id, string name) : base(id)
    => Name = name;

  public string Name { get; private set; } = default!;

  private List<Game>? games;

  public IEnumerable<Game> Games => GetGamesList();

  private List<Game> GetGamesList()
    => this.games ??= new List<Game>();

  internal void AddGame(Game g)
    => GetGamesList().Add(g);

  internal void RemoveGame(Game g)
    => GetGamesList().Remove(g);

  public Game CreateGame(string name, int id = 0)
    => new Game(id, name, this);
}