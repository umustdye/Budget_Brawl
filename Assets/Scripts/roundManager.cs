using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roundManager : MonoBehaviour
{
    // set it to round manager gameobject
    public GameObject roundTime;
    public GameObject healthSpawner;
    public GameObject specialSpawner;

    private ItemSpawner health;
    private ItemSpawner special;

    public GameObject timeover;
    
    private textAnimation timeoverAnim;
    private roundTimer timer;
    public bool isRoundEnd;
    public int roundNum = 3;

    // Start is called before the first frame update
    void Start()
    {
        health = healthSpawner.GetComponent<ItemSpawner>();
        special = specialSpawner.GetComponent<ItemSpawner>();

        timer = roundTime.GetComponent<roundTimer>();
        timeoverAnim = timeover.GetComponent<textAnimation>();

        initialize();

        isRoundEnd = false;
    }

    void initialize(){
        timer.reset();
    }

    // Update is called once per frame
    void Update()
    {
        // if ready/fight animation ends
        // restart the timer
        if(timeoverAnim.transition.isAnimationEnd){
            timer.restart();
            timeoverAnim.transition.isAnimationEnd = false;
        }
        if(isRoundEnd){
            roundEnd();
        }
    }

    void roundEnd(){
        // pause() the whole game(maybe gameManager?), character movements are stopped
        // after the time over animation, goes to the next round or end the game
        // Debug.Log("Round Ended");
        if(roundNum == 0){
            // end the game and move to the result screen
            Debug.Log("Game Ended");
            return;
        }
        else{
            roundNum--;
        }
        
        // play round ending animation
        // add transition logics:
        //      reset the timer
        //      play time over animation
        //      ready for ready/fight animation
        //      clean items on the stage
        timeoverAnim.setAnimationSeconds(4.0f);
        timeoverAnim.isTimeOver = true;
        timer.reset();

        health.reset();
        health.emptyChild();
        special.reset();
        special.emptyChild();

        isRoundEnd = false;
    }
}
