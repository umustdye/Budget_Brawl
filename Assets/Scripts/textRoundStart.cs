using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textRoundStart : MonoBehaviour
{
    TMP_Text text;
    float speed = 30.0f;
    float animationSeconds = 0.5f;

    public bool isEnter = true;
    public bool isAnimationEnd = false;
    bool isExit = false;
    bool isReady = true;
    bool isWait = false;

    float waitTime = 1.5f;
    float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        disappear();
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnter){
            appear(Time.deltaTime);
        }

        if(isExit){
            exit(Time.deltaTime);
        }

        // wait timer after the text arrives in the middle of the screen
        // applies to both ready and fight
        if(isWait){
            if(timer >= waitTime){
                isWait = false;
                timer = 0.0f;
                isExit = true;
            }
            else{
                timer += Time.deltaTime;
            }
        }
        else{

        }
    }

    // reset the position of text to out of the screen to the right
    public void disappear(){
        transform.localPosition = new Vector3(1350, 40, 0);
        speed = transform.localPosition.x / animationSeconds;
    }

    // text moves from right to left
    // stop when the text reaches middle of the screen
    public void appear(float time){
        if(transform.localPosition.x > 0){
            Vector3 speedVec = new Vector3(-speed, 0, 0);
            transform.Translate(speedVec * time);
        }
        else{
            isEnter = false;
            isWait = true;
        }   
    }

    // text moves from right to left
    // starts in the middle of the screen, and exits to the left side of the screen
    public void exit(float time){
        if(transform.localPosition.x > -1350){
            Vector3 speedVec = new Vector3(-speed, 0, 0);
            transform.Translate(speedVec * time);
        }
        else{
            isExit = false;
            if(isReady){
                fight();
                isEnter = true;
                isReady = false;
            }
            else{
                ready();
                isReady = true;
                // changes back to Ready and disappear
                // animation ends here
                isAnimationEnd = true;
            }
            disappear();
        }  
    }

    public void ready(){
        text.text = "Ready";
    }

    public void fight(){
        text.text = "Fight!";
    }
}
