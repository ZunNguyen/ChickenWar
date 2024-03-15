using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : ErshenMonoBehaviour
{
    [SerializeField] protected CanvasController canvasController;
    public bool isStarting = false;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadCanvasController();
    }

    protected virtual void LoadCanvasController()
    {
        if (canvasController != null) return;
        canvasController = this.transform.GetComponent<CanvasController>();
    }

    public virtual void StartGame()
    {
        if (isStarting) return;
        // On Spawn Dog
        canvasController.PointSpawnDogController.enabled = true;
        // On Bullet
        canvasController.PointSpawnBulletController.BulletOn();
        // On tracking wave
        TrackingWave.Instance.GetSumDogMax();
        // Show wave text
        canvasController.TrackingWaveController.CountWave.LoadText();
        canvasController.TrackingWaveController.TWTrackingWave.TW_TrackingWaveOn();
    }

    public void SpawnChicken()
    {
        canvasController.ButtonSpawn.SpawnChickenInGrid();
    }

    public virtual void ButtonClaim()
    {
        canvasController.ButtonManager.isStarting = false;

        // Off panel tracking wave
        canvasController.TrackingWaveController.TWTrackingWave.TW_TrackingWaveOff();

        // Off panel victory
        canvasController.PanelController.Panel.PanelOff();
    }

    public virtual void ButtonUnclockChickenUpgrade()
    {
        canvasController.TWUpgradeChicken.TW_UpgradeOff();
    }
}