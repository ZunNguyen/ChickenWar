using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldHPBar : ProcessSlider
{
    public virtual void ChangeSlider(float hpCurrent, float hpMax)
    {
        if (hpCurrent <= 0)
        {
            Debug.Log("Shield death");
            hpCurrent = 0;
        }
        float value = (hpCurrent * 100 / hpMax);
        slider.value = value;
    }
}
