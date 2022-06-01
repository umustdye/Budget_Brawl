using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class changeText : MonoBehaviour
{
    TMP_Text text;
    public PlayerGameInfo playerManager;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void roundOver(){
        text.text = "Round Over";
    }

    public void draw(){
        text.text = "Draw";
    }

    public void win(){
        if(playerManager.player1Win){
            text.text = "Player 1 Wins!";
        }
        else if(playerManager.player2Win){
            text.text = "Player 2 Wins!";
        }
        else{
            draw();
        }
        
    }
}
