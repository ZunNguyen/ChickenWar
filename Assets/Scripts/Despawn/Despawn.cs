
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : ErshenMonoBehaviour
{
    protected void FixedUpdate()
    {
        //Despawning();
    }

    protected virtual void Despawning()
    {
        if (!CanDespawn()) return;
        DespawnObj();
    }

    public virtual void DespawnObj()
    {
        Destroy(transform.parent.gameObject);
    }

    protected virtual bool CanDespawn()
    {
        return false;
    }
}