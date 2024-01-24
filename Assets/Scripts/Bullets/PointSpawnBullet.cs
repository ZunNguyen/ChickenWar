using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawnBullet : ErshenMonoBehaviour
{
    [Header("Connect Script")]
    [SerializeField] protected PointSpawnBulletController pointSpawnBulletController;

    [Header("Value")]
    [SerializeField] protected float timeCurrent;
    [SerializeField] protected float timeDelay = 1;
    [SerializeField] protected int index;
    public int levelChicken;

    [Header("Shooting system")]
    public List<Transform> listDog;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPointSpawnBulletController();
        LoadIndex();
        TurnOffScript();
    }

    protected virtual void LoadPointSpawnBulletController()
    {
        if (pointSpawnBulletController != null) return;
        pointSpawnBulletController = transform.GetComponentInParent<PointSpawnBulletController>();
    }

    protected virtual void LoadIndex()
    {
        if (index > 0) return;
        string name = gameObject.name;
        index = name[name.Length - 1];
        index -= 48;
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
            // Get name chicken
            levelChicken = pointSpawnBulletController.CanvasController.CheckPositionChicken.GetIndexChickenInList(index - 1);
            pointSpawnBulletController.CanvasController.PointSpawnBulletController.BulletSpawner.BulletCtrl.BulletDamSender.GetDamgeBullet(levelChicken);
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
            Transform newBullet = pointSpawnBulletController.BulletSpawner.Spawn("Bullet", this.transform.position, this.transform.rotation);
            BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
            bulletCtrl.BulletMovement.objTarget = listDog[0];
            newBullet.gameObject.SetActive(true);
            timeCurrent = 0;

            //Set Animation for gun
            pointSpawnBulletController.CanvasController.CheckPositionChicken.SetAnimationIndex(index);
        }
    }

    protected virtual bool CanSpawnBullet()
    {
        // Check have dog in line
        if (!HaveDogInLine()) return false;

        // Check chicken in line
        if (!pointSpawnBulletController.CanvasController.CheckPositionChicken.HaveChickenInSlot(index - 1)) return false;
        return true;
    }

    protected virtual bool HaveDogInLine()
    {
        RemoveTransform();
        if (listDog.Count == 0) return false;
        return true;
    }

    // Remove transform enable in list
    protected virtual void RemoveTransform()
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

    protected virtual void GetTransNearestObj()
    {
        foreach (Transform dog in listDog)
        {
            
        }
    }
}