using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stonks : MonoBehaviour
{
    
    public void MarketOpen()
    {
        for (int i = 0; i < PlayerGameInfo.playerLives; ++i)
        {
            Transform child = gameObject.transform.GetChild(i);
            // Debug.Log("Child Name: " + child.name);
            child.gameObject.SetActive(true);
        }
    }
    public void minusOneStock(ref int playerLives)
    {
        if (playerLives > 0)
        {
            Transform lostStock = gameObject.transform.GetChild(--playerLives);
            lostStock.gameObject.SetActive(false);
        }
    }
}
