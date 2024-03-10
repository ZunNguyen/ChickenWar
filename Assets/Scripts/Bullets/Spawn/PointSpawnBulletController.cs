using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawnBulletController : ErshenMonoBehaviour
{
    [Header("Connect Script")]
    [SerializeField] protected PointSpawnBullet pointSpawnBullet;
    public PointSpawnBullet PointSpawnBullet { get => pointSpawnBullet; }

    [SerializeField] protected GameObjectSpawner gameObjectSpawner;
    public GameObjectSpawner GameObjectSpawner => gameObjectSpawner;

    [SerializeField] protected CanvasController canvasController;
    public CanvasController CanvasController { get => canvasController; }

    [Header("Load list point spawn bullet")]
    [SerializeField] protected List<PointSpawnBullet> listPointSpawns;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPointSpawnBullet();
        LoadGameObjectSpawner();
        LoadCanvasController();
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

    protected virtual void LoadCanvasController()
    {
        if (canvasController != null) return;
        canvasController = GameObject.Find("Canvas").GetComponent<CanvasController>();
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