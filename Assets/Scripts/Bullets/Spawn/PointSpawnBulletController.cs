using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawnBulletController : ErshenMonoBehaviour
{
    [Header("Connect InSide")]
    [SerializeField] protected PointSpawnBullet pointSpawnBullet;
    public PointSpawnBullet PointSpawnBullet { get => pointSpawnBullet; }

    [Header("Connect OutSide")]
    [SerializeField] protected GameObjectSpawner gameObjectSpawner;
    public GameObjectSpawner GameObjectSpawner => gameObjectSpawner;

    [Header("Load list point spawn bullet")]
    [SerializeField] protected List<PointSpawnBullet> listPointSpawns;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPointSpawnBullet();
        LoadGameObjectSpawner();
        LoadPointSpawnBullets();
    }

    protected virtual void LoadPointSpawnBullet()
    {
        if (pointSpawnBullet != null) return;
        pointSpawnBullet = gameObject.GetComponentInChildren<PointSpawnBullet>();
    }

    protected virtual void LoadGameObjectSpawner()
    {
        if (gameObjectSpawner != null) return;
        gameObjectSpawner = GameObject.Find("GameObject Spawner").GetComponent<GameObjectSpawner>();
    }

    protected virtual void LoadPointSpawnBullets()
    {
        if (listPointSpawns.Count > 0) return;
        foreach (Transform poinSpawn in this.transform)
        {
            PointSpawnBullet pointSpawnBullet = poinSpawn.GetComponentInChildren<PointSpawnBullet>();
            listPointSpawns.Add(pointSpawnBullet);
        }
    }

    public virtual void BulletOn()
    {
        foreach (PointSpawnBullet pointSpawnBullet in listPointSpawns)
        {
            pointSpawnBullet.enabled = true;
        }
    }

    public virtual void BulletOff()
    {
        foreach (PointSpawnBullet pointSpawnBullet in listPointSpawns)
        {
            pointSpawnBullet.enabled = false;
        }
    }
}