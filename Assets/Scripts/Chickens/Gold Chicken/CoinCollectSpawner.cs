using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinCollectSpawner : ErshenMonoBehaviour
{
    protected static CoinCollectSpawner instance;
    public static CoinCollectSpawner Instance { get => instance; }

    [SerializeField] protected GameObject holder;
    [SerializeField] protected List<GameObject> prefabs;
    [SerializeField] public List<GameObject> poolObjs;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadInstance();
        LoadHolder();
        LoadPrefabs();
    }

    protected virtual void LoadInstance()
    {
        if (instance != null) return;
        CoinCollectSpawner.instance = this;
    }
    protected virtual void LoadHolder()
    {
        if (holder != null) return;
        holder = transform.Find("Holder").gameObject;
    }

    protected virtual void LoadPrefabs()
    {
        if (prefabs.Count > 0) return;
        Transform prefabsObj = this.transform.Find("Prefabs");
        foreach (Transform prefab in prefabsObj)
        {
            prefabs.Add(prefab.gameObject);
        }
        HiddenPrefabs();
    }

    protected virtual void HiddenPrefabs()
    {
        foreach (GameObject prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual GameObject Spawn(string prefabName, Vector3 pos, Quaternion rot)
    {
        GameObject prefabByName = GetPrefabByName(prefabName);
        if (prefabByName == null)
        {
            Debug.Log("Don't find prefab has name like:" + prefabName);
        }
        return Spawn(prefabByName, pos, rot);
    }

    public virtual GameObject Spawn(GameObject prefab, Vector3 pos, Quaternion rot)
    {
        GameObject prefabFromPool = GetPrefabFromPool(prefab.transform);
        prefabFromPool.transform.SetPositionAndRotation(pos, rot);
        prefabFromPool.transform.SetParent(holder.transform);
        return prefabFromPool;
    }

    protected virtual GameObject GetPrefabByName(string prefabName)
    {
        foreach (GameObject prefab in prefabs)
        {
            if (prefab.name == prefabName)
            {
                return prefab;
            }
        }
        return null;
    }

    protected virtual GameObject GetPrefabFromPool(Transform prefab)
    {
        foreach (GameObject poolObj in poolObjs)
        {
            if (poolObj == null) continue;
            if (poolObj.name == prefab.name)
            {
                poolObjs.Remove(poolObj);
                return poolObj;
            }
        }
        GameObject newPrefab = Instantiate(prefab).gameObject;
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual void Despawn(GameObject obj)
    {
        poolObjs.Add(obj);
        obj.transform.SetParent(holder.transform);
        obj.SetActive(false);
    }
}