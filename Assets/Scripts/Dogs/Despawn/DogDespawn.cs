using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDespawn : Despawn
{
    public override void DespawnObj()
    {
        // Add achievement
        CanvasCtrl.Instance.PanelMissionCtrl.PanelMission_4.AddAchievementPlayer(1);

        CanvasCtrl.Instance.TrackingWaveController.TrackingWave.sumDogDeath += 1;
        GameObjectSpawner.Instance.Despawn(transform.parent);
    }
}