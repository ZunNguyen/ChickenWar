using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointSpawnDog : LoadIndexObj
{
    [Header("Connect Script")]
    [SerializeField] protected PointSpawnDogController pointSpawnDogController;

    public float x = 0.01f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPointSpawnDogController();
        }

    protected virtual void LoadPointSpawnDogController()
    {
        if (pointSpawnDogController != null) return;
        pointSpawnDogController = transform.GetComponentInParent<PointSpawnDogController>();
    }
    
    public virtual IEnumerator Spawning(string nameDog, float timeDelay, int hpDog, int damageDog, float scaleValue)
    {
        pointSpawnDogController.isSpawning = true;
        yield return new WaitForSeconds(timeDelay);
     
        SpawnDog(nameDog, timeDelay, hpDog, damageDog, scaleValue);

        pointSpawnDogController.dogNum += 1;
        pointSpawnDogController.CanvasController.TrackingWaveController.TrackingWave.AddNumDogCurrent();
        pointSpawnDogController.isSpawning = false;
    }

    protected virtual void SpawnDog(string nameDog, float timeDelay, int hpDog, int damageDog, float scaleValue)
    {
        Transform newDogSpawn = pointSpawnDogController.GameObjectSpawner.Spawn(nameDog, transform.position, transform.rotation).transform;

        // Avoid the sprite in same line has bug
        Vector3 newPos = newDogSpawn.position;
        newPos.z -= x;
        newDogSpawn.position = newPos;
        x += 0.01f;

        // Scale Obj
        newDogSpawn.localScale = new Vector3(scaleValue, scaleValue, 1);

        newDogSpawn.gameObject.SetActive(true);
        DogCtrl dogCtrl = newDogSpawn.GetComponent<DogCtrl>();
        dogCtrl.DogIndex.indexDog = index;
        dogCtrl.DogDamageReceiver.hpMax = hpDog;
        dogCtrl.DogDamageSender.damgeSend = damageDog;
        dogCtrl.EnableComponent();
    }
}