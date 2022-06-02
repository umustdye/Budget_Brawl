using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    private linkPlayerHealth playerHealth;
    // List of hurtboxes starting from top of the character to the bottom
    public List<BoxCollider> hurtboxes;
    public enum ColliderState { Blocking, Active, Colliding };
    public ColliderState state = ColliderState.Active;
    public bool isHit;

    public Color hurtboxColor = Color.green;
    public Color hurtboxBlock;
    public Color hurtboxCollision;
    
    public void GetHitBy(int damage)
    {
        playerHealth = this.GetComponent<linkPlayerHealth>();
        playerHealth.ApplyDamage(damage); 
        
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
