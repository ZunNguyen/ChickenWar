using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : ErshenMonoBehaviour
{
    [SerializeField] protected BulletSO bulletSO;
    public BulletSO BulletSO => bulletSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadChickenSO();
    }

    protected virtual void LoadChickenSO()
    {
        if (bulletSO != null) return;
        string resPath = "SO/Bullets/" + this.transform.name;
        bulletSO = Resources.Load<BulletSO>(resPath);
    }
}