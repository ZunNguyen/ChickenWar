using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHPBar : ProcessSlider
{
    [Header("Connect Script")]
    [SerializeField] protected DogDamageReceiver dogDamageReceiver;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadDogDamageReceiver();
    }

    protected virtual void LoadDogDamageReceiver()
    {
        if (dogDamageReceiver != null) return;
        dogDamageReceiver = transform.parent.parent.GetComponentInChildren<DogDamageReceiver>();
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