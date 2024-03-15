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
        dogCtrl = transform.parent.parent.GetComponent<DogCtrl>();
    }

    protected override void OnDead()
    {
        dogCtrl.DogAniamtion.Dead();
        dogCtrl.DisaleComponents();

        this.transform.parent.parent.position = new Vector3(this.transform.position.x, this.transform.position.y, 10);
        TrackingWave.Instance.sumDogCurrent += 1;
        Invoke(nameof(Despawn), 3);
    }

    protected virtual void Despawn()
    {
        dogCtrl.DogDespawn.DespawnObj();
    }
}