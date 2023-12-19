using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : ErshenMonoBehaviour
{
    [SerializeField] protected int damge = 1;

    public virtual void Send(Transform obj)
    {
        DamageReciver damageReciver = obj.transform.GetComponent<DamageReciver>();
        if (damageReciver == null) return;
        this.Send(damageReciver);
    }

    public virtual void Send(DamageReciver damageReciver)
    {
        damageReciver.Deduct(damge);
    }
}

