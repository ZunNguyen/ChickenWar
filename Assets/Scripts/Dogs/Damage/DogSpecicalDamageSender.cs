using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSpecicalDamageSender : DogDamageSender
{
    protected override void SetAnimationAttack()
    {
        base.SetAnimationAttack();

        // Audio
        CanvasController.Instance.AudioManager.PlaySFX(CanvasController.Instance.AudioManager.effectBoom);

        dogCtrl.CanvasHP.gameObject.SetActive(false);
        Invoke(nameof(SetDelayToDespawn), 1f);
    }

    protected virtual void SetDelayToDespawn()
    {
        dogCtrl.DogDespawn.DespawnObj();
    }
}
