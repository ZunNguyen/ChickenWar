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

    public virtual void SetAnimationIndex(int index)
    {
        nameObj = chickenSlots[index - 1];
        animationGun = nameObj.GetComponentInChildren<AnimationGun>();
        animationGun.SetAnimationOn();
    }

    public virtual bool HaveChickenInSlot(int indexSlot)
    {
        if (chickenSlots[indexSlot].childCount == 0) return false;
        return true;
    }

    public virtual string GetNameBullet(int indexSlot)
    {
        ChickenController chickenController = chickenSlots[indexSlot].transform.GetComponentInChildren<ChickenController>();
        string nameBullet = chickenController.ChickenGun.nameBullet;
        return nameBullet;
    }

    public virtual int GetDamageBullet(int indexSlot)
    {
        ChickenController chickenController = chickenSlots[indexSlot].transform.GetComponentInChildren<ChickenController>();
        int damageBullet = chickenController.ChickenGun.damage;
        return damageBullet;
    }
}