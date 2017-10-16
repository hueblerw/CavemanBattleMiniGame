using UnityEngine;


public class Location {

    public static int X, Y;
    public Vector2 position;

    // Constructors
    public Location(int x, int y)
    {
        position = new Vector2(x, y);
    }

    public static void setMaxMapSize(int MaxX, int MaxY)
    {
        X = MaxX;
        Y = MaxY;
    }

}
