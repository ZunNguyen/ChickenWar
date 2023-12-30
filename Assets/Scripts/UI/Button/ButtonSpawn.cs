using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawn : ErshenMonoBehaviour
{
    [SerializeField] protected int levelSpawnChicken = 1;
    public string nameNewChicken = "Chicken01";

    public virtual void GetLevelChickenToSpawn(int levelChicken)
    {
        if (levelChicken >= 5)
        {
            int level = levelChicken - 3;
            UpdateNameChickenSpawn(level);
        }
    }

    protected virtual void UpdateNameChickenSpawn(int levelChicken)
    {
        if (levelSpawnChicken > levelChicken) return;
        levelSpawnChicken = levelChicken;
        string nameOldChicken = "Chicken0" + levelSpawnChicken.ToString();
        nameNewChicken = "Chicken0" + levelChicken.ToString();
        // Change chicken prefab in button spawn
        ChangeChickenObj(nameOldChicken, nameNewChicken);
        Debug.Log(nameNewChicken);
    }

    protected virtual void ChangeChickenObj(string oldChicken, string newChicken)
    {
        DragItem dragItem = this.transform.GetComponentInChildren<DragItem>();
        Transform obj = dragItem.transform;
        Spawner.Instance.Despawn(obj);
        obj = Spawner.Instance.Spawn(newChicken, transform.position, transform.rotation);
        // Set position on rect tranform
        SetPostion(obj);
        obj.gameObject.SetActive(true);
        obj.SetParent(this.transform);
    }

    protected virtual void SetPostion(Transform obj)
    {
        ChangePositionUI changePosition = obj.GetComponent<ChangePositionUI>();
        DragItem dragItem = obj.GetComponent<DragItem>();
        changePosition.enabled = true;
        dragItem.enabled = false;
    }
}