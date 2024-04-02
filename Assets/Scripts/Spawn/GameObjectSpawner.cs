using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSpawner : Spawner
{
    [Header("---Instance---")]
    protected static GameObjectSpawner instance;
    public static GameObjectSpawner Instance => instance;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadInstance();
    }

    protected virtual void LoadInstance()
    {
        if (instance != null) return;
        instance = this;
    }

    public virtual void OffMovementObjInHolder()
    {
        foreach (Transform obj in holder)
        {
            if (obj.gameObject.activeSelf && obj.CompareTag("Dog"))
            {
                DogCtrl dogCtrl = obj.GetComponent<DogCtrl>();
                dogCtrl.DisaleComponents();
            }
        }
    }

    public virtual void OffObjInHolder()
    {
        foreach(Transform obj in holder)
        {
            if (obj.gameObject.activeSelf) obj.gameObject.SetActive(false);
        }
    }
}
