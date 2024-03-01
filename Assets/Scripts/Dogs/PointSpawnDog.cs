using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawnDog : ErshenMonoBehaviour
{
    [Header("Connect Script")]
    [SerializeField] protected PointSpawnDogController pointSpawnDogController;

    [Header("Variable")]
    public int index;

    [Header("Load ScriptableObject")]
    [SerializeField] protected WaveDogSO waveDog;

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

    protected virtual void SetOffScript()
    {
        PointSpawnDog pointSpawnDog = this.transform.GetComponent<PointSpawnDog>();
        pointSpawnDog.enabled = false;
    }
    
    public virtual IEnumerator Spawning(string nameDog, float timeDelay)
    {
        pointSpawnDogController.isSpawning = true;
        yield return new WaitForSeconds(timeDelay);
        Transform newDogSpawn = pointSpawnDogController.DogSpawner.Spawn(nameDog, transform.position, transform.rotation).transform;
        newDogSpawn.gameObject.SetActive(true);
        DogCtrl dogCtrl = newDogSpawn.GetComponent<DogCtrl>();
        dogCtrl.DogIndex.indexDog = index;
        pointSpawnDogController.dogNum += 1;
        pointSpawnDogController.isSpawning = false;
    }
}