using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlayer : MonoBehaviour
{
    // respawn point
    public Vector3 p1;
    public Vector3 p2;

    public GameObject blue;
    public GameObject red;

    public HealthBar left;
    public HealthBar right;

    public PlayerGameInfo gameInfo;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player1;
        GameObject player2;

        if(PlayerPrefs.GetInt("Player1") == 0){
            player1 = Instantiate(blue, p1, Quaternion.Euler(new Vector3(0, 90, 0)));
        }
        else{
            player1 = Instantiate(red, p1, Quaternion.Euler(new Vector3(0, 90, 0)));
        }

        if(PlayerPrefs.GetInt("Player2") == 0){
            player2 = Instantiate(blue, p2, Quaternion.Euler(new Vector3(0, -90, 0)));
        }
        else{
            player2 = Instantiate(red, p2, Quaternion.Euler(new Vector3(0, -90, 0)));
        }

        // initialize related to players here
        GameObject[] players = {player1, player2};

        gameInfo = gameObject.GetComponent<PlayerGameInfo>();
        
        player1.GetComponent<linkPlayerHealth>().initializeHealthBar(left, gameInfo.player1Stocks, gameInfo.player1Lives);
        player2.GetComponent<linkPlayerHealth>().initializeHealthBar(right, gameInfo.player2Stocks, gameInfo.player2Lives);
        gameInfo.initializePlayer(players);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
