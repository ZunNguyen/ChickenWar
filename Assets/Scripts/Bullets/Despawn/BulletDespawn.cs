using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : Despawn
{
    public override void DespawnObj()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}