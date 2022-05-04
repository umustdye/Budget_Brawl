using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int maxHPValue)
    {
        slider.maxValue = maxHPValue;
        slider.value = maxHPValue;
    }

    public void SetHealth(int hpValue)
    {
        slider.value = hpValue;
    }
}
