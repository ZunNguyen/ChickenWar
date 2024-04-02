using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawner : Spawner
{
    public int GetIndexChicken(Transform obj)
    {
        int index = prefabs.IndexOf(GetChickenInList(obj));
        return index;
    }

    public string GetNameChicken(int index)
    {
        string nameChicken = prefabs[index].gameObject.name;
        return nameChicken;
    }

    protected Transform GetChickenInList(Transform obj)
    {
        foreach (Transform prefab in prefabs)
        {
            if (prefab.gameObject.name == obj.gameObject.name)
            {
                return prefab;
            }
        }
        return null;
    }
}