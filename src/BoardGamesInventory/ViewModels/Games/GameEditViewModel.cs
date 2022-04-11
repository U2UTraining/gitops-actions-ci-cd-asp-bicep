namespace BoardGamesInventory.ViewModels.Games
{
  public class GameEditViewModel
  {
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int PublisherId { get; set; }

    public IEnumerable<Publisher> Publishers { get; set; } = default!;
  }
}
