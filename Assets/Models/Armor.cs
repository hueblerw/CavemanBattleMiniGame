using System.Collections.Generic;


public class Armor : Equipment {

    public int opponentAttackPenalty;

    public Armor(string name, string type, double weight, int opponentAttackPenalty, Dictionary<string, int> bonuses) : base(name, type, weight, bonuses)
    {
        // Basically need the same constructor as equipment, however make sure a melee type has actually been created
        if (type != "armor")
        {
            throw new System.Exception("Wrong Equipment Type");
        }
        this.opponentAttackPenalty = opponentAttackPenalty;
    }

}
