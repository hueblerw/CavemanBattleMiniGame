using System.Collections.Generic;


public class RangedWeapon : Weapon {

    public int range;
    public List<Ammo> validAmmos;

    public RangedWeapon(string name, string type, double manpowerMultiplier, double weight, int handsUsed, bool firstStrike, int range, Dictionary<string, int> bonuses, List<Ammo> validAmmos) : base(name, type, manpowerMultiplier, weight, handsUsed, firstStrike, bonuses)
    {
        // Basically need the same constructor as weapons, however make sure a melee type has actually been created
        if (type != "ranged")
        {
            throw new System.Exception("Wrong Weapon Type");
        }

        this.range = range;
        this.validAmmos = validAmmos;
    }

    // METHODS
    public bool isValidAmmo(Ammo ammo)
    {
        return validAmmos.Contains(ammo);
    }

}

