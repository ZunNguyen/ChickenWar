using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeNameChickenSlot : ErshenMonoBehaviour
{
    [SerializeField] protected List<Transform> chickenSlots;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadChickenSlots();
    }

    protected virtual void LoadChickenSlots()
    {
        foreach (Transform chickenSlot in this.transform)
        {
            chickenSlots.Add(chickenSlot);
        }
        this.ChangName();
    }

    protected virtual void ChangName()
    {
        foreach (Transform chikenSlot in chickenSlots)
        {
            int i = chickenSlots.IndexOf(chikenSlot) + 1;
            chikenSlot.transform.name = "Chicken Upadte - " + i;
        }
    }
}
