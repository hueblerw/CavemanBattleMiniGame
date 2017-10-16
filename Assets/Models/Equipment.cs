using System.Collections.Generic;


public class Equipment {

    public string type;
    public string name;
    public double weight;
    public int defenseBonus;
    public int chargeBonus;
    public int extraFlankingBonus;
    public int beingFlankedBonus;

    // Constructor
    public Equipment(string name, string type, double weight, Dictionary<string, int> bonuses)
    {
        this.name = name;
        this.type = type;
        this.weight = weight;
        bonuses.TryGetValue("defenseBonus", out defenseBonus);
        bonuses.TryGetValue("chargeBonus", out chargeBonus);
        bonuses.TryGetValue("extraFlankingBonus", out extraFlankingBonus);
        bonuses.TryGetValue("beingFlankedBonus", out beingFlankedBonus);
    }

}
