using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDamageReciever : DamageReciver
{
    protected override void OnDead()
    {
        Debug.Log("Shield dead");
    }
}