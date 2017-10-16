using System.Collections.Generic;


public class Ammo : Equipment {

    public int ammoBonus;

    public Ammo(string name, string type, double weight, Dictionary<string, int> bonuses) : base(name, type, weight, bonuses)
    {
        // Basically need the same constructor as equipment, however make sure a melee type has actually been created
        if (type != "ammo")
        {
            throw new System.Exception("Wrong Equipment Type");
        }
        bonuses.TryGetValue("ammoBonus", out ammoBonus);
    }

}
