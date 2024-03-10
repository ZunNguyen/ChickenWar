using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : ErshenMonoBehaviour
{
    [Header("Connect Script Outside")]
    [SerializeField] protected PointSpawnDogController pointSpawnDogController;

    [Header("Connect Script Inside")]
    [SerializeField] protected SpawnChicken spawnChicken;
    [SerializeField] protected CanvasController canvasController;

    [Header("Instance")]
    [SerializeField] protected static ButtonManager instance;
    public static ButtonManager Instance => instance;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPointSpawnDogController();
        LoadInstance();
        LoadSpawnChicken();
    }

    protected virtual void LoadPointSpawnDogController()
    {
        if (pointSpawnDogController != null) return;
        pointSpawnDogController = GameObject.Find("Point Spawn Dog").GetComponent<PointSpawnDogController>();
    }

    protected virtual void LoadSpawnChicken()
    {
        if (spawnChicken != null) return;
        spawnChicken = GetComponentInChildren<SpawnChicken>();
    }

    protected virtual void LoadInstance()
    {
        if (instance != null) return;
        ButtonManager.instance = this;
    }

    public virtual void StartGame()
    {
        // On Spawn Dog
        pointSpawnDogController.enabled = true;
        // On Bullet
        canvasController.PointSpawnBulletController.BulletOn();
        // On tracking wave
        TrackingWave.Instance.GetSumDogMax();
        // Show wave text
        canvasController.TrackingWaveController.CountWave.LoadText();
    }

    public void SpawnChicken()
    {
        canvasController.ButtonSpawn.SpawnChickenInGrid();
    }
}