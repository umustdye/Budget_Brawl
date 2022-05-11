using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>(), false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay(Collision collide)
    {
        Debug.Log("I hit the GameObject : " + collide.gameObject.name);
    }
}
