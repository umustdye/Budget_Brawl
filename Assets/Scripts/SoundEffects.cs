using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{

    public PlayerController playerController;
    public AudioSource characterAudioPlayer;
    //Fighting Sounds
    [Header("FightingSounds")]
    public AudioClip Blocking_Sound;
    public AudioClip Punch_Impact_Sound;
    public AudioClip Punch_Whoosh_Sound;
    public AudioClip Kick_Whoosh_Sound;
    public AudioClip Kick_Impact_Sound;
    

    //Movement Sounds
    [Header("MovingSounds")]
    public AudioClip Jump_Up_Sound;
    public AudioClip Jump_Down_Sound;
    public AudioClip Jump_Whoosh_Sound;


    void Start()
    {
        playerController = GetComponent<PlayerController>();
        characterAudioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void play_Blocking_Sound()
    {
        characterAudioPlayer.clip = Blocking_Sound;
        characterAudioPlayer.Play();
    }

    public void play_Punch_Impact_Sound()
    {
        characterAudioPlayer.clip = Punch_Impact_Sound;
        characterAudioPlayer.Play();
    }

    public void play_Punch_Whoosh_Sound()
    {
        characterAudioPlayer.clip = Punch_Whoosh_Sound;
        characterAudioPlayer.Play();
    }

    public void play_Kick_Whoosh_Sound()
    {
        characterAudioPlayer.clip = Kick_Whoosh_Sound;
        characterAudioPlayer.Play();
    }

    public void play_Kick_Impact_Sound()
    {
        characterAudioPlayer.clip = Kick_Impact_Sound;
        characterAudioPlayer.Play();
    }


    public void play_Jump_Whoosh_Sound()
    {
        characterAudioPlayer.clip = Jump_Whoosh_Sound;
        characterAudioPlayer.Play();
    }

    public void play_Jumping_Up_Sound()
    {
        characterAudioPlayer.clip = Jump_Up_Sound;
        characterAudioPlayer.Play();
    }

    public void play_Jumping_Down_Sound()
    {
        characterAudioPlayer.clip = Jump_Down_Sound;
        characterAudioPlayer.Play();
    }


}
