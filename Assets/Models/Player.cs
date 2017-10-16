using System.Collections.Generic;


public class Player {

    public Leader commander;
    public List<Unit> units;

    // Constructor
    public Player(Leader commander)
    {
        this.commander = commander;
    }

}
