using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStonks : MonoBehaviour
{

    public PlayerGameInfo playerGameInfo;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // Tests the functionality of minusOneStock()
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            playerGameInfo.player1Stocks.minusOneStock(ref playerGameInfo.player1Lives);
        }
    }
}
