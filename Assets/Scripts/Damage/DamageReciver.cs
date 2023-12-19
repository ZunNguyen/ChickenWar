using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReciver : ErshenMonoBehaviour
{
    [SerializeField] protected int hpMax = 10;
    [SerializeField] protected int hp = 1;
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
        hp = hpMax;
        isDead = false;
    }

    public virtual void Deduct(int deduct)
    {
        if (isDead) return;
        hp -= deduct;
        if (hp < 0) hp = 0;
        CheckIsDead();
    }

    protected virtual void CheckIsDead()
    {
        if (hp > 0) return;
        isDead = true;
        OnDead();
    }

    protected abstract void OnDead();
}
