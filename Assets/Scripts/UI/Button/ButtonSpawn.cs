using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawn : CanvasAbstract
{
    [Header("Connect ScriptableObject")]
    [SerializeField] protected ChickenSO chickenSO;
    [SerializeField] protected GoldUpdateChicken goldUpdateChicken;

    public int levelSpawnChicken = 0;
    public string nameNewChicken = "Chicken01";

    [Header("Variable")]
    [SerializeField] protected int goldPlayer;
    [SerializeField] protected int goldUpdate;
    public int highestLevelChicken = 0;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadChickenSO();
        LoadSpawnUpdateChicken();
    }

    protected virtual void LoadChickenSO()
    {
        if (chickenSO != null) return;
        string resPath = "SO/Chickens/Chickens";
        chickenSO = Resources.Load<ChickenSO>(resPath);
    }

    protected virtual void LoadSpawnUpdateChicken()
    {
        if (goldUpdateChicken != null) return;
        goldUpdateChicken = transform.GetComponentInChildren<GoldUpdateChicken>();
    }

    private void Start()
    {
        LoadBeginGame();
    }

    protected virtual void LoadBeginGame()
    {
        GetLevelChickenToSpawn(highestLevelChicken);
        UpdateGoldChickenSpawn();
    }

    public virtual void GetLevelChickenToSpawn(int levelChicken)
    {
        // When chicken have level 0,1,2,3 -> level update chicken still 1
        if (levelChicken >= 4)
        {
            int level = levelChicken - 3;
            UpdateNameChickenSpawn(level);
        }
    }

    protected virtual void UpdateNameChickenSpawn(int levelChicken)
    {
        // Prevent bug
        if (levelSpawnChicken > levelChicken) return;
        levelSpawnChicken = levelChicken;
        // Get name chicken
        nameNewChicken = ChickenSpawner.Instance.GetNameChicken(levelChicken);
        // Change chicken prefab in button spawn
        ChangeChickenObj(nameNewChicken);
        // Update gold chicken spawn
        goldUpdateChicken.GetValueText(chickenSO.levels[levelSpawnChicken].goldUpdate);
    }

    protected virtual void ChangeChickenObj(string newChicken)
    {
        DragItem dragItem = this.transform.GetComponentInChildren<DragItem>();
        Transform obj = dragItem.transform;
        ChickenSpawner.Instance.Despawn(obj);
        obj = ChickenSpawner.Instance.Spawn(newChicken, transform.position, transform.rotation).transform;
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

        // SFX
        canvasController.AudioManager.PlaySFX(canvasController.AudioManager.effectSpawnButton);

        canvasController.SpawnChicken.SpawnChickenInSlot();

        // Subtract money
        canvasController.GoldPlayer.SubtractGoldPlayer(goldUpdate);
    }

    protected virtual bool CanSpawn()
    {
        // Enough money
        goldPlayer = canvasController.GoldPlayer.gold;
        goldUpdate = chickenSO.levels[levelSpawnChicken].goldUpdate;
        if (goldPlayer < goldUpdate)
        {
            Debug.Log("Don't have enough gold to spawn");

            // Audio
            canvasController.AudioManager.PlaySFX(canvasController.AudioManager.effectSpawnError);

            // Spawn Text Not Enough Gold
            GameObject newPrefab = CoinCollectSpawner.Instance.Spawn("Not Enough Gold", transform.position, transform.rotation);
            NotEnoughGold notEnoughGold = newPrefab.GetComponent<NotEnoughGold>();
            notEnoughGold.TWTextOn();
            newPrefab.SetActive(true);

            return false;
        }
        
        // Check slot is full
        int checkSlot = canvasController.SpawnChicken.CheckSlotEmtyInList();
        if (checkSlot == 99)
        {
            Debug.Log("Full slot");
            return false;
        }        
        return true;
    }

    protected virtual void UpdateGoldChickenSpawn()
    {
        //if (levelSpawnChicken - 1 < 0) return;
        goldUpdateChicken.GetValueText(chickenSO.levels[levelSpawnChicken].goldUpdate);
    }
}