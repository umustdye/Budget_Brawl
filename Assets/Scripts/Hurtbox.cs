using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    private linkPlayerHealth playerHealth;
    // List of hurtboxes starting from top of the character to the bottom
    public List<BoxCollider> hurtboxes;
    public int chipPercent = 15;

    public enum ColliderState { Blocking, Active, Colliding };
    public ColliderState state = ColliderState.Active;
    public bool isHit;

    private CombatScript combatAction;

    public Color hurtboxColor = new Color(0f, 1f, 0f, 0.1960f);
    public Color hurtboxBlock = new Color(0f, 0.9363262f, 1f, 0.3921569f);
    public Color hurtboxCollision = new Color(0.7411765f, 0, 0.9725491f, 0.3921569f);

    void Start()
    {
        combatAction = this.GetComponent<CombatScript>();  
        hurtboxColor = new Color(0f, 1f, 0f, 0.1960f);
        hurtboxBlock = new Color(0f, 0.9363262f, 1f, 0.3921569f);
        hurtboxCollision = new Color(0.7411765f, 0, 0.9725491f, 0.3921569f);
    }

    public void GetHitBy(int damage)
    {
        playerHealth = this.GetComponent<linkPlayerHealth>();

        if (combatAction.is_blocking)
        {
            float chipDamage = ((float) damage * (chipPercent/100f));
            // Debug.Log("Chip Damage: " + Mathf.RoundToInt(chipDamage));
            playerHealth.ApplyDamage(Mathf.RoundToInt(chipDamage));
        }
        else
        {
            playerHealth.ApplyDamage(damage);
        }
        
        isHit = true;

    }

    public void SetCollision()
    {
        state = ColliderState.Colliding;
    }

    private void UpdateGizmoColor()
    {
        switch (state)
        {
            case ColliderState.Blocking:
                Gizmos.color = hurtboxBlock;
                break;

            case ColliderState.Colliding:
                Gizmos.color = hurtboxCollision;
                break;

            case ColliderState.Active:
                Gizmos.color = hurtboxColor;
                break;
        }
    }

    private void OnDrawGizmos()
    {
        UpdateGizmoColor();
        // Draw all hurtboxes
        for (int i = 0; i < hurtboxes.Count; ++i) {
            Gizmos.matrix = Matrix4x4.TRS(hurtboxes[i].transform.position, hurtboxes[i].transform.rotation, hurtboxes[i].transform.localScale);

            Gizmos.DrawCube(hurtboxes[i].center, hurtboxes[i].size);
        }
    }
}
