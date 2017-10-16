using System.Collections.Generic;


public class Unit {

    // Constants
    private const double DEFAULT_SPEED = 2.0;
    private const double PACIFIST_MORALE = 1.4;
    private const int HP_PER_SOLDIER = 4;
    private const double FLEEING_MORALE = 1.0;
    private const double CULTURAL_MORALE_DIVISOR = 20.0;
    private const double XP_MORALE_DIVISOR = 10.0;
    private const double ENCUMBERANCE_DROPOFF = 0.3;
    private const int MAX_UNENCUMBERED_WEIGHT = 10;

    // Variables
    public Leader localCommander;
    public Leader commander;
    public string name;
    public int troops;
    public int wounded;
    public int dead;
    public int HP;
    public int availableHP;
    public double culturalViolence;
    public double morale;
    public double maxMorale;
    private Dictionary<Equipment, int> equipment;
    public int xp;
    public bool fleeing; 

    // Constructors
    public Unit(string name, Leader commander, int troops, int xp, double culturalViolence)
    {
        setupUnit(name, commander, troops, xp, culturalViolence);
    }

    public Unit(string name, Leader commander, Leader localCommander, int troops, int xp, double culturalViolence)
    {
        this.localCommander = localCommander;
        setupUnit(name, commander, troops, xp, culturalViolence);
    }

    // Calculate Battle Stats - **************
    public double calculateAttackValue()
    {
        // Do a bunch of math and return a number
        return 1.0;
    }

    // **************
    public double calculateBonus(bool defending, bool charging, bool flanking, bool flanked)
    {
        // Do a bunch of math based upon the weapons and the situation
        return 0;
    }

    // Take Causualties - **************
    public void takeHPdamage(int damage)
    {
        HP -= damage;
        // Calculate wounded - dead - leaders fallen - morale effect?
    }

    // Morale Effects - **************  MIGHT NEED AN ALERT THAT THE UNIT IS FLEEING TO FIRE???
    public void moraleChange(double moraleChange)
    {
        morale += moraleChange;
        if (morale > FLEEING_MORALE && fleeing)
        {
            fleeing = false;
        }
        else if (morale <= FLEEING_MORALE && !fleeing)
        {
            fleeing = true;
        }
    }

    // Equipment Changes
    public void addEquipment(Equipment item, int number)
    {
        if (equipment.ContainsKey(item))
        {
            equipment[item] += number;
        }
        else
        {
            equipment.Add(item, number);
        }
    }

    public void lostEquipment(Equipment item, int lost)
    {
        equipment[item] -= lost;
        if (equipment[item] <= 0)
        {
            equipment.Remove(item);
        }
    }

    public string printEquipment()
    {
        string manifest = "";
        foreach(var item in equipment)
        {
            manifest += item.Key.name + ": " + item.Value + "\n";
        }
        return manifest;
    }

    public double getSpeed()
    {
        // less than (10 + xp) lbs. per soldier has no effect on default speed.
        // Each subsequent multiplication of weight reduces speed by ENCUMBERANCE_DROPOFF
        int baseCarryingCapacity = MAX_UNENCUMBERED_WEIGHT + xp;
        double encumberance = calculateEncumberance();
        if (encumberance > baseCarryingCapacity)
        {
            double multiplier = encumberance / baseCarryingCapacity - 1.0;
            return (DEFAULT_SPEED - (multiplier * ENCUMBERANCE_DROPOFF));
        }
        else
        {
            return DEFAULT_SPEED;
        }
    }

    // battleEnd
    public void battleOver()
    {
        xp++;
        calculateMaxMorale();
    }

    public string printUnitStats()
    {
        string roster = "Unit Name: " + name + "\n";
        roster += "Overall Commander: " + commander;
        if (localCommander != null)
        {
            roster += "\tLocal Commander: " + localCommander;
        }
        roster += "\ntroops: " + troops + "\twounded: " + wounded + "\tkilled: " + dead + "\n";
        roster += "morale: " + morale + " / " + maxMorale + "\tXP: " + xp + "\n";
        roster += "Equipment: \n";
        roster += printEquipment();
        return roster;
    }

    // Privates
    private double calculateMaxMorale()
    {
        return PACIFIST_MORALE + (culturalViolence / CULTURAL_MORALE_DIVISOR) + (xp / XP_MORALE_DIVISOR);
    }

    private int calculateHP()
    {
        return troops * HP_PER_SOLDIER;
    }

    private int getFightingTroops()
    {
        return troops - wounded - dead;
    }

    private double calculateEncumberance()
    {
        // this is the averge weight the unit is carrying
        double totalWeight = 0.0;
        foreach (var weapon in equipment)
        {
            totalWeight += (weapon.Key.weight * weapon.Value);
        }
        return (totalWeight / getFightingTroops());
    }

    private void setupUnit(string name, Leader commander, int troops, int xp, double culturalViolence)
    {
        this.name = name;
        this.commander = commander;
        this.troops = troops;
        HP = calculateHP();
        availableHP = HP;
        this.culturalViolence = culturalViolence;
        this.xp = xp;
        maxMorale = calculateMaxMorale();
        morale = maxMorale;
        equipment = new Dictionary<Equipment, int>();
        fleeing = false;
    }

}
