using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
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
        if(collide.gameObject.tag == "Player"){
            // add interaction with health or special move
            Token token = gameObject.GetComponent<Token>();
            token.interact(collide.gameObject);

            // in case of changing mechanism for picking up item
            // Physics.IgnoreCollision(collide.gameObject.GetComponent<Collider>(), GetComponent<Collider>(), true);

            // on collision item should be dispensed from ItemSpanwer.childItems and disappear
            Destroy(gameObject);
        }
    }
}
