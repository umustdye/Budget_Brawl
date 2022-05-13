using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialToken : Token
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void interact(GameObject player){
        // Debug.Log("Special token interact");
        ParticleSystem particles = player.GetComponent<ParticleSystem>();
        particles.Play();
    }
}
