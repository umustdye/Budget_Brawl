using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roundTimer : MonoBehaviour
{
    // set it to round manager gameobject
    public GameObject roundManager;
    private roundManager manager;

    private float roundTime;
    // change maxTime will actually change the round time
    public float maxTime = 180.0f;
    // set it to textUI timertext
    public Text timerText;
    private bool isRunning;
    // Start is called before the first frame update
    void Start()
    {
        manager = roundManager.GetComponent<roundManager>();
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
            manager.setRoundEnd(true);
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

    public bool isTimerRunning(){
        return isRunning;
    }

    public void displayTime(){
        timerText.text = string.Format("{0:00}:{1:00}", getMinutes(), getSeconds());
    }
}
