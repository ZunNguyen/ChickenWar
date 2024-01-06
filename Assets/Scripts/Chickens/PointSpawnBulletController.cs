using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawnBulletController : ErshenMonoBehaviour
{
    [Header("Connect Script")]
    [SerializeField] protected PointSpawnBullet pointSpawnBullet;
    public PointSpawnBullet PointSpawnBullet { get => pointSpawnBullet; }

    [SerializeField] protected BulletSpawner bulletSpawner;
    public BulletSpawner BulletSpawner { get => bulletSpawner; }

    [SerializeField] protected CanvasController canvasController;
    public CanvasController CanvasController { get => canvasController; }

    [Header("Load list point spawn bullet")]
    [SerializeField] protected List<PointSpawnBullet> listPointSpawns;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPointSpawnBullet();
        LoadBulletSpawner();
        LoadCanvasController();
        LoadPointSpawnBullets();
    }

    protected virtual void LoadPointSpawnBullet()
    {
        if (pointSpawnBullet != null) return;
        pointSpawnBullet = gameObject.GetComponentInChildren<PointSpawnBullet>();
    }

    protected virtual void LoadBulletSpawner()
    {
        if (bulletSpawner != null) return;
        bulletSpawner = GameObject.Find("Bullet Spawner").GetComponent<BulletSpawner>();
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