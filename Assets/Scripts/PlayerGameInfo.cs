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
    public List<GameObject> Players;

    public HealthBar player1HealthBar;
    public HealthBar player2HealthBar;
    public int player1Health = 10000;
    public int player2Health = 10000;

    public int player1Lives = 3;
    public int player2Lives = 3;

    public int roundTime;

    public bool timeOut = false;
    public bool player1Win = false;
    public bool player2Win = false;
    public bool player1Dead = false;
    public bool player2Dead = false;
    public BlastZoneBounds safe_zone;

    // Start is called before the first frame update
    void Start()
    {
        player1Health = 10000;
        player2Health = 10000;

        player1HealthBar.SetMaxHealth(player1Health);
        player2HealthBar.SetMaxHealth(player2Health);

        player1Lives = 3;
        player2Lives = 3;
        player1Win = false;
        player2Win = false;
        player1Dead = false;
        player2Dead = false;

    }

    // Update is called once per frame
    void Update()
    {
        
       // if (!safe_zone.blastZoneBounds.Contains(Players[i]))
        player1HealthBar.SetHealth(player1Health);
        player2HealthBar.SetHealth(player2Health);

        if (player1Health <= 0)
        {
            player1Dead = true;

            if (player1Lives <= 0)
            {
                player2Win = true;
            }
            else
            {
                //Respawn player 1
            }
        }
        else if (player2Health <= 0)
        {
            player2Dead = true;

            if (player1Lives <= 0)
            {
                player1Win = true;
            }
            else
            {
                //Respawn player 2
            }
        }
    }
}
