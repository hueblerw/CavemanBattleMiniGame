using System.Collections.Generic;
using UnityEngine;


public class GameSetupController : MonoBehaviour {

    List<Player> players;
    Battle gameBattle;


	// Use this for initialization
	void Start () {
        generateNewPlayers();
        generateRandomBattlefield();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void generateNewPlayers()
    {
        players.Add(new Player(generateRandomLeader("Nutwyp")));
        players.Add(new Player(generateRandomLeader("Gerald")));
    }

    private Leader generateRandomLeader(string name)
    {
        int adm = Random.Range(1, 12);
        int mil = Random.Range(1, 12);
        int cha = Random.Range(1, 12);
        return new Leader(name, adm, mil, cha, 0);
    }

    private void generateRandomBattlefield()
    {
        gameBattle = new Battle(players);
    }
}
