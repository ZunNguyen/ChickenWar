using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawnBulletController : ErshenMonoBehaviour
{
    [SerializeField] protected PointSpawnBullet pointSpawnBullet;

    //[SerializeField] protected DogController dogController;
    //public DogController DogController { get => dogController; }

    [SerializeField] protected BulletSpawner bulletSpawner;
    public BulletSpawner BulletSpawner { get => bulletSpawner; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPointSpawnBullet();
        //LoadDogController();
        LoadBulletSpawner();
    }

    protected virtual void LoadPointSpawnBullet()
    {
        if (pointSpawnBullet != null) return;
        pointSpawnBullet = gameObject.GetComponentInChildren<PointSpawnBullet>();
    }

    //protected virtual void LoadDogController()
    //{
    //    if (dogController != null) return;
    //    dogController = GameObject.Find("Dog01").GetComponent<DogController>();
    //}

    protected virtual void LoadBulletSpawner()
    {
        if (bulletSpawner != null) return;
        bulletSpawner = GameObject.Find("Bullet Spawner").GetComponent<BulletSpawner>();
    }
}
