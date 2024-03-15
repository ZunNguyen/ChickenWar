using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : ErshenMonoBehaviour
{
    [Header("Instance")]
    [SerializeField] protected static CanvasController instance;
    public static CanvasController Instance => instance;
    
    [Header("Load Script Outside")]

    [SerializeField] protected PointSpawnBulletController pointSpawnBulletController;
    public PointSpawnBulletController PointSpawnBulletController => pointSpawnBulletController;

    [SerializeField] protected PointSpawnDogController pointSpawnDogController;
    public PointSpawnDogController PointSpawnDogController => pointSpawnDogController;

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

    [SerializeField] protected TrackingWaveController trackingWaveController;
    public TrackingWaveController TrackingWaveController => trackingWaveController;

    [SerializeField] protected PanelController panelController;
    public PanelController PanelController => panelController;

    [SerializeField] protected TWUpgradeChicken tWUpgradeChicken;
    public TWUpgradeChicken TWUpgradeChicken => tWUpgradeChicken;

    [SerializeField] protected ShieldUpdateController shieldUpdateController;
    public ShieldUpdateController ShieldUpdateController => shieldUpdateController;

    [SerializeField] protected PanelLoseController panelLoseController;
    public PanelLoseController PanelLoseController => panelLoseController;

    [Header("Load script for shield")]
    [SerializeField] protected ShieldUpdate shieldUpdate;
    public ShieldUpdate ShieldUpdate => shieldUpdate;

    [SerializeField] protected ShieldHPSum shieldHPSum;
    public ShieldHPSum ShieldHPSum => shieldHPSum;

    [SerializeField] protected ButtonManager buttonManager;
    public ButtonManager ButtonManager => buttonManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        // Instance
        LoadInstance();

        LoadChickenSpawner();
        LoadDragItem();
        LoadSpawnChicken();
        LoadButtonSpawn();
        LoadCheckPositionChicken();
        LoadPointSpawnBulletController();
        LoadPointSpawnDogController();
        LoadGoldPlayer();
        LoadTrackingWaveController();
        LoadPanelController();
        LoadButtonManager();
        LoadShieldUpdateController();
        LoadTWUpgradeChicken();
        LoadpanelLoseController();

        // Load Script for Shield
        LoadShieldUpdate();
        LoadShieldSumHP();
    }

    protected virtual void LoadPointSpawnDogController()
    {
        if (pointSpawnDogController != null) return;
        pointSpawnDogController = GameObject.Find("Point Spawn Dog").GetComponent<PointSpawnDogController>();
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

    protected virtual void LoadGoldPlayer()
    {
        if (goldPlayer != null) return;
        goldPlayer = transform.GetComponentInChildren<GoldPlayer>();
    }

    protected virtual void LoadTrackingWaveController()
    {
        if (trackingWaveController != null) return;
        trackingWaveController = transform.GetComponentInChildren<TrackingWaveController>();
    }

    protected virtual void LoadShieldUpdate()
    {
        if (shieldUpdate != null) return;
        shieldUpdate = transform.GetComponentInChildren<ShieldUpdate>();
    }

    protected virtual void LoadPanelController()
    {
        if (panelController != null) return;
        panelController = transform.Find("Panel").GetComponent<PanelController>();
    }

    protected virtual void LoadTWUpgradeChicken()
    {
        if (tWUpgradeChicken != null) return;
        tWUpgradeChicken = transform.Find("Panel - Upgrade").GetComponent<TWUpgradeChicken>();
    }

    protected virtual void LoadButtonManager()
    {
        if (buttonManager != null) return;
        buttonManager = this.transform.GetComponent<ButtonManager>();
    }

    protected virtual void LoadShieldUpdateController()
    {
        if (shieldUpdateController != null) return;
        shieldUpdateController = transform.Find("Update Shield").GetComponent<ShieldUpdateController>();
    }

    protected virtual void LoadpanelLoseController()
    {
        if (panelLoseController != null) return;
        panelLoseController = transform.Find("Panel - Lose").GetComponent<PanelLoseController>();
    }

    protected virtual void LoadInstance()
    {
        if (instance != null) return;
        instance = this;
    }
}