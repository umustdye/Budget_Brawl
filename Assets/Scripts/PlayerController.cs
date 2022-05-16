using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    private GameInputScript input;
    private Rigidbody rigid_body;
    private CombatScript combat;
    private SoundEffects soundfx;

    // Player Movement
    [Header("Movement")]
    public float walk_speed = 3.0f;
    public float sprint_speed = 5.0f;
    public bool is_idle = false;
    public bool is_walking = false;
    public bool is_sprinting = false;
    private float horizontal_velocity_delta = 0;

    // Jumping
    [Header("Jumping")]
    public float jump_height = 3.0f;
    public int jump_max = 3;
    public bool is_jumping = false;
    public bool waiting_to_land = false;
    private int jump_current = 0;
    private float vertical_velocity_delta = 0;

    // Falling
    [Header("Falling")]
    public bool is_falling = false;
    public float fall_max_time = 1.0f;
    private float fall_current_time = 0f;

    // Ground Collision
    [Header("Ground Collision")]
    public float ground_radius = 0.5f;
    public float ground_offset = -0.51f;
    public bool is_touching_ground = false;
    public LayerMask ground_layers;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<GameInputScript>();
        rigid_body = GetComponent<Rigidbody>();
        combat = GetComponent<CombatScript>();
        soundfx = GetComponent<SoundEffects>();
        ground_layers = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        GroundedCheck();
        FallingCheck();
        UpdateJump();
        UpdateMovement();
        ApplyRotation();
        ApplyForce();
    }

    void GroundedCheck()
    {
        Vector3 center = new Vector3(transform.position.x, transform.position.y + ground_offset, transform.position.z);
        is_touching_ground = Physics.CheckSphere(center, ground_radius, ground_layers, QueryTriggerInteraction.Ignore);
        Debug.Log("is_touching_ground: " + is_touching_ground);
    }

    void FallingCheck()
    {
        fall_current_time += Time.fixedDeltaTime;
        if (waiting_to_land) {
            if (is_touching_ground)
            {
                is_falling = false;
                fall_current_time = 0;
            }
            else {
                 if (fall_current_time > fall_max_time || Vector3.Dot(GetComponent<Rigidbody>().velocity, Vector3.up) < -0.01f) {
                     is_falling = true;
                     is_jumping = false;
                 }
            }
        }
        
}

    void UpdateJump()
    {
        if(is_touching_ground)
        {
            if (waiting_to_land) { 
                waiting_to_land = false;
                soundfx.play_Jumping_Down_Sound();
            }
            is_jumping = false;
            jump_current = 0;
        }

        if(input.jump)
        {
            if(jump_current < jump_max && !(combat.is_punching || combat.is_kicking))
            {   
                ++jump_current;
                if (jump_current == 1) { soundfx.play_Jumping_Up_Sound(); }
                else { soundfx.play_Jump_Whoosh_Sound(); }
                rigid_body.velocity = new Vector3(rigid_body.velocity.x, 0, 0); // Vertical velocity zero for full height jump in air
                vertical_velocity_delta = Mathf.Sqrt(jump_height * -2f * Physics.gravity.y);
                is_jumping = true;
                is_falling = false;
                fall_current_time = 0;
                waiting_to_land = true;
            }
            input.jump = false;
        }
        else
        {
            vertical_velocity_delta = 0;
        }
    }

    void UpdateMovement()
    {
        // Set movement bools
        is_idle = is_touching_ground && input.player_direction == 0 && !combat.is_blocking;
        is_walking = is_touching_ground && input.player_direction != 0 && !input.sprint && !combat.is_blocking;
        is_sprinting = is_touching_ground && input.player_direction != 0 && input.sprint && !combat.is_blocking;

        // Update velocity
        if(combat.is_blocking)
        {
            horizontal_velocity_delta = -rigid_body.velocity.x; // Stop player movement when blocking
        }
        else
        {
            float target_speed = input.sprint ? sprint_speed : walk_speed;
            horizontal_velocity_delta = input.player_direction * target_speed - rigid_body.velocity.x;
        }
    }

    void ApplyRotation()
    {
        if(input.player_direction != 0)
        {
            Quaternion new_rotation = Quaternion.LookRotation(new Vector3(input.player_direction, 0, 0));
            rigid_body.MoveRotation(new_rotation);
        }
    }

    void ApplyForce()
    {
        rigid_body.AddForce(new Vector3(horizontal_velocity_delta, vertical_velocity_delta, 0), ForceMode.VelocityChange);
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 center = new Vector3(transform.position.x, transform.position.y + ground_offset, transform.position.z);
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(center, ground_radius);
    }
}