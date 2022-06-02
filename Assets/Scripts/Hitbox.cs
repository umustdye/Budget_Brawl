using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hitbox : MonoBehaviour
{
    private LayerMask mask;
    public GameObject hitbox;
    public Color hitboxColor = Color.red;

    public ColliderState state;
    public enum ColliderState { Inactive, Active, Colliding };

    private CombatScript combatAction;
    public int punchDamage;
    public int kickDamage;
    public int specialAttackDamage;

    // Colors to test functioning hitbox
    private Color hitboxInactive;
    private Color hitboxCollision;

    private Vector3 hitboxSize;

    public List<Hurtbox> enemyHurtboxes;
    public Collider[] colliders;

    void Start()
    {
        mask = LayerMask.GetMask("AllHitboxes");
        combatAction = this.GetComponent<CombatScript>();
        hitbox = transform.Find("Hitbox").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // counts number of colliders that belongs to itself
        int selfCollide = 0;
        Transform playerFromHurtbox;
        if (state == ColliderState.Inactive)
        {
            return;
        }

        colliders = Physics.OverlapBox(hitbox.transform.position, hitboxSize, hitbox.transform.rotation, mask);
        //TODO: create attack script that controls the amount of damage each attack does via
        // a function that takes an int and is called through the animator event for each attack
        // will use a switch block to select damage and will have a stupid about of public integers

        for (int i = 0; i < colliders.Length; ++i)
        {
            Collider hurtboxCollider = colliders[i];
            playerFromHurtbox = hurtboxCollider.transform.root;

            if ( this.transform != playerFromHurtbox)
            {
                //TODO: convert this portion to a new script/function
                Hurtbox enemyHurtbox = playerFromHurtbox.gameObject.GetComponent<Hurtbox>();
                enemyHurtbox.state = Hurtbox.ColliderState.Colliding;
                if (!enemyHurtbox.isHit)
                {
                    enemyHurtbox.GetHitBy(GetDamage());
                    enemyHurtboxes.Add(enemyHurtbox);
                }
            }
            else
            {
                ++selfCollide;
            }

        }

        state = colliders.Length > selfCollide ? ColliderState.Colliding : ColliderState.Active;
    }

    public void StartCollisionDetection()
    {
        state = ColliderState.Active;
        hitbox.SetActive(true);
        Debug.Log("Active Hitbox");
    }

    public void StopCollisionDetection()
    {
        state = ColliderState.Inactive;
        hitbox.SetActive(false);
        ResetEnemyHurtbox();
    }

    private void ResetEnemyHurtbox()
    {
        for (int i = 0; i < enemyHurtboxes.Count; ++i)
        {
            enemyHurtboxes[i].isHit = false;
            enemyHurtboxes[i].state = Hurtbox.ColliderState.Active;
        }
    }

    public int GetDamage()
    {
        int attackDamage = 0;

        if (combatAction.is_punching)
        {
            attackDamage = punchDamage;
        }
        else if (combatAction.is_kicking)
        {
            attackDamage = kickDamage;
        }
        else if (combatAction.is_special_attack)
        {
            attackDamage = specialAttackDamage;
        }


        return attackDamage;
    }

    private void UpdateGizmoColor()
    {
        switch(state)
        {
            case ColliderState.Inactive:
                Gizmos.color = hitboxInactive;
                break;

            case ColliderState.Colliding:
                Gizmos.color = hitboxCollision;
                break;

            case ColliderState.Active:
                Gizmos.color = hitboxColor;
                break;
        }
    }

    private void OnDrawGizmos()
    {
        hitboxSize = hitbox.GetComponent<BoxCollider>().size;
        UpdateGizmoColor();

        Gizmos.matrix = Matrix4x4.TRS(hitbox.transform.position, hitbox.transform.rotation, hitbox.transform.localScale);

        Gizmos.DrawCube(Vector3.zero, new Vector3(hitboxSize.x, hitboxSize.y, hitboxSize.z));
    }
}
