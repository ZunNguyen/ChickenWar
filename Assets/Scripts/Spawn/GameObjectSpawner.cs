using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSpawner : Spawner
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
        if (bulletCtrl != null) return;
        bulletCtrl = GameObject.Find("GameObject Spawner").transform.Find("Prefabs").transform.Find("Bullet").GetComponent<BulletCtrl>();
    }
}
