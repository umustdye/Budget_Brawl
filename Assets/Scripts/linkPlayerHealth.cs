using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linkPlayerHealth : MonoBehaviour
{
    public int maxHP = 10500;
    public int currentHP;

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
}
