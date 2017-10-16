using System.Collections.Generic;


public class Weapon : Equipment {

    public double manpowerMultiplier;
    public int handsUsed;
    public bool firstStrike;

    // Constructor
    public Weapon(string name, string type, double manpowerMultiplier, double weight, int handsUsed, bool firstStrike, Dictionary<string, int> bonuses) : base(name, type, weight, bonuses)
    {
        if (type != "melee" || type != "Ranged")
        {
            throw new System.Exception("Wrong Weapon Type");
        }
        this.manpowerMultiplier = manpowerMultiplier;
        this.handsUsed = handsUsed;
        this.firstStrike = firstStrike;
    }

}
