using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDamageReceiver : DamageReciver
{
    [SerializeField] protected DogCtrl dogCtrl;
    public DogCtrl DogCtrl => dogCtrl;

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

    protected override void OnDead()
    {
        dogCtrl.DogDespawn.DespawnObj();
    }
}
