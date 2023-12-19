using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDespawn : Despawn
{
    public override void DespawnObj()
    {
        DogSpawner.Instance.Despawn(transform.parent);
    }
}
