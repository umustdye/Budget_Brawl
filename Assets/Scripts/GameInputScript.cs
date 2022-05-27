using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInputScript : MonoBehaviour
{
    // Movement
    [Header("Movement Input")]
    public float player_direction = 0;
    public bool sprint = false;
    public bool jump = false;

    // Fighting
    [Header("Fighting")]
    public bool punch = false;
    public bool kick = false;
    public bool block = false;
    public bool special_attack = false;

    // Input Action Message Handlers
    void OnDirection(InputValue val)
    {
        player_direction = val.Get<float>();
        // Debug.Log("player_direction: " + player_direction);
    }

    void OnSprint(InputValue val)
    {
        sprint = val.isPressed;
        // Debug.Log("sprint: " + sprint);
    }

    void OnJump(InputValue val)
    {
        jump = val.isPressed;
        // Debug.Log("jump: " + jump);
    }

    void OnPunch(InputValue val)
    {
        punch = val.isPressed;
        // Debug.Log("punch: " + punch);
    }

    void OnKick(InputValue val)
    {
        kick = val.isPressed;
        // Debug.Log("kick: " + kick);
    }

    void OnBlock(InputValue val)
    {
        block = val.Get<float>() != 0;
        // Debug.Log("block: " + block);
    }

    void OnSpecialAttack(InputValue val)
    {
        special_attack = val.isPressed;
        Debug.Log("special attack: " + special_attack);
    }
}
