using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    // Components
    private GameInputScript input;
    private PlayerController controller;

    // Fighting
    [Header("Fighting")]
    public bool is_blocking = false;
    public bool is_punching = false;
    public bool is_kicking = false;
    public float punch_time = 0.5f;
    public float kick_time = 0.8f;
    private float punch_delta = 0;
    private float kick_delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<GameInputScript>();
        controller = GetComponent<PlayerController>();
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
