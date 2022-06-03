using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public float fixedZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collide)
    {
        // when item collides with player
        // make sure for players to be taggered as "Player"
        if(collide.gameObject.tag == "Player"){
            // add interaction with health or special move
            Token token = gameObject.GetComponent<Token>();
            token.interact(collide.gameObject);

            // in case of changing mechanism for picking up item
            Physics.IgnoreCollision(collide.gameObject.GetComponent<Collider>(), GetComponent<Collider>(), true);
            // when player touches cube, player slightly moves in Z-axis
            // to counteract distortion, physically foced player to stay at one Z-position
            // z-position is hard coded right now
            collide.gameObject.transform.position = new Vector3(collide.gameObject.transform.position.x, collide.gameObject.transform.position.y, fixedZ);

            // on collision item should be dispensed from ItemSpanwer.childItems and disappear
            Destroy(gameObject);
        }
    }
}
