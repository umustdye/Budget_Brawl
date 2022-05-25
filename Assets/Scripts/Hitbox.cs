using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Hitbox : MonoBehaviour
{
    public LayerMask mask;
    public Vector3 hitboxSize = Vector3.one;
    public Color hitboxColor = Color.red;

    public ColliderState state;
    public enum ColliderState { Inactive, Active, Colliding };
    // Colors to test functioning hitbox
    public Color hitboxInactive;
    public Color hitboxCollision;

    private Vector3 position;
    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == ColliderState.Inactive)
        {
            return;
        }

        Collider[] colliders = Physics.OverlapBox(transform.position, hitboxSize, transform.rotation, mask);

        if (colliders.Length > 0)
        {
            state = ColliderState.Colliding;
        }
        else
        {
            state = ColliderState.Active;
        }
    }

    private void boxChange()
    {

    }

    public void StartCollisionDetection()
    {
        state = ColliderState.Active;
    }

    public void StopCollisionDetection()
    {
        state = ColliderState.Inactive;
    }

    private void updateGizmoColor()
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
        updateGizmoColor();

        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);

        Gizmos.DrawCube(Vector3.zero, new Vector3(hitboxSize.x * 2, hitboxSize.y * 2, hitboxSize.z * 2));
    }
}
