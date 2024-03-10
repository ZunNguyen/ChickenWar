using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : Despawn
{
    public override void DespawnObj()
    {
        GameObjectSpawner.Instance.Despawn(transform.parent);
    }
}