using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSpecicalDamageSender : DogDamageSender
{
    protected override void SetAnimationAttack()
    {
        base.SetAnimationAttack();

        // Audio
        CanvasCtrl.Instance.AudioManager.PlaySFX(CanvasCtrl.Instance.AudioManager.effectBoom);

        dogCtrl.DisaleComponents();
        Invoke(nameof(SetDelayToDespawn), 1f);
    }

    protected virtual void SetDelayToDespawn()
    {
        dogCtrl.DogDespawn.DespawnObj();
    }
}
