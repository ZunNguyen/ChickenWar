using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReciver : ErshenMonoBehaviour
{
    public float hpMax = 99999;
    public float hpCurrent = 1;
    [SerializeField] protected bool isDead = false;

    protected override void ResetValue()
    {
        base.ResetValue();
        Reborn();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        Reborn();
    }

    public virtual void Reborn()
    {
        hpCurrent = hpMax;
        isDead = false;
    }

    public virtual void Deduct(int deduct)
    {
        if (isDead) return;
        hpCurrent -= deduct;
        if (hpCurrent < 0) hpCurrent = 0;
        CheckIsDead();
    }

    protected virtual void CheckIsDead()
    {
        if (hpCurrent > 0) return;
        isDead = true;
        OnDead();
    }

    protected abstract void OnDead();
}
