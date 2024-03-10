using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDespawn : Despawn
{
    public virtual void DespawnEffect()
    {
        Invoke(nameof(DespawnObj), 2f);
    }

    public override void DespawnObj()
    {
        EffectSpawner.Instance.Despawn(transform);
    }
}