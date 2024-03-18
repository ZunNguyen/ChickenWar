using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Spawner : ErshenMonoBehaviour
{
    protected static Spawner instance;
    public static Spawner Instance => instance;

    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] public List<Transform> poolObjs;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadHolder();
        LoadPrefabs();
        LoadInstance();
    }

    protected virtual void LoadInstance()
    {
        if (instance != null) return;
        Spawner.instance = this;
    }

    protected virtual void LoadHolder()
    {
        if (holder != null) return;
        holder = transform.Find("Holder");
    }

    protected virtual void LoadPrefabs()
    {
        if (prefabs.Count > 0) return;
        Transform prefabsObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabsObj)
        {
            prefabs.Add(prefab);
        }
        HiddenPrefabs();
    }

    protected virtual void HiddenPrefabs()
    {
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 pos, Quaternion rot)
    {
        Transform prefabByName = GetPrefabByName(prefabName);
        if (prefabByName == null)
        {
            Debug.Log("Don't find prefab has name like:" + prefabName);
        }
        return Spawn(prefabByName, pos, rot);
    }

    public virtual Transform Spawn(Transform prefab, Vector3 pos, Quaternion rot)
    {
        Transform prefabFromPool = GetPrefabFromPool(prefab);
        prefabFromPool.SetPositionAndRotation(pos, rot);
        prefabFromPool.SetParent(holder);
        return prefabFromPool;
    }

    protected virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in prefabs)
        {
            if (prefab.name == prefabName)
            {
                return prefab;
            }
        }
        return null;
    }

    protected virtual Transform GetPrefabFromPool(Transform prefab)
    {
        foreach (Transform poolObj in poolObjs)
        {
            if (poolObj == null) continue;
            if (poolObj.name == prefab.name)
            {
                poolObjs.Remove(poolObj);
                return poolObj;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual void Despawn(Transform obj)
    {
        poolObjs.Add(obj);
        obj.SetParent(holder);
        obj.gameObject.SetActive(false);
    }
}