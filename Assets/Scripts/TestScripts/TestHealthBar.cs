using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHP = 10500;
    public int currentHP;

    public HealthBar healthBarLeft;
    public HealthBar healthBarRight;
    void Start()
    {
        currentHP = maxHP;
        healthBarLeft.SetMaxHealth(maxHP);
        healthBarRight.SetMaxHealth(maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            ApplyDamage(1313);
        }
    }

    private void ApplyDamage(int damage)
    {
        currentHP -= damage;
        healthBarLeft.SetHealth(currentHP);
        healthBarRight.SetHealth(currentHP);
    }
}
