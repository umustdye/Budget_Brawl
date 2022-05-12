using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Animations : MonoBehaviour
{
    //animation object
    private Animator playerAnimation;
    //check input bools
    private PlayerController playerController;
    //check combat/attack bools
    private CombatScript attack;
    //Audio Source
    public AudioSource movementAudioPlayer;


    //Movement Sounds
    [Header("FightingSounds")]
    public AudioClip Jump_Up_Sound;
    public AudioClip Jump_Down_Sound;

    [SerializeField] private float _inactiveTimerMax = 6; //six seconds
    float time = 0.0f;
    float velocity = 0.0f;
    public float acceleration = .8f;
    public float deceleration = 1.2f;

    void Start()
    {
        playerAnimation = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        attack = GetComponent<CombatScript>();
        movementAudioPlayer = GetComponent<AudioSource>();
        playerAnimation.SetBool("isWalking", playerController.is_walking);
        playerAnimation.SetBool("isSprinting", playerController.is_sprinting);
        playerAnimation.SetBool("isIdle", playerController.is_idle);
        playerAnimation.SetBool("jumpPressed", playerController.is_jumping);
        playerAnimation.SetBool("jumpFreefall", playerController.is_falling);
        playerAnimation.SetBool("jumpGround", playerController.is_touching_ground);
        playerAnimation.SetFloat("speed", velocity);
        playerAnimation.SetFloat("inactiveTimer", time);
        playerAnimation.SetBool("isBlocking", attack.is_blocking);
        playerAnimation.SetBool("isPunching", attack.is_punching);
        playerAnimation.SetBool("isKicking", attack.is_kicking); 
    }


    void SpeedUp()
    {
        velocity += Time.deltaTime * acceleration;
        if(velocity > 1.0f)
            velocity = 1.0f;
    }

    void SlowDown()
    {
        velocity -= Time.deltaTime * deceleration;
        if(velocity < 0.1f)
            velocity = 0.1f;
    }

    //movement with running implementation
    void LeftandRightSpeed()
    {
        //Debug.Log("left: " + left); // We hate the left

        //kitty cat proof for trying to move in two directions at once
        if(playerController.is_idle)
        {
            velocity = 0.0f;
            time += Time.deltaTime;
            if(time > _inactiveTimerMax)
            {
                time = _inactiveTimerMax;
            }
        }

        else if(!playerController.is_idle)
        {
            time = 0.0f;
        }

        //Walking animation
        if(playerController.is_walking)
        {
            //Check if running to set walking/running animations
            //SlowDown();
            velocity = 0.0f;
     
        }

        //Right Movement
        else if(playerController.is_sprinting)
        {
            //Check if running to set walking/running animations
            SpeedUp();
        }



        //set animation for running/walking/idle
        playerAnimation.SetFloat("speed", velocity);
        playerAnimation.SetFloat("inactiveTimer", time);
        playerAnimation.SetBool("isWalking", playerController.is_walking);
        playerAnimation.SetBool("isSprinting", playerController.is_sprinting);
        playerAnimation.SetBool("isIdle", playerController.is_idle);

    }


    void Jumping()
    {
        playerAnimation.SetBool("jumpPressed", playerController.is_jumping);
        playerAnimation.SetBool("jumpFreefall", playerController.is_falling);
        playerAnimation.SetBool("jumpGround", playerController.is_touching_ground);
    }

    void Attack()
    {
        playerAnimation.SetBool("isBlocking", attack.is_blocking);
        playerAnimation.SetBool("isPunching", attack.is_punching);
        playerAnimation.SetBool("isKicking", attack.is_kicking); 
        Debug.Log("Block: " + attack.is_blocking);
        Debug.Log("Punch: " + attack.is_punching);
        Debug.Log("Kick: " + attack.is_kicking);
    }

    void Update()
    {
        LeftandRightSpeed();
        Jumping();
        Attack();
    }

    public void play_Jumping_Up_Sound()
    {
        movementAudioPlayer.clip = Jump_Up_Sound;
        movementAudioPlayer.Play();
    }

    public void play_Jumping_Down_Sound()
    {
        
        movementAudioPlayer.clip = Jump_Down_Sound;
        movementAudioPlayer.Play();
    }
}
