using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPositionChicken : ErshenMonoBehaviour
{
    [SerializeField] protected CanvasController canvasController;

    [SerializeField] protected List<Transform> chickenSlots;

    [SerializeField] protected AnimationGun animationGun;

    public Transform nameObj;

    public bool testCheckPosition = false;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadChickenSlots();
        LoadCanvasController();
    }

    protected virtual void LoadChickenSlots()
    {
        if (chickenSlots.Count > 0) return;
        foreach(Transform chickenSlot in this.transform)
        {
            chickenSlots.Add(chickenSlot);
        }
    }

    protected virtual void LoadCanvasController()
    {
        if (canvasController != null) return;
        canvasController = GetComponentInParent<CanvasController>();
    }

    protected void Update()
    {
        //if (testCheckPosition)
        //CheckSlotChicken();
    }

    //protected virtual void CheckSlotChicken()
    //{
    //    foreach (Transform chickenSlot in chickenSlots)
    //    {
    //        if (chickenSlot.transform.childCount == 0)
    //        {
    //            int index = chickenSlots.IndexOf(chickenSlot);
    //            canvasController.CheckPositionSpawnPoint.BulletOff(index);
    //        }
    //        else if (chickenSlot.transform.childCount > 0)
    //        {
    //            int index = chickenSlots.IndexOf(chickenSlot);
    //            string bulletName = GetNameBullet(index);
    //            canvasController.CheckPositionSpawnPoint.BulletOn(index, bulletName);
    //        }
    //    }
    //}

    public virtual void SetAnimationIndex(int index)
    {
        nameObj = chickenSlots[index - 1];
        animationGun = nameObj.GetComponentInChildren<AnimationGun>();
        animationGun.SetAnimationOn();
    }

    protected virtual string GetNameBullet(int index)
    {
        nameObj = chickenSlots[index];
        ChickenGun chickenGun = nameObj.GetComponentInChildren<ChickenGun>();
        string bullet = chickenGun.nameBullet;
        return bullet;
    }

    public virtual bool HaveChickenInSlot(int indexSlot)
    {
        if (chickenSlots[indexSlot].childCount == 0) return false;
        return true;
    }

    public virtual int GetIndexChickenInList(int indexSlot)
    {
        ChickenController chickenController = chickenSlots[indexSlot].transform.GetComponentInChildren<ChickenController>();
        string nameChicken = chickenController.gameObject.name;
        return chickenController.ChickenSO.GetIndexChicken(nameChicken);
    }
}