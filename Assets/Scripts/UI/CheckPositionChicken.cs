using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPositionChicken : ErshenMonoBehaviour
{
    [SerializeField] protected CanvasController canvasController;

    [SerializeField] protected List<Transform> chickenSlots;

    [SerializeField] protected AnimationGun animationGun;

    [SerializeField] protected Transform nameObj;

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
        if (testCheckPosition)
            CheckSlotChicken();
    }

    protected virtual void CheckSlotChicken()
    {
        foreach (Transform chickenSlot in chickenSlots)
        {
            if (chickenSlot.transform.childCount == 0)
            {
                int index = chickenSlots.IndexOf(chickenSlot);
                canvasController.CheckPositionSpawnPoint.BulletOff(index);
            }
            else if (chickenSlot.transform.childCount > 0)
            {
                int index = chickenSlots.IndexOf(chickenSlot);
                canvasController.CheckPositionSpawnPoint.BulletOn(index);
            }
        }
    }

    public virtual void SetAnimationIndex(int index)
    {
        nameObj = chickenSlots[index - 1];
        Debug.Log(nameObj.name);
        animationGun = nameObj.GetComponentInChildren<AnimationGun>();
        animationGun.SetAnimationOn();
    }
}
