using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roundManager : MonoBehaviour
{
    // set it to round manager gameobject
    public GameObject roundTime;
    // automatically set it to its child
    public Text timeoverText;

    private roundTimer timer;
    private bool isRoundEnd;
    private bool isAnimationRunning;
    private bool transitionToNextRound;
    private bool waitForTransition;
    public int roundNum = 3;

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
        transitionToNextRound = false;
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

        if(waitForTransition){
            waitTransition();
        }

        if(transitionToNextRound){
            roundTransition();
        }
    }

    public void setRoundEnd(bool state){
        isRoundEnd = state;
    }

    void roundTransition(){
        // transition animations? another waiting time, dispose "TIME OVER"
        // respawn and position all characters
        // restart the timer
        placeholder = "";
        waitForTransition = false;

        timer.restart();
        transitionToNextRound = false;
    }

    void roundEnd(){
        // when the timer runs out, this function is called once
        if(!timer.isTimerRunning()){
            // pause() the whole game(maybe gameManager?), character movements are stopped
            // after the time over animation, goes to the next round or end the game
            Debug.Log("Round Ended");
            if(roundNum == 0){
                // end the game and move to the result screen
                Debug.Log("Game Ended");
                return;
            }
            else{
                roundNum--;
            }
            
            // play round ending animation
            isAnimationRunning = true;
        }

        setRoundEnd(false);
    }

    void animateTimeOver(){
        // when all words are printed on the screen
        if(index >= end.Length){
            // stop the animation
            isAnimationRunning = false;
            // transition to the next round, but have to wait for seconds
            waitForTransition = true;
            // reset the index: pointer to word position, and animationTimer: time that waits to print an alphabet
            index = 0;
            animationTimer = 0;
            return;
        }
        // when timer exceeds animationSpeed
        if(animationTimer > animationSpeed){
            // add character to placeholder
            placeholder += end[index];
            // print the string on the placeholder: substring of end="TIME OVER"
            timeoverText.text = placeholder;
            // increment index
            index++;
            //reset animation Timer
            animationTimer = 0.0f;
        }
        // add time
        animationTimer += Time.deltaTime;
    }

    float maxSeconds;
    float currTimer = 0.0f;
    bool waitEnd;
    // reset the wait timer and set the maximum time to wait
    void setWaitTime(float seconds){
        waitEnd = false;
        maxSeconds = seconds;
    }
    // run until desgnated time is reached, when timer runs out assert waitEnd to signal
    void waitTime(){
        if(currTimer < maxSeconds){
            currTimer += Time.deltaTime;
        }
        else{
            currTimer = 0.0f;
            waitEnd = true;
        }
    }
    // set wait time of 9 seconds, wait; then, transition to the next round
    void waitTransition(){
        setWaitTime(9);
        waitTime();
        if(waitEnd){
            transitionToNextRound = true;
            waitEnd = false;
        }
        else{
            if(currTimer < 4){
                timeoverText.text = placeholder;
            }
            else if(4 <= currTimer && currTimer < 6){
                timeoverText.text = "READY!";
            }
            else if(6 <= currTimer && currTimer < 8){
                timeoverText.text = "FIGHT!";
            }
            else{
                timeoverText.text = "";
            }
        }
    }
}
