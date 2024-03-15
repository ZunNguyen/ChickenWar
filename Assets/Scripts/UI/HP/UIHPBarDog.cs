using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHPBarDog : ProcessSlider
{
    [Header("Connect Controller")]
    [SerializeField] protected DogCtrl dogCtrl;

    [SerializeField] protected float hpMax;
    [SerializeField] protected float hpCurrent;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadDogCtrl();
    }

    protected virtual void LoadDogCtrl()
    {
        if (dogCtrl != null) return;
        dogCtrl = transform.parent.GetComponent<DogCtrl>();
    }

    private void FixedUpdate()
    {
        UpdateHPBar();
    }

    protected virtual void UpdateHPBar()
    {
        hpMax = dogCtrl.DogDamageReceiver.hpMax;
        hpCurrent = dogCtrl.DogDamageReceiver.hpCurrent;
        this.slider.value = hpCurrent/hpMax*100;
    }
}