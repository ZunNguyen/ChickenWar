using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : ErshenMonoBehaviour
{
    [Header("Abstract Class")]
    [SerializeField] protected BulletCtrl bulletCtrl;

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
}
