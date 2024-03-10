using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamSender : DamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    public int index;
    public int damge = 10;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (bulletCtrl != null) return;
        bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
    }

    public override void Send(DamageReciver damageReciver)
    {
        damageReciver.Deduct(this.damge);
        // Despawn Obj
        bulletCtrl.BulletDespawn.DespawnObj();
    }

    public virtual void GetDamgeBullet(int indexLevelChicken)
    {
        damge = bulletCtrl.ChickenSO.levels[indexLevelChicken].damage;
    }
}