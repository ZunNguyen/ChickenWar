using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : ErshenMonoBehaviour
{
    [SerializeField] protected int damgeSend;

    public virtual void Send(Transform obj)
    {
        if (!obj.transform.TryGetComponent<DamageReciver>(out var damageReciver)) return;
        this.Send(damageReciver);
    }

    public virtual void Send(DamageReciver damageReciver)
    {
        damageReciver.Deduct(damgeSend);
    }
}