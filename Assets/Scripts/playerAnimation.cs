using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    Animator animator;
    Direction dir;
    // Start is called before the first frame update
    // animator parameters: may be optimized later
    //      whenPunchPressed -> button interaction
    //      whenKickPressed -> button interaction
    //      whenForwardPressed -> button interaction
    //      whenBackwardPressed -> button interaction
    //      whenDefeated -> occurs when player is defeated/health becomes 0/hit by smash attack
    //      respawn -> occurs when round starts again/when player tries to get up
    //      whenSmashed -> occurs when player is damaged enough to get down
    //      whenFlinched -> occurs when player is "hit" by attacks
    void Start()
    {
        dir = Direction.RIGHT;
        animator = GetComponent<Animator>();
        animator.SetBool("onFight", true);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("whenPunchPressed", false);
        animator.SetBool("whenKickPressed", false);
        // press FORWARD
        if(Input.GetKeyDown(KeyCode.G)){
            dir = Direction.RIGHT;
            decideDirection();
            animator.SetBool("whenForwardPressed", true);
        }
        else if(Input.GetKeyUp(KeyCode.G)){
            animator.SetBool("whenForwardPressed", false);
        }
        /* For backward movement only */
        if(Input.GetKeyDown(KeyCode.D)){
            dir = Direction.LEFT;
            decideDirection();
            animator.SetBool("whenBackwardPressed", true);
        }
        else if(Input.GetKeyUp(KeyCode.D)){
            animator.SetBool("whenBackwardPressed", false);
        }

        // maybe change to InputManager-related conditional statements GetButton()
        if(Input.GetKeyUp(KeyCode.A)){
            animator.SetBool("whenPunchPressed", true);
        }
        if(Input.GetKeyUp(KeyCode.S)){
            animator.SetBool("whenKickPressed", true);
        }
    }

    void decideDirection(){
        if(dir == Direction.RIGHT){
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 1);
        }
        else{
            gameObject.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }
    }
}

