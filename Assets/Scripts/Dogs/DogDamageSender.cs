using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDamageSender : DamageSender
{
    [SerializeField] protected DogCtrl dogCtrl;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Dog Damage Receiver") return;
        if (collision.gameObject.name == "Shield Damage Reciver")
        {
            // Stop movement
            StopMovement();
            // Set Animation for Attack Damage
            SetAnimationAttack();
            Send(collision.transform);

            // Set Update HP Shield
            SetUpdateHPShield(collision.transform);
        }
    }

    protected virtual void StopMovement()
    {
        dogCtrl.DogMovement.enabled = false;
    }

    protected virtual void SetAnimationAttack()
    {
        dogCtrl.DogAniamtion.Attack();
    }

    protected virtual void SetUpdateHPShield(Transform obj)
    {
        ShieldHPSum shieldHPSum = obj.parent.parent.GetComponent<ShieldHPSum>();
        shieldHPSum.LoadSumHpCurrent();
    }
}