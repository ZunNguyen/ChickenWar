using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldHPBar : CanvasAbstract
{
    [Header("Get Component")]
    [SerializeField] protected Slider slider;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadSlider();
    }

    protected virtual void LoadSlider()
    {
        if (slider != null) return;
        slider = transform.GetComponent<Slider>();
    }

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

    public void Change()
    {

    }
}
