using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameInfo : MonoBehaviour
{
    //TODO: restructure for more than 2 players --> use List or array and add as much health bar as we want
    //TODO: make max health character specific rather than hard coded --> attribute can be stored in the player prefabs?
    //TODO: add integration for player lives/stocks
    //TODO: potentially add integration for roundtime/ number of rounds
    //TODO: link with blast/death animation

    public GameObject player1;
    public GameObject player2;

    private linkPlayerHealth p1Health;
    private linkPlayerHealth p2Health;

    public int player1Lives = 3;
    public int player2Lives = 3;

    public int roundTime;

    public bool timeOut = false;
    public bool player1Win = false;
    public bool player2Win = false;
    public bool player1Dead = false;
    public bool player2Dead = false;

    public 

    // Start is called before the first frame update
    void Start()
    {
        // after implementing map select and transition between round and menu
        // we have to dynamically add players to generalize certain logics we have right now
        // can easily be shortend by having a designated player list
        p1Health = player1.GetComponent<linkPlayerHealth>();
        p2Health = player2.GetComponent<linkPlayerHealth>();

        p1Health.refillFull();
        p2Health.refillFull();

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
        if (p1Health.getHP() <= 0)
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
        else if (p2Health.getHP() <= 0)
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
