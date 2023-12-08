using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : ErshenMonoBehaviour
{
    [Header("Load Script inside")]
    [SerializeField] protected ChickenSpawner chickenSpawner;
    public ChickenSpawner ChickenSpawner { get => chickenSpawner; }

    [SerializeField] protected DragItem dragItem;
    public DragItem DragItem { get => dragItem; }

    [SerializeField] protected SpawnUpdateChicken spawnPrefab;
    public SpawnUpdateChicken SpawnPrefab { get => spawnPrefab; }

    [SerializeField] protected UpdateChickenSpawn updateChickenSpawn;
    public UpdateChickenSpawn UpdateChickenSpawn { get => updateChickenSpawn; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadChickenSpawner();
        LoadDragItem();
        LoadSpawnPrefab();
        LoadUpdateChickenSpawn();
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

    protected virtual void LoadSpawnPrefab()
    {
        if (spawnPrefab != null) return;
        spawnPrefab = transform.GetComponentInChildren<SpawnUpdateChicken>();
    }

    protected virtual void LoadUpdateChickenSpawn()
    {
        if (updateChickenSpawn != null) return;
        updateChickenSpawn = transform.GetComponentInChildren<UpdateChickenSpawn>();
    }
}