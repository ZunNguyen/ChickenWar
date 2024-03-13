using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class SpawnChicken : CanvasAbstract
{
    [SerializeField] List<Transform> slots;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadListSlots();
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
        int indexChicken = canvasController.ChickenSpawner.GetIndexChicken(prefab);
        string namePrefabHighLevel = canvasController.ChickenSpawner.GetNameChicken(indexChicken + 1);
        // Check Index of parentPrefabz
        int indexSlot = CheckSlotInList(parentPrefab.transform);
        // If indexSlot = 99 -> don't allow add prefab on slot
        //if (indexSlot == 99) return;
        // Instantiate prefab
        Transform chickenHigherLV = InstantiatePrefab(namePrefabHighLevel, indexSlot);
        // Show aniamtion update new chicken higher level
        canvasController.TWUpgradeChicken.ProcessShowUpgradePanel(indexChicken + 1, prefab, chickenHigherLV);
        UpdateChickenForSpawn(chickenHigherLV.gameObject.name);
    } 

    // Spawn chicken
    public virtual Transform InstantiatePrefab(string namePrefab, int indexSlot)
    {
        Transform newPrefab = canvasController.ChickenSpawner.Spawn(namePrefab, this.transform.position, this.transform.rotation);
        newPrefab.gameObject.SetActive(true);
        newPrefab.SetParent(slots[indexSlot]);
        SetRaycastTargetOn(newPrefab);
        return newPrefab;
    }

    public virtual int CheckSlotEmtyInList()
    {
        foreach (Transform slot in slots)
        {
            if (slot.childCount == 0) return slots.IndexOf(slot);
        }
        return 99;
    }

    protected virtual int CheckSlotInList(Transform prefab)
    {
        //foreach (Transform slot in slots)
        //{
        //    if (slot.gameObject.name == prefab) return slots.IndexOf(slot);
        //}
        //return 99;

        return slots.IndexOf(prefab);
    }

    // Set chicken high level - 3 for Spawn Button
    protected virtual void UpdateChickenForSpawn(string nameChicken)
    {
        string S = nameChicken;
        int levelChicken = S[8];
        levelChicken -= 48;

        if (levelChicken > canvasController.ButtonSpawn.highestLevelChicken) canvasController.ButtonSpawn.highestLevelChicken = levelChicken;
        canvasController.ButtonSpawn.GetLevelChickenToSpawn(levelChicken);
    }

    // For save game
    public virtual void SaveSlotChicken(List<int> _indexSlot, List<string> _nameChicken)
    {
        foreach (Transform slot in slots)
        {
            if (slot.childCount > 0)
            {
                _indexSlot.Add(slots.IndexOf(slot));
                _nameChicken.Add(slot.GetChild(0).gameObject.name);
            }
        }
    }
}