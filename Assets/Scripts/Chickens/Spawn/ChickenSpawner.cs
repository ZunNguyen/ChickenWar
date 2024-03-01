using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChickenSpawner : Spawner
{
    public string GetNameChickenHighLevel(Transform obj)
    {
        int index = prefabs.IndexOf(GetChickenInList(obj));
        index += 1;
        string nameChicken = prefabs[index].gameObject.name;
        return nameChicken;
    }

    protected Transform GetChickenInList(Transform obj)
    {
        //Debug.Log(obj.gameObject.name);
        foreach (Transform prefab in prefabs)
        {
            if (prefab.gameObject.name == obj.gameObject.name)
            {
                //Debug.Log(prefab.gameObject.name);
                return prefab;
            }
        }
        return null;
    }
}