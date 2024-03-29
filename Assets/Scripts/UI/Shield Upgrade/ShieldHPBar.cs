using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShieldHPBar : ProcessSlider
{
    public virtual void ChangeSlider(float hpCurrent, float hpMax)
    {
        float value = (hpCurrent * 100 / hpMax);
        slider.value = value;
    }
}
