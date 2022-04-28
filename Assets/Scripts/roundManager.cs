using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roundManager : MonoBehaviour
{
    public GameObject roundTime;
    public Text timeoverText;

    private roundTimer timer;
    private bool isRoundEnd;
    private bool isAnimationRunning;
    private int roundNum = 3;

    private float animationSpeed = 0.3f;
    private string end = "TIME OVER";
    private float animationTimer = 0.0f;
    private int index = 0;
    private string placeholder = "";
    // Start is called before the first frame update
    void Start()
    {
        timer = roundTime.GetComponent<roundTimer>();
        isRoundEnd = false;
        isAnimationRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isRoundEnd){
            roundEnd();
        }

        if(isAnimationRunning){
            animateTimeOver();
        }
    }

    public void setRoundEnd(){
        isRoundEnd = true;
    }

    void roundEnd(){
        // when the timer runs out, this function is called once
        if(!timer.isTimerRunning()){
            // pause() the whole game(maybe gameManager?), character movements are stopped
            Debug.Log("Game Paused");
            // play round ending animation
            isAnimationRunning = true;
        }

        isRoundEnd = false;
    }

    void animateTimeOver(){
        if(index == end.Length){
            isAnimationRunning = false;
            index = 0;
            animationTimer = 0;
        }

        if(animationTimer > animationSpeed){
            placeholder += end[index];
            timeoverText.text = placeholder;
            index++;
            animationTimer = 0.0f;
        }
        animationTimer += Time.deltaTime;
    }
}
