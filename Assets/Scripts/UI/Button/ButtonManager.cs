using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : ErshenMonoBehaviour
{
    [Header("Connect Script Outside")]
    [SerializeField] protected PointSpawnDogController pointSpawnDogController;

    [Header("Connect Script Inside")]
    [SerializeField] protected SpawnChicken spawnPrefab;
    [SerializeField] protected CanvasController canvasController;

    [Header("Instance")]
    [SerializeField] protected static ButtonManager instance;
    public static ButtonManager Instance => instance;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPointSpawnDogController();
        LoadInstance();
        LoadSpawnPrefab();
    }

    protected virtual void LoadPointSpawnDogController()
    {
        if (pointSpawnDogController != null) return;
        pointSpawnDogController = GameObject.Find("Point Spawn Dog").GetComponent<PointSpawnDogController>();
    }

    protected virtual void LoadSpawnPrefab()
    {
        if (spawnPrefab != null) return;
        spawnPrefab = GetComponentInChildren<SpawnChicken>();
    }

    protected virtual void LoadInstance()
    {
        if (instance != null) return;
        ButtonManager.instance = this;
    }

    public virtual void StartGame()
    {
        pointSpawnDogController.PointSpawnDog.enabled = true;
        canvasController.CheckPositionChicken.testCheckPosition = true;
    }

    public void SpawnChicken()
    {
        spawnPrefab.SpawnPrefabInSlot();
    }
}