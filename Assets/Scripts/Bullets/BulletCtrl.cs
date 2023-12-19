using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : ErshenMonoBehaviour
{
    [SerializeField] protected BulletSO bulletSO;
    public BulletSO BulletSO => bulletSO;

    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender => damageSender;

    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn => bulletDespawn;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadChickenSO();
        LoadDamgeSender();
        LoadBulletDespawn();
    }

    protected virtual void LoadChickenSO()
    {
        if (bulletSO != null) return;
        string resPath = "SO/Bullets/" + this.transform.name;
        bulletSO = Resources.Load<BulletSO>(resPath);
    }

    protected virtual void LoadDamgeSender()
    {
        if (damageSender != null) return;
        damageSender = transform.GetComponentInChildren<DamageSender>();
    }

    protected virtual void LoadBulletDespawn()
    {
        if (bulletDespawn != null) return;
        bulletDespawn = transform.GetComponentInChildren<BulletDespawn>();
    }
}