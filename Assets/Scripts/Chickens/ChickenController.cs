using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : ErshenMonoBehaviour
{
    [SerializeField] protected BulletSpawn bulletSpawn;
    [SerializeField] protected DogController dogController;
    public DogController DogController { get => dogController; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadBulletSpawn();
        LoadDogController();
    }

    protected virtual void LoadBulletSpawn()
    {
        if (bulletSpawn != null) return;
        bulletSpawn = gameObject.GetComponentInChildren<BulletSpawn>();
    }

    protected virtual void LoadDogController()
    {
        if (dogController != null) return;
        dogController = GameObject.Find("Dog01").GetComponent<DogController>();
    }
}
