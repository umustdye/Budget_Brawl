using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    private linkPlayerHealth playerHealth;
    public BoxCollider hurtbox;
    public enum ColliderState { Inactive, Active, Colliding };
    public ColliderState state = ColliderState.Active;

    public Color hurtboxColor = Color.green;
    public Color hurtboxInactive;
    public Color hurtboxCollision;
    
    public bool GetHitBy(int damage)
    {
        playerHealth = this.GetComponent<linkPlayerHealth>();

        playerHealth.ApplyDamage(damage);

        return true;
    }

    private void UpdateGizmoColor()
    {
        switch (state)
        {
            case ColliderState.Inactive:
                Gizmos.color = hurtboxInactive;
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

        Gizmos.matrix = Matrix4x4.TRS(hurtbox.transform.position, hurtbox.transform.rotation, hurtbox.transform.localScale);

        Gizmos.DrawCube(hurtbox.center, hurtbox.size);
    }
}
