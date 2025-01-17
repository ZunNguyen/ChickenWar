using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawnBullet : LoadIndexObj
{
    [Header("Connect Script")]
    [SerializeField] protected PointSpawnBulletCtrl pointSpawnBulletCtrl;

    [Header("Value")]
    [SerializeField] protected float timeCurrent;
    [SerializeField] protected float timeDelay = 1;
    public int levelChicken;

    [Header("Shooting system")]
    public List<Transform> listDog;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPointSpawnBulletCtrl();
        TurnOffScript();
    }

    protected virtual void LoadPointSpawnBulletCtrl()
    {
        if (pointSpawnBulletCtrl != null) return;
        pointSpawnBulletCtrl = transform.GetComponentInParent<PointSpawnBulletCtrl>();
    }

    protected virtual void TurnOffScript()
    {
        PointSpawnBullet pointSpawnBullet = this.gameObject.GetComponent<PointSpawnBullet>();
        pointSpawnBullet.enabled = false;
    }

    private void Update()
    {
        SpawningBullet();
    }

    protected virtual void SpawningBullet()
    {
        if (CanSpawnBullet())
        {
            SpawnBulletByTime();
        }
    }

    // Spawning bullet
    public virtual void SpawnBulletByTime()
    {
        timeCurrent += Time.deltaTime;
        if (timeCurrent < timeDelay) return;
        if (timeCurrent >= timeDelay)
        {
            SpawnBullet();
            timeCurrent = 0;
            //Set Animation for gun
            CanvasCtrl.Instance.CheckPositionChicken.SetAnimationIndex(index);
        }
    }

    protected virtual void SpawnBullet()
    {
        // Set information bullet
        string nameBullet = CanvasCtrl.Instance.CheckPositionChicken.GetNameBullet(index - 1);
        int damageBullet = CanvasCtrl.Instance.CheckPositionChicken.GetDamageBullet(index - 1);
        GameObject newBullet = pointSpawnBulletCtrl.GameObjectSpawner.Spawn(nameBullet, this.transform.position, this.transform.rotation);
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.BulletMovement.objTarget = GetTransNearestObj();
        bulletCtrl.BulletDamSender.damge = damageBullet;
        newBullet.SetActive(true);
    }

    protected virtual bool CanSpawnBullet()
    {
        // Check have dog in line
        if (!HaveDogInLine()) return false;

        // Check chicken in line
        if (!CanvasCtrl.Instance.CheckPositionChicken.HaveChickenInSlot(index - 1)) return false;
        return true;
    }

    protected virtual bool HaveDogInLine()
    {
        RemoveTransformDisable();
        if (listDog.Count == 0) return false;
        return true;
    }

    // Remove transform disable in list
    protected virtual void RemoveTransformDisable()
    {
        foreach (Transform dog in listDog)
        {
            if (dog.gameObject.activeSelf == false)
            {
                listDog.Remove(dog);
                return;
            }
        }
    }

    protected virtual Transform GetTransNearestObj()
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform dog in listDog)
        {
            float dist = Vector3.Distance(currentPos, dog.transform.position);
            if (dist < minDist)
            {
                tMin = dog;
                minDist = dist;
            }
        }
        return tMin;
    }
}