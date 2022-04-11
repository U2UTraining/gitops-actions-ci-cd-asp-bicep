﻿namespace BoardGamesInventory.ViewModels.Games
{
  public class GameDetailViewModel
  {
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Publisher { get; set; } = string.Empty;
  }
}
