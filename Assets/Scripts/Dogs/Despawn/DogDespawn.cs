using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDespawn : Despawn
{
    public override void DespawnObj()
    {
        GameObjectSpawner.Instance.Despawn(transform.parent);
    }
}