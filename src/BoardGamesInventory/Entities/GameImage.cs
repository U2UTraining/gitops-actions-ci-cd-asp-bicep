namespace U2U.BoardGames.Entities;

public class GameImage : EntityBase
{
  public GameImage(int id, string imageLocation) : base(id)
    => this.ImageLocation = imageLocation;

  public string ImageLocation { get; private set; }

  public void SetImageUrl(string url)
    => this.ImageLocation = url;
}
