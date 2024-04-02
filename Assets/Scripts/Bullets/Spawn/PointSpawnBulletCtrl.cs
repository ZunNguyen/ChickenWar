using System.Collections.Generic;
using UnityEngine;

public class PointSpawnBulletCtrl : ErshenMonoBehaviour
{
    [Header("Connect OutSide")]
    [SerializeField] protected GameObjectSpawner gameObjectSpawner;
    public GameObjectSpawner GameObjectSpawner => gameObjectSpawner;

    [Header("Load list point spawn bullet")]
    [SerializeField] protected List<PointSpawnBullet> listPointSpawns;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadGameObjectSpawner();
        LoadPointSpawnBullets();
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