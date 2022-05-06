using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Controls the 'Fill' gameObject 
    public Slider slider;

    // Changes slider max value to match the passed in hp value
    public void SetMaxHealth(int maxHPValue)
    {
        slider.maxValue = maxHPValue;
        slider.value = maxHPValue;
    }

    // Changes slider value to mach passed in value
    public void SetHealth(int hpValue)
    {
        slider.value = hpValue;
    }
}
