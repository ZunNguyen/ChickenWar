using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class SpawnChicken : ErshenMonoBehaviour
{
    [Header("Load Script inside")]
    [SerializeField] protected CanvasController canvasController;

    [SerializeField] List<Transform> slots;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadListSlots();
        LoadCanvasController();
    }

    protected virtual void LoadCanvasController()
    {
        if (canvasController != null) return;
        canvasController = transform.GetComponentInParent<CanvasController>();
    }

    protected virtual void LoadListSlots()
    {
        if (slots.Count > 0) return; 
        foreach (Transform slot in this.transform.Find("Grid - Update Chicken"))
        {
            slots.Add(slot);
        }
        foreach (Transform slot in this.transform.Find("Grid - Select Chicken"))
        {
            slots.Add(slot);
        }
    }

    protected virtual void SetRaycastTargetOn(Transform prefab)
    {
        DragItem dragItem = prefab.transform.GetComponentInChildren<DragItem>();
        dragItem.SetRaycastTarget(true);
    }

    public virtual void SpawnChickenInSlot()
    {
        // Check Index of list slots
        int indexSlot = CheckSlotEmtyInList();
        // If indexSlot = 99 -> don't allow add prefab on slot
        if (indexSlot == 99) return;
        // Instantiate prefab
        InstantiatePrefab(canvasController.ButtonSpawn.nameNewChicken, indexSlot);
    }

    public void SpawnChickenHighLevel(Transform prefab, Transform parentPrefab)
    {
        string namePrefabHighLevel = canvasController.ChickenSpawner.GetNameChickenHighLevel(prefab);
        // Check Index of parentPrefabz
        int indexSlot = CheckSlotInList(parentPrefab.gameObject.name);
        // If indexSlot = 99 -> don't allow add prefab on slot
        if (indexSlot == 99) return;
        // Instantiate prefab
        Transform instance = InstantiatePrefab(namePrefabHighLevel, indexSlot);
        UpdateChickenForSpawn(instance.gameObject.name);
        
    }

    protected virtual Transform InstantiatePrefab(string namePrefab, int indexSlot)
    {
        Transform newPrefab = canvasController.ChickenSpawner.Spawn(namePrefab, this.transform.position, this.transform.rotation).transform;
        newPrefab.gameObject.SetActive(true);
        newPrefab.SetParent(slots[indexSlot]);
        SetRaycastTargetOn(newPrefab);
        return newPrefab;
    }

    protected virtual int CheckSlotEmtyInList()
    {
        foreach (Transform slot in slots)
        {
            if (slot.childCount == 0) return slots.IndexOf(slot);
        }
        return 99;
    }

    protected virtual int CheckSlotInList(string prefab)
    {
        foreach (Transform slot in slots)
        {
            if (slot.gameObject.name == prefab) return slots.IndexOf(slot);
        }
        return 99;
    }

    // Set chicken high level - 3 for Spawn Button
    protected virtual void UpdateChickenForSpawn(string nameChicken)
    {
        string S = nameChicken;
        int levelChicken = S[8];
        levelChicken -= 48;
        //Debug.Log(levelChicken);
        canvasController.ButtonSpawn.GetLevelChickenToSpawn(levelChicken);
    }
}