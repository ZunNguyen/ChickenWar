using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoadPrefabChicken : ErshenMonoBehaviour
{
    //[SerializeField] private Object[] prefabs;
    [SerializeField] protected int maxPrefabs = 10;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadChickenInResource();
    }

    protected virtual void LoadChickenInResource()
    {
        if (this.transform.childCount > 0) return;
        Transform[] prefabs = Resources.LoadAll<Transform>("Prefabs/Chickens");
        foreach(Transform prefab in prefabs)
        {
            Transform newPrefab = Instantiate(prefab);
            newPrefab.name = prefab.name;
            newPrefab.SetParent(this.transform);
        }
    }
}