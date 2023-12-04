using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawnDogController : ErshenMonoBehaviour
{
    [Header("Connect Script outside")]
    [SerializeField] protected DogSpawner dogSpawner;
    public DogSpawner DogSpawner { get => dogSpawner; }

    [Header("Connect Script childrent")]
    [SerializeField] protected PointSpawnDog pointSpawnDog;
    public PointSpawnDog PointSpawnDog { get => pointSpawnDog; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadDogSpawner();
        LoadPointSpawnDog();
    }

    protected virtual void LoadDogSpawner()
    {
        if (dogSpawner != null) return;
        dogSpawner = GameObject.Find("Dog Spawner").GetComponent<DogSpawner>();
    }

    protected virtual void LoadPointSpawnDog()
    {
        if (pointSpawnDog != null) return;
        pointSpawnDog = transform.GetComponentInChildren<PointSpawnDog>();
    }
}
