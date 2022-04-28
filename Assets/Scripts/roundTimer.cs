using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roundTimer : MonoBehaviour
{
    private float roundTime;
    // change maxTime will actually change the round time
    public float maxTime = 180.0f;
    public Text timerText;
    private bool isRunning;
    // Start is called before the first frame update
    void Start()
    {
        restart();
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning){
            decrementTimer();
            // Debug.Log(getMinutes() + " : " + getSeconds());
            displayTime();
        }
    }

    void decrementTimer(){
        if(roundTime > 0){
            roundTime -= Time.deltaTime;
        }
        else{
            // round ends, no logic yet
            roundTime = 0;
            isRunning = false;
        }
        
    }

    public void restart(){
        isRunning = true;
        roundTime = maxTime;
    }

    int getMinutes(){
        return (int)(roundTime / 60);
    }

    int getSeconds(){
        return (int)(roundTime % 60);
    }

    public void displayTime(){
        timerText.text = string.Format("{0:00}:{1:00}", getMinutes(), getSeconds());
    }
}