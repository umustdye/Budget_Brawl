using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHP = 10500;
    public int currentHP;

    public linkPlayerHealth healthBarLeft;
    public linkPlayerHealth healthBarRight;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            healthBarLeft.ApplyDamage(1313);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            healthBarLeft.ApplyHealing(1313);
        }
    }
}
