using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Hitbox : MonoBehaviour
{
    public LayerMask mask;
    public GameObject hitbox;
    public Color hitboxColor = Color.red;

    public ColliderState state;
    public enum ColliderState { Inactive, Active, Colliding };

    // Colors to test functioning hitbox
    public Color hitboxInactive;
    public Color hitboxCollision;

    private Vector3 hitboxSize;
    // Start is called before the first frame update
    void Start()
    {
        // hitbox = GameObject.Find("Hitbox");
    }

    // Update is called once per frame
    void Update()
    {
        if (state == ColliderState.Inactive)
        {
            return;
        }

        hitboxSize = hitbox.GetComponent<BoxCollider>().size;
        Collider[] colliders = Physics.OverlapBox(hitbox.transform.position, hitboxSize, hitbox.transform.rotation, mask);

        if (colliders.Length > 1)
        {
            state = ColliderState.Colliding;
        }
        else
        {
            state = ColliderState.Active;
        }
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
