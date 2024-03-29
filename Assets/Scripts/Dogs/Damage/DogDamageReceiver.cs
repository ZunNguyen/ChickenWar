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
        // Audio for dog boom
        if (transform.parent.parent.gameObject.name == "Dog05" || transform.parent.parent.gameObject.name == "Dog10") CanvasController.Instance.AudioManager.PlaySFX(CanvasController.Instance.AudioManager.effectBoom);

        dogCtrl.DisaleComponents();
        dogCtrl.DogAniamtion.Dead();
        Invoke(nameof(Despawn), 3);
    }

    protected virtual void Despawn()
    {
        dogCtrl.DogDespawn.DespawnObj();
    }
}