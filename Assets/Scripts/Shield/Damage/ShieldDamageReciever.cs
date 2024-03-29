using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDamageReciever : DamageReciver
{
    public override void Deduct(int deduct)
    {
        CanvasController.Instance.ShieldUpdateController.ShieldUpdate.SubtractHPShield(deduct);
    }

    protected override void OnDead()
    {
        throw new System.NotImplementedException();
    }
}