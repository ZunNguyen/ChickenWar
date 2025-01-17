using System;
using UnityEngine;

public class ButtonSpawn : CanvasAbstract
{
    [Header("Connect ScriptableObject")]
    [SerializeField] protected ChickenSO chickenSO;
    [SerializeField] protected GoldUpdateChicken goldUpdateChicken;

    public int levelSpawnChicken = 0;
    public string nameNewChicken = "Chicken01";

    [Header("Variable")]
    [SerializeField] protected Int64 goldPlayer;
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
        nameNewChicken = canvasController.ChickenSpawner.GetNameChicken(levelChicken);
        // Change chicken prefab in button spawn
        ChangeChickenObj(nameNewChicken);
        // Update gold chicken spawn
        goldUpdateChicken.GetValueText(chickenSO.levels[levelSpawnChicken].goldUpdate);
    }

    protected virtual void ChangeChickenObj(string newChicken)
    {
        DragItem dragItem = this.transform.GetComponentInChildren<DragItem>();
        Transform obj = dragItem.transform;
        canvasController.ChickenSpawner.Despawn(obj);
        obj = canvasController.ChickenSpawner.Spawn(newChicken, transform.position, transform.rotation).transform;
        obj.localScale = new Vector3(1, 1, 1);
        // Set position on rect tranform
        SetPostion(obj);
        obj.SetParent(this.transform);
        obj.gameObject.SetActive(true);
        ChangePositionUI changePositionUI = obj.GetComponent<ChangePositionUI>();
        changePositionUI.SetPosition();
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
            // Audio
            canvasController.AudioManager.PlaySFX(canvasController.AudioManager.effectSpawnError);
            // Spawn Text Not Enough Gold
            canvasController.TWTextSpawner.SpawnText(transform.position, transform.rotation, "Not Enough Gold");
            return false;
        }
        
        // Check slot is full
        int checkSlot = canvasController.SpawnChicken.CheckSlotEmtyInList();
        if (checkSlot == 99)
        {
            // Audio
            canvasController.AudioManager.PlaySFX(canvasController.AudioManager.effectSpawnError);
            // Spawn Text Full Slot
            canvasController.TWTextSpawner.SpawnText(transform.position, transform.rotation, "Full Slot");
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