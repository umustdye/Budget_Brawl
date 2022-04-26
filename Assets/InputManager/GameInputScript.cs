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
    public bool is_punching = false;
    public bool is_kicking = false;
    public bool is_blocking = false;

    // Input Action Message Handlers
    void OnDirection(InputValue val)
    {
        player_direction = val.Get<float>();
        Debug.Log("player_direction: " + player_direction);
    }

    void OnSprint(InputValue val)
    {
        sprint = val.isPressed;
        Debug.Log("sprint: " + sprint);
    }

    void OnJump(InputValue val)
    {
        jump = val.isPressed;
        Debug.Log("jump: " + jump);
    }

    void OnPunch(InputValue val)
    {
        is_punching = val.isPressed;
        Debug.Log("punch: " + is_punching);
    }

    void OnKick(InputValue val)
    {
        is_kicking = val.isPressed;
        Debug.Log("kick: " + is_kicking);
    }

    void OnBlock(InputValue val)
    {
        is_blocking = val.Get<float>() != 0;
        Debug.Log("block: " + is_blocking);
    }
}