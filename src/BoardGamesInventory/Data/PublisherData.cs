namespace U2U.BoardGames.Data;

public class PublisherData : IEntityTypeData<Publisher>
{
  public void HasData(EntityTypeBuilder<Publisher> publisher) 
    => publisher.HasData(Publishers._999Games, Publishers._Goliath, Publishers._DaysOfWonder);
}
