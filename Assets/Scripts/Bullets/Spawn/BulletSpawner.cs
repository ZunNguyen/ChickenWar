using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl => bulletCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        //if (bulletCtrl != null) return;
        bulletCtrl = GameObject.Find("Bullet Spawner").transform.Find("Prefabs").transform.Find("Bullet").GetComponent<BulletCtrl>();
    }
}
