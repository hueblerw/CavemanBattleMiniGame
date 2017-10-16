

public class Leader {

    public string name;
    public int status; // -1 dead, 0 wounded, 1 alive and kicking
    public int administration;
    public int charisma;
    public int military;
    public int battlesFought;

    // Constructors
    public Leader(string name, int administration, int charisma, int military, int battlesFought)
    {
        this.name = name;
        status = 1;
        this.administration = administration;
        this.charisma = charisma;
        this.military = military;
        this.battlesFought = battlesFought;
    }

    public void woundLeader()
    {
        status = 0;
    }

    public void killLeader()
    {
        status = -1;
    }

    public void recoverFromWounds()
    {
        status = -1;
    }

    public void battleOver()
    {
        battlesFought++;
        if (battlesFought % 2 == 0)
        {
            military++;
        }
    }

}
