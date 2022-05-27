using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator currentAnimation;
    public int punch_damage = 500;
    public int kick_damage = 1500;
    public int backslide_damage = 1500;
    public int hurricane_kick_damage = 750;
    public int attackLayer = 0;

    public linkPlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentAnimation = Find<Animator>();
    }

    public int GetAttackDamage()
    {
        int attackDamage = 0;
        currentAnimation = FindObjectOfType<Animator>();
        

        if (currentAnimation.GetCurrentAnimatorStateInfo(attackLayer).IsName("Boxing_Punch_Humanoid"))
        {
            attackDamage = punch_damage;
        }
        else if (currentAnimation.GetCurrentAnimatorStateInfo(attackLayer).IsName("MMA_Kick_Humanoid"))
        {
            attackDamage = kick_damage;
        }
        else if (currentAnimation.GetCurrentAnimatorStateInfo(attackLayer).IsName("Sprint_To_Backslide_Humanoid"))
        {
            attackDamage = backslide_damage;
        }
        else if (currentAnimation.GetCurrentAnimatorStateInfo(attackLayer).IsName("Hurricane_Kick_Humanoid"))
        {
            attackDamage = hurricane_kick_damage;
        }
        else
        {
            Debug.Log("Error! Could not find your attack");
        }


        return attackDamage;
    }

    public void Attack_Player(Collider hurtboxCollider)
    {
        playerHealth = hurtboxCollider.GetComponent<linkPlayerHealth>();

        int damage = GetAttackDamage();

        playerHealth.ApplyDamage(damage);
    }
}
