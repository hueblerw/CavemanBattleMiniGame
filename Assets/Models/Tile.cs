

public class Tile {

    // Constants
    private const double DEFAULT_MOVEMENT_COST = 2.0;

    // Variables
    public Location location;
    public bool forest;
    public bool swamp;
    public bool saturated;
    public bool frozen;
    public double snowCover;
    public int flatness; // - 1 is impassable, 0 - is difficult, 1 - normal
    public double movementCost;

    // Constructor
    public Tile(int x, int y, bool forest, bool swamp, bool saturated, bool frozen, double snowCover, int flatness)
    {
        location = new Location(x, y);
        this.forest = forest;
        this.swamp = swamp;
        this.saturated = saturated;
        this.frozen = frozen;
        this.snowCover = snowCover;
        this.flatness = flatness;
        this.movementCost = calculateMovementCost();
    }

    // Should make a method where anytime a stat is updated the movement cost is recalculated.  Probably means all variables are private.

    // **********  NEEDS THE REAL MATH HERE
    private double calculateMovementCost()
    {
        return DEFAULT_MOVEMENT_COST;
    }

}
