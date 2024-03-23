using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDespawn : Despawn
{
    public override void DespawnObj()
    {
        CanvasController.Instance.TrackingWaveController.TrackingWave.sumDogDeath += 1;
        GameObjectSpawner.Instance.Despawn(transform.parent);
    }
}