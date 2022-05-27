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

    public GameObject roundStart;
    public GameObject timeover;
    
    private textParent roundStartAnim;
    private textParent timeoverAnim;
    private roundTimer timer;
    public bool isRoundEnd;
    public int roundNum = 3;

    // Start is called before the first frame update
    void Start()
    {
        // initialize scripts
        health = healthSpawner.GetComponent<ItemSpawner>();
        special = specialSpawner.GetComponent<ItemSpawner>();

        timer = roundTime.GetComponent<roundTimer>();
        roundStartAnim = roundStart.GetComponent<textRoundStart>();
        timeoverAnim = timeover.GetComponent<textAnimation>();

        // reset the timer to round time
        timer.reset();

        isRoundEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if ready/fight animation ends
        // restart the timer
        if(roundStartAnim.isAnimationEnd){
            // ACTIONS: when round starts
            timer.restart();
            health.restart();
            special.restart();
            roundStartAnim.isAnimationEnd = false;
        }
        if(isRoundEnd){
            roundEnd();
        }
    }

    void roundEnd(){
        // pause() the whole game(maybe gameManager?), character movements are stopped
        // after the time over animation, goes to the next round or end the game
        if(roundNum > 0){
            roundNum--;
        }
        if(roundNum <= 0){
            // end the game and move to the result screen
            Debug.Log("Game Ended");
            isRoundEnd = false;

            return;
        }
        
        // ACTIONS: when round ends
        // add transition logics:
        //      reset the timer
        //      play time over animation
        //      ready for ready/fight animation
        //      clean items on the stage
        timeoverAnim.setAnimationSeconds(4.0f);
        timeoverAnim.isAnimationEnd = false;
        timeoverAnim.isEnter = true;
        timer.reset();

        health.reset();
        health.emptyChild();
        special.reset();
        special.emptyChild();

        isRoundEnd = false;
    }
}
