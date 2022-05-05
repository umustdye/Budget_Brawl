using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    // Components
    private GameInputScript input;
    private PlayerController controller;
    public AudioSource fightingAudioPlayer;

    // Fighting
    [Header("Fighting")]
    public bool is_blocking = false;
    public bool is_punching = false;
    public bool is_kicking = false;
    public float punch_time = 1.733f;
    public float kick_time = 1.3f;
    private float punch_delta = 0;
    private float kick_delta = 0;

    //Fighting Sounds
    [Header("FightingSounds")]
    public AudioClip Blocking_Sound;
    public AudioClip Punch_Impact_Sound;
    public AudioClip Punch_Whoosh_Sound;
    public AudioClip Kick_Whoosh_Sound;
    public AudioClip Kick_Impact_Sound;
    public AudioClip Jump_Whoosh_Sound;


    public void play_Blocking_Sound()
    {
        fightingAudioPlayer.clip = Blocking_Sound;
        fightingAudioPlayer.Play();
    }

    public void play_Punch_Impact_Sound() {
        fightingAudioPlayer.clip = Punch_Impact_Sound;
        fightingAudioPlayer.Play();
    }

    public void play_Punch_Whoosh_Sound()
    {
        fightingAudioPlayer.clip = Punch_Whoosh_Sound;
        fightingAudioPlayer.Play();
    }

    public void play_Kick_Whoosh_Sound()
    {
        fightingAudioPlayer.clip = Kick_Whoosh_Sound;
        fightingAudioPlayer.Play();
    }

    public void play_Kick_Impact_Sound()
    {
        fightingAudioPlayer.clip = Kick_Impact_Sound;
        fightingAudioPlayer.Play();
    }


    public void play_Jump_Whoosh_Sound()
    {
        fightingAudioPlayer.clip = Jump_Whoosh_Sound;
        fightingAudioPlayer.Play();
    }



    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<GameInputScript>();
        controller = GetComponent<PlayerController>();
        fightingAudioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCombatState();
    }

    void UpdateCombatState()
    {
        // State timers
        if(is_punching)
        {
            punch_delta += Time.deltaTime;
            if(punch_delta >= punch_time) 
            {
                punch_delta = 0;
                is_punching = false;
            }
        }

        if(is_kicking)
        {
            kick_delta += Time.deltaTime;
            if(kick_delta >= kick_time) 
            {
                kick_delta = 0;
                is_kicking = false;
            }
        }

        // Input
        is_blocking = input.block && controller.is_touching_ground && !(is_punching || is_kicking);
        if(input.punch)
        {
            is_punching = !(is_blocking || is_kicking);
            input.punch = false;
        }
        if(input.kick)
        {
            is_kicking = !(is_blocking || is_punching);
            input.kick = false;
        }
    }
}
