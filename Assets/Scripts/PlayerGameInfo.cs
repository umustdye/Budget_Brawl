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
    public Stonks player1Stocks;
    public Stonks player2Stocks;
    public int player1Health = 10000;
    public int player2Health = 10000;

    public static int playerLives = 4;
    public int player1Lives;
    public int player2Lives;

    public int roundTime;

    public bool timeOut = false;
    public bool player1Win = false;
    public bool player2Win = false;
    public bool player1Dead = false;
    public bool player2Dead = false;

    // Start is called before the first frame update
    void Start()
    {
        player1Health = 10000;
        player2Health = 10000;
        player1HealthBar.SetMaxHealth(player1Health);
        player2HealthBar.SetMaxHealth(player2Health);

        player1Lives = playerLives;
        player2Lives = playerLives;
        player1Win = false;
        player2Win = false;
        player1Dead = false;
        player2Dead = false;

        player1Stocks.MarketOpen();
        player2Stocks.MarketOpen();
        player1Lives = playerLives;
        player2Lives = playerLives;

    }

    // Update is called once per frame
    void Update()
    {

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
