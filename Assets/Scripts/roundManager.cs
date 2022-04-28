using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundManager : MonoBehaviour
{
    public GameObject roundTime;
    private roundTimer timer;
    private bool isRoundEnd;
    // Start is called before the first frame update
    void Start()
    {
        timer = roundTime.GetComponent<roundTimer>();
        isRoundEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isRoundEnd){
            roundEnd();
        }
    }

    public void setRoundEnd(){
        isRoundEnd = true;
    }

    void roundEnd(){
        // when the timer runs out, this function is called once
        if(!timer.isTimerRunning()){
            // pause the whole game, character movements are stopped
            
            // play round ending animation

        }
        isRoundEnd = false;
    }
}
