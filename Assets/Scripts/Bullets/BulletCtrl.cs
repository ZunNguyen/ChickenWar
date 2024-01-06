using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : ErshenMonoBehaviour
{
    [SerializeField] protected BulletSO bulletSO;
    public BulletSO BulletSO => bulletSO;

    [SerializeField] protected BulletDamSender bulletDamSender;
    public BulletDamSender BulletDamSender => bulletDamSender;

    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn => bulletDespawn;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadChickenSO();
        LoadBulletDamgeSender();
        LoadBulletDespawn();
    }

    protected virtual void LoadChickenSO()
    {
        if (bulletSO != null) return;
        string resPath = "SO/Bullets/Bullets";
        bulletSO = Resources.Load<BulletSO>(resPath);
    }

    protected virtual void LoadBulletDamgeSender()
    {
        if (bulletDamSender != null) return;
        bulletDamSender = transform.GetComponentInChildren<BulletDamSender>();
    }

    protected virtual void LoadBulletDespawn()
    {
        if (bulletDespawn != null) return;
        bulletDespawn = transform.GetComponentInChildren<BulletDespawn>();
    }
}