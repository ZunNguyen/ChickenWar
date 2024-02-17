using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawnDogController : ErshenMonoBehaviour
{
    [Header("Connect Script Outside")]
    [SerializeField] protected DogSpawner dogSpawner;
    public DogSpawner DogSpawner { get => dogSpawner; }

    [Header("Connect Script Childrent")]
    [SerializeField] protected List<PointSpawnDog> listPointSpawnDog;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadDogSpawner();
        LoadListPointSpawnDog();
    }

    protected virtual void LoadDogSpawner()
    {
        if (dogSpawner != null) return;
        dogSpawner = GameObject.Find("Dog Spawner").GetComponent<DogSpawner>();
    }

    protected virtual void LoadListPointSpawnDog()
    {
        if (listPointSpawnDog.Count > 0) return;
        foreach (Transform obj in this.transform)
        {
            PointSpawnDog pointSpawnDog = obj.GetComponent<PointSpawnDog>();
            listPointSpawnDog.Add(pointSpawnDog);
        }
    }

    public virtual void OnList()
    {
        foreach (PointSpawnDog pointSpawnDog in listPointSpawnDog)
        {
            pointSpawnDog.enabled = true;
        }
    }

    public virtual void OffList()
    {
        foreach (PointSpawnDog pointSpawnDog in listPointSpawnDog)
        {
            pointSpawnDog.enabled = false;
        }
    }
}