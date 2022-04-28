using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundManager : MonoBehaviour
{
    public GameObject roundTime;
    private roundTimer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = roundTime.GetComponent<roundTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void roundEnd(){
        // when the timer runs out
        if(!timer.isTimerRunning()){
            // play round ending animation

            
        }
    }
}
