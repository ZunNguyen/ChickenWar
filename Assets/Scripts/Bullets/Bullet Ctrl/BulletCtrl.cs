using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : ErshenMonoBehaviour
{
    [SerializeField] protected ChickenSO chickenSO;
    public ChickenSO ChickenSO => chickenSO;

    [SerializeField] protected BulletDamSender bulletDamSender;
    public BulletDamSender BulletDamSender => bulletDamSender;

    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn => bulletDespawn;

    [SerializeField] protected BulletMovement bulletMovement;
    public BulletMovement BulletMovement => bulletMovement;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadChickenSO();
        LoadBulletDamgeSender();
        LoadBulletDespawn();
        LoadBulletMovement();
    }

    protected virtual void LoadChickenSO()
    {
        if (chickenSO != null) return;
        string resPath = "SO/Chickens/Chickens";
        chickenSO = Resources.Load<ChickenSO>(resPath);
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

    protected virtual void LoadBulletMovement()
    {
        if (bulletMovement != null) return;
        bulletMovement = transform.GetComponentInChildren<BulletMovement>();
    }
}