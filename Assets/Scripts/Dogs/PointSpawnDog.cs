using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawnDog : ErshenMonoBehaviour
{
    [Header("Connect Script")]
    [SerializeField] protected PointSpawnDogController pointSpawnDogController;

    [Header("Variable")]
    [SerializeField] protected float currentTime = 0f;
    [SerializeField] protected float timeDelay = 2f;

    private void Update()
    {
        Spawning();
    }

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

    protected virtual void Spawning()
    {
        currentTime += Time.deltaTime;
        if (currentTime < timeDelay) return;
        if (currentTime > timeDelay)
        {
            Transform newDogSpawn = pointSpawnDogController.DogSpawner.Spawn("Dog01", transform.position, transform.rotation);
            newDogSpawn.gameObject.SetActive(true);
            currentTime = 0;
        }
    }
}
