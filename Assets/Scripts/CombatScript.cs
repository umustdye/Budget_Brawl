using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    // Components
    private GameInputScript input;
    private PlayerController controller;
    //check if the player collected a special attack item
    private specialManager special_attack_item;

    // Fighting
    [Header("Fighting")]
    public bool is_blocking = false;
    public bool is_punching = false;
    public bool is_kicking = false;
    public bool is_special_attack = false;
    public float punch_time = 1.0f;
    public float kick_time = 0.8f;
    public float special_attack_time = 4.0f;
    private float punch_delta = 0;
    private float kick_delta = 0;
    private float special_attack_delta = 0;





    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<GameInputScript>();
        controller = GetComponent<PlayerController>();
        special_attack_item = GetComponent<specialManager>();
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

        else if(is_kicking)
        {
            kick_delta += Time.deltaTime;
            if(kick_delta >= kick_time) 
            {
                kick_delta = 0;
                is_kicking = false;
            }
        }

        else if(is_special_attack)
        {
            special_attack_delta += Time.deltaTime;
            special_attack_item.dischargeSpecial();
            special_attack_item.stopParticles();
            if(special_attack_delta >= special_attack_time)
            {
                special_attack_delta = 0;
                is_special_attack = false;
            }
        }

        // Input
        is_blocking = input.block && controller.is_touching_ground && !IsAttacking();
        if(input.punch)
        {
            is_punching = !(is_blocking || is_kicking || is_special_attack);
            input.punch = false;
        }
        if(input.kick)
        {
            is_kicking = !(is_blocking || is_punching || is_special_attack);
            input.kick = false;
        }
        if(input.special_attack)
        {
            is_special_attack = !(is_blocking || is_punching || is_kicking) && special_attack_item.isSpecialCharged();
            input.special_attack = false;
        }
    }

    public bool IsAttacking()
    {
        return is_punching || is_kicking || is_special_attack;
    }
}
