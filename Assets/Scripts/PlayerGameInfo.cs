using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameInfo : MonoBehaviour
{
    //TODO: restructure for more than 2 players
    //TODO: make max health character specific rather than hard coded
    //TODO: add integration for player lives/stocks
    //TODO: potentially add integration for roundtime/ number of rounds
    //TODO: link with blast/death animation

    public HealthBar player1HealthBar;
    public HealthBar player2HealthBar;
    public int player1Health;
    public int player2Health;

    public int player1Lives = 3;
    public int player2Lives = 3;

    public int roundTime;

    public bool timeOut = false;

    public 

    // Start is called before the first frame update
    void Start()
    {
        player1Health = 10000;
        player2Health = 10000;
        player1HealthBar.SetMaxHealth(player1Health);
        player2HealthBar.SetMaxHealth(player2Health);

        player1Lives = 3;
        player2Lives = 3;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
