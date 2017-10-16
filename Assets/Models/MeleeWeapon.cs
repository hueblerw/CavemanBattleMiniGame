using System.Collections.Generic;


public class MeleeWeapon : Weapon {

    public MeleeWeapon(string name, string type, double manpowerMultiplier, double weight, int handsUsed, bool firstStrike, Dictionary<string, int> bonuses) : base(name, type, manpowerMultiplier, weight, handsUsed, firstStrike, bonuses)
    {
        // Basically need the same constructor as weapons, however make sure a melee type has actually been created
        if (type != "melee")
        {
            throw new System.Exception("Wrong Weapon Type");
        }
    }

}
