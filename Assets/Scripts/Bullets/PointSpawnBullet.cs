using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawnBullet : ErshenMonoBehaviour
{
    [SerializeField] protected PointSpawnBulletController pointSpawnBulletController;
    [SerializeField] protected float distance;
    [SerializeField] protected float timeCurrent;
    [SerializeField] protected float timeDelay = 1;
    [SerializeField] protected int index;
    public int levelChicken;

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
        CheckSpawnBullet();
    }

    protected virtual void CheckSpawnBullet()
    {
        if (CanSpawnBullet() == true)
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
            newBullet.gameObject.SetActive(true);
            timeCurrent = 0;

            //Set Animation
            pointSpawnBulletController.CanvasController.CheckPositionChicken.SetAnimationIndex(index);
            //GetIndexObject();
        }
    }

    protected virtual bool CanSpawnBullet()
    {
        // Check have dog in line
        if (!HaveDogInLine()) return false;

        // Check chicken in line
        if (!pointSpawnBulletController.CanvasController.CheckPositionChicken.HaveChickenInSlot(index - 1)) return false;
        return true;

        // 

        //if (CheckDistance() < 10f) return true;
        //else return false;
    }

    protected virtual bool HaveDogInLine()
    {
        return true;
    }

    //protected virtual float CheckDistance()
    //{
    //    //Vector3 distanceDog = pointSpawnBulletController.DogController.transform.position;
    //    //distance = Vector3.Distance(this.transform.position, distanceDog);
    //    return distance;
    //}

    //protected virtual void GetIndexObject()
    //{
    //    string name = this.gameObject.name;
    //    index = name[name.Length - 1];
    //    index -= 48;
    //    pointSpawnBulletController.CanvasController.CheckPositionChicken.SetAnimationIndex(index);
    //}
}