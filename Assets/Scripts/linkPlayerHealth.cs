using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linkPlayerHealth : MonoBehaviour
{
    public int maxHP = 10000;
    public int currentHP;

    //determining low health
    public bool lowHealth;
    public bool dead;
    //bool revived;
    private int lowHealthFactor = 2;

    // health bar may be dynamically assigned when the game starts
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        healthBar.SetMaxHealth(maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        updateLowHealthStatus();
    }

    // upon respawn or beginning of the game, refill player's health to max
    public void refillFull(){
        currentHP = maxHP;
        healthBar.SetHealth(maxHP);
    }

    public void ApplyDamage(int damage)
    {
        currentHP -= damage;
        // just in case of underflow
        if(currentHP < 0){
            currentHP = 0;
        }
        healthBar.SetHealth(currentHP);

    }
    public void ApplyHealing(int hpRestored)
    {
        currentHP += hpRestored;
        // just in case of overflow
        if(currentHP > maxHP){
            currentHP = maxHP;
        }
        healthBar.SetHealth(currentHP);
    }

    public int getHP(){
        return currentHP;
    }

    void updateLowHealthStatus()
    {   
        if(currentHP <= 0)
        {
            dead = true;
        }

        else
        {
            dead = false;
            if(currentHP < maxHP/lowHealthFactor)
            {
                lowHealth = true;
            }

            else
            {
                lowHealth = false;
            }
        }
    }
}
