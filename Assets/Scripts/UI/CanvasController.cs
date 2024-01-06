using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : ErshenMonoBehaviour
{
    [Header("Load Script Outside")]

    [SerializeField] protected PointSpawnBulletController pointSpawnBulletController;
    public PointSpawnBulletController PointSpawnBulletController => pointSpawnBulletController;

    [Header("Load Script inside")]
    [SerializeField] protected ChickenSpawner chickenSpawner;
    public ChickenSpawner ChickenSpawner => chickenSpawner;
    [SerializeField] protected CheckPositionChicken checkPositionChicken;
    public CheckPositionChicken CheckPositionChicken => checkPositionChicken;

    [SerializeField] protected DragItem dragItem;
    public DragItem DragItem => dragItem;

    [SerializeField] protected SpawnChicken spawnChicken;
    public SpawnChicken SpawnChicken => spawnChicken;

    [SerializeField] protected ButtonSpawn buttonSpawn;
    public ButtonSpawn ButtonSpawn => buttonSpawn;
    
    [SerializeField] protected GoldPlayer goldPlayer;
    public GoldPlayer GoldPlayer => goldPlayer;   

    [Header("Load script for shield")]
    [SerializeField] protected ShieldUpdate shieldUpdate;
    public ShieldUpdate ShieldUpdate => shieldUpdate;

    [SerializeField] protected ShieldGoldUpdate shieldGoldUpdate;
    public ShieldGoldUpdate ShieldGoldUpdate => shieldGoldUpdate;

    [SerializeField] protected ShieldHPBar shieldHPBar;
    public ShieldHPBar ShieldHPBar => shieldHPBar;

    [SerializeField] protected ShieldHPSum shieldHPSum;
    public ShieldHPSum ShieldHPSum => shieldHPSum;

    [SerializeField] protected ShieldHPText shieldHPText;
    public ShieldHPText ShieldHPText => shieldHPText;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadChickenSpawner();
        LoadDragItem();
        LoadSpawnChicken();
        LoadButtonSpawn();
        LoadCheckPositionChicken();
        LoadPointSpawnBulletController();
        LoadGoldPlayer();

        // Load Script for Shield
        LoadShieldGoldUpdate();
        LoadShieldUpdate();
        LoadShieldSumHP();
        LoadShielHPBar();
        LoadShieldHPText();
    }

    protected virtual void LoadChickenSpawner()
    {
        if (chickenSpawner != null) return;
        chickenSpawner = transform.GetComponentInChildren<ChickenSpawner>();
    }

    protected virtual void LoadDragItem()
    {
        if (dragItem != null) return;
        dragItem = transform.GetComponentInChildren<DragItem>();
    }

    protected virtual void LoadSpawnChicken()
    {
        if (spawnChicken != null) return;
        spawnChicken = transform.GetComponentInChildren<SpawnChicken>();
    }

    protected virtual void LoadButtonSpawn()
    {
        if (buttonSpawn != null) return;
        buttonSpawn = transform.GetComponentInChildren<ButtonSpawn>();
    }

    protected virtual void LoadCheckPositionChicken()
    {
        if (checkPositionChicken != null) return;
        checkPositionChicken = transform.GetComponentInChildren<CheckPositionChicken>();
    }

    protected virtual void LoadPointSpawnBulletController()
    {
        if (pointSpawnBulletController != null) return;
        pointSpawnBulletController = GameObject.Find("Point Spawn Bullet").GetComponentInChildren<PointSpawnBulletController>();
    }

    protected virtual void LoadShieldSumHP()
    {
        if (shieldHPSum != null) return;
        shieldHPSum = GameObject.Find("Shields").GetComponent<ShieldHPSum>();
    }

    protected virtual void LoadShielHPBar()
    {
        if (shieldHPBar != null) return;
        shieldHPBar = transform.GetComponentInChildren<ShieldHPBar>();
    }

    protected virtual void LoadGoldPlayer()
    {
        if (goldPlayer != null) return;
        goldPlayer = transform.GetComponentInChildren<GoldPlayer>();
    }

    protected virtual void LoadShieldGoldUpdate()
    {
        if (shieldGoldUpdate != null) return;
        shieldGoldUpdate = transform.GetComponentInChildren<ShieldGoldUpdate>();
    }

    protected virtual void LoadShieldUpdate()
    {
        if (shieldUpdate != null) return;
        shieldUpdate = transform.GetComponentInChildren<ShieldUpdate>();
    }

    protected virtual void LoadShieldHPText()
    {
        if (shieldHPText != null) return;
        shieldHPText = transform.GetComponentInChildren<ShieldHPText>();
    }
}