using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHPBar : ErshenMonoBehaviour
{
    [SerializeField] protected Slider slider;
    [SerializeField] protected DogDamageReceiver dogDamageReceiver;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadSLider();
    }

    protected virtual void LoadSLider()
    {
        if (slider != null) return;
        slider = transform.GetComponent<Slider>();
    }

    private void FixedUpdate()
    {
        UpdateHPBar();        
    }

    protected virtual void UpdateHPBar()
    {
        this.slider.value = dogDamageReceiver.hpCurrent;
    }
}
