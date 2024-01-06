using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawn : CanvasAbstract
{
    [Header("Connect ScriptableObject")]
    [SerializeField] protected UpdateChickenSO updateChickenSO;

    [SerializeField] protected int levelSpawnChicken = 1;
    public string nameNewChicken = "Chicken01";

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadUpdateChickenSO();
    }

    protected virtual void LoadUpdateChickenSO()
    {
        if (updateChickenSO != null) return;
        string resPath = "SO/Update Chicken/UpdateChicken";
        updateChickenSO = Resources.Load<UpdateChickenSO>(resPath);
    }

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

    // Change Position when spawn chicken in button spawn
    protected virtual void SetPostion(Transform obj)
    {
        ChangePositionUI changePosition = obj.GetComponent<ChangePositionUI>();
        DragItem dragItem = obj.GetComponent<DragItem>();
        changePosition.enabled = true;
        dragItem.enabled = false;
    }

    public virtual void SpawnChickenInGrid()
    {
        if (!CanSpawn()) return;
        canvasController.SpawnChicken.SpawnChickenInSlot();
    }

    protected virtual bool CanSpawn()
    {
        // Enough money
        float goldPlayer = canvasController.GoldPlayer.gold;
        float goldSpawn = updateChickenSO.levels[levelSpawnChicken-1].gold;
        if (goldPlayer < goldSpawn)
        {
            Debug.Log("Don't have enough gold to spawn");
            return false;
        }
        canvasController.GoldPlayer.gold = goldPlayer - goldSpawn;
        return true;
    }
}