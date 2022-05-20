using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthToken : Token
{
    private float maxMultiplier = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void interact(GameObject player){
        // Debug.Log("Health token interact");
        linkPlayerHealth health = player.GetComponent<linkPlayerHealth>();
        float varMultiplier = (health.maxHP / (float)health.currentHP);
        // maximum restored hp would be 17.5% of max hp
        // minimum restored hp would be 5% of max hp as varMultiplire or maxHP / maxHP = 1
        double restoredHp = Mathf.Min(maxMultiplier, varMultiplier) * 0.05f * health.maxHP;
        health.ApplyHealing((int)(restoredHp));
    }
}
