using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : ErshenMonoBehaviour
{
    [SerializeField] protected bool canSpawnBullet;
    [SerializeField] Spawner spawner;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawner();
    }

    protected virtual void LoadSpawner()
    {
        if (spawner != null) return;
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
    }

    private void Update()
    {
        CheckSpawnBullet();
    }

    protected virtual void CheckSpawnBullet()
    {
        if (canSpawnBullet == true)
        {
            Transform newBullet = spawner.Spawn("Bullets2", this.transform.position, this.transform.rotation);
            newBullet.gameObject.SetActive(true);
        }
    }
}
