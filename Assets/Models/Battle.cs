using System.Collections.Generic;


public class Battle {

    private const int DEFAULT_BATTLEFIELD_SIZE = 20;

    public Tile[,] battlefield;
    public List<Player> players;
    public string battlePhase;
    public Dictionary<Location, List<Equipment>> battlefieldTreasure;

    // Constructors
    public Battle(Player player1, Player player2)
    {
        players.Add(player1);
        players.Add(player2);
        initiailizeBattle();
    }

    public Battle(List<Player> players)
    {
        this.players = players;
        initiailizeBattle();
    }

    private void initiailizeBattle()
    {
        battlePhase = "Setup";
        battlefieldTreasure = new Dictionary<Location, List<Equipment>>();
        battlefield = new Tile[DEFAULT_BATTLEFIELD_SIZE, DEFAULT_BATTLEFIELD_SIZE];
        for (int x = 0; x < DEFAULT_BATTLEFIELD_SIZE; x++)
        {
            for (int y = 0; y < DEFAULT_BATTLEFIELD_SIZE; y++)
            {
                // ********************  NEED TO BUILD A RANDOM WORLD OR PASS IN ONE FROM FILE
                battlefield[x, y] = new Tile(x, y, false, false, false, false, 0.0, 1);
            }
        }
    }

}
