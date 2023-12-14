using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawnBullet : ErshenMonoBehaviour
{
    [SerializeField] protected PointSpawnBulletController pointSpawnBulletController;
    [SerializeField] protected float distance;
    [SerializeField] protected float timeCurrent;
    [SerializeField] protected float timeDelay;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPointSpawnBulletController();
    }

    protected virtual void LoadPointSpawnBulletController()
    {
        if (pointSpawnBulletController != null) return;
        pointSpawnBulletController = transform.GetComponentInParent<PointSpawnBulletController>();
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
            Transform newBullet = pointSpawnBulletController.BulletSpawner.Spawn("Bullet2", this.transform.position, this.transform.rotation);
            newBullet.gameObject.SetActive(true);
            
            timeCurrent = 0;
            GetIndexObject();
        }
    }

    protected virtual bool CheckCanSpawnBullet()
    {
        if (CheckDistance() < 10f) return true;
        else return false;
    }

    protected virtual float CheckDistance()
    {
        //Vector3 distanceDog = pointSpawnBulletController.DogController.transform.position;
        //distance = Vector3.Distance(this.transform.position, distanceDog);
        return distance;
    }

    protected virtual void GetIndexObject()
    {
        string name = this.gameObject.name;
        int index = name[name.Length - 1];
        index -= 48;
        pointSpawnBulletController.CanvasController.CheckPositionChicken.SetAnimationIndex(index);
    }
}
