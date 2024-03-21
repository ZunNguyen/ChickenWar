using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointSpawnDog : ErshenMonoBehaviour
{
    [Header("Connect Script")]
    [SerializeField] protected PointSpawnDogController pointSpawnDogController;

    [Header("Variable")]
    public int index;

    public float x = 0.01f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPointSpawnDogController();
        LoadIndex();
    }

    protected virtual void LoadPointSpawnDogController()
    {
        if (pointSpawnDogController != null) return;
        pointSpawnDogController = transform.GetComponentInParent<PointSpawnDogController>();
    }

    protected virtual void LoadIndex()
    {
        if (index > 0) return;
        string name = gameObject.name;
        index = name[name.Length - 1];
        index -= 48;
    }
    
    public virtual IEnumerator Spawning(string nameDog, float timeDelay, int hpDog, int damageDog)
    {
        pointSpawnDogController.isSpawning = true;
        yield return new WaitForSeconds(timeDelay);
     
        SpawnDog(nameDog, timeDelay, hpDog, damageDog);

        pointSpawnDogController.dogNum += 1;
        pointSpawnDogController.isSpawning = false;
    }

    protected virtual void SpawnDog(string nameDog, float timeDelay, int hpDog, int damageDog)
    {
        Transform newDogSpawn = pointSpawnDogController.GameObjectSpawner.Spawn(nameDog, transform.position, transform.rotation).transform;

        Vector3 newPos = newDogSpawn.position;
        newPos.z -= x;
        newDogSpawn.position = newPos;
        x += 0.01f;

        newDogSpawn.gameObject.SetActive(true);
        DogCtrl dogCtrl = newDogSpawn.GetComponent<DogCtrl>();
        dogCtrl.DogIndex.indexDog = index;
        dogCtrl.DogDamageReceiver.hpMax = hpDog;
        dogCtrl.DogDamageSender.damgeSend = damageDog;
        dogCtrl.EnableComponent();
    }
}