using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class roundTimer : MonoBehaviour
{
    // set it to round manager gameobject
    public GameObject roundManager;
    private roundManager manager;

    private float roundTime;
    // change maxTime will actually change the round time
    public float maxTime = 180.0f;
    // set it to textUI timertext
    public TMP_Text timerText;
    private bool isRunning;
    // Start is called before the first frame update
    void Start()
    {
        manager = roundManager.GetComponent<roundManager>();
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
            // add effects when roundTime has 10/3 seconds left
            if((int)roundTime <= 10){
                if((int)roundTime % 2 == 0){
                    // Debug.Log("red");
                    timerText.color = new Color(255, 134, 0, 255);
                }
                else{
                    timerText.color = Color.white;
                }
            }
        }
        else{
            manager.isRoundEnd = true;
            roundTime = 0;
            isRunning = false;
        }
        
    }

    public void restart(){
        isRunning = true;
    }

    public void reset(){
        timerText.color = Color.white;
        roundTime = maxTime;
        displayTime();
    }

    int getMinutes(){
        return (int)(roundTime / 60);
    }

    int getSeconds(){
        return (int)(roundTime % 60);
    }

    public void stop(){
        isRunning = false;
    }

    public bool isTimerRunning(){
        return isRunning;
    }

    public void displayTime(){
        timerText.text = string.Format("{0:00}:{1:00}", getMinutes(), getSeconds());
    }
}
