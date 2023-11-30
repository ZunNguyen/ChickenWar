using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : ErshenMonoBehaviour
{
    //[SerializeField] protected ChickenController chickenController;
    [SerializeField] protected float distance;
    [SerializeField] protected float timeCurrent;
    [SerializeField] protected float timeDelay;
    [SerializeField] Spawner spawner;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawner();
        //this.LoadChickenController();
    }

    //protected virtual void LoadChickenController()
    //{
    //    if (chickenController != null) return;
    //    chickenController = transform.GetComponentInParent<ChickenController>();
    //}

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
        if (CheckCanSpawnBullet() == true)
        {
            SpawnBulletByTime();
        }
    }

    protected virtual void SpawnBulletByTime()
    {
        timeCurrent += Time.deltaTime;
        if (timeCurrent < timeDelay) return;
        if (timeCurrent >= timeDelay)
        {
            Transform newBullet = spawner.Spawn("Bullets2", this.transform.position, this.transform.rotation);
            newBullet.gameObject.SetActive(true);
            timeCurrent = 0;
        }
    }

    protected virtual bool CheckCanSpawnBullet()
    {
        if (CheckDistance() < 10f) return true;
        else return false;
    }

    protected virtual float CheckDistance()
    {
        //distance = Vector3.Distance(chickenController.transform.position, chickenController.DogController.transform.position);
        return distance;
    }
}
