using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPositionSpawnPoint : ErshenMonoBehaviour
{
    [SerializeField] protected List<Transform> listPointSpawns;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPointSpawnBullets();
    }

    protected virtual void LoadPointSpawnBullets()
    {
        if (listPointSpawns.Count > 0) return;
        foreach(Transform poinSpawn in this.transform)
        {
            listPointSpawns.Add(poinSpawn);
        }
    }

    public virtual void BulletOn(int index, string updateBulletName)
    {
        PointSpawnBullet pointSpawnBullet = listPointSpawns[index].GetComponent<PointSpawnBullet>();
        pointSpawnBullet.enabled = true;
        pointSpawnBullet.bulletName = updateBulletName;
    }

    public virtual void BulletOff(int index)
    {
        PointSpawnBullet pointSpawnBullet = listPointSpawns[index].GetComponent<PointSpawnBullet>();
        pointSpawnBullet.enabled = false;
    }
}
