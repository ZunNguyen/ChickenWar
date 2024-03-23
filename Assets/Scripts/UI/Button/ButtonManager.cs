using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : ErshenMonoBehaviour
{
    [SerializeField] protected CanvasController canvasController;
    public bool isStarting = false;
    public bool isClaiming = false;
    public int timePressButton = 0;

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
        timePressButton += 1;
        if (timePressButton % 2 == 0 && timePressButton > 0) canvasController.ChangeButtonStart.ChangeImageButtonXTime(2,1);
        if (timePressButton % 2 == 1 && timePressButton > 0) canvasController.ChangeButtonStart.ChangeImageButtonXTime(1,2);
        if (isStarting) return;

        //Audio
        canvasController.AudioManager.PlayMusic(canvasController.AudioManager.musicBattle);

        // On Spawn Dog
        canvasController.PointSpawnDogController.gameObject.SetActive(true);
        canvasController.PointSpawnDogController.OnObj();
        // On Bullet
        canvasController.PointSpawnBulletController.BulletOn();
        // On tracking wave
        canvasController.TrackingWaveController.TrackingWave.TrackingWaveOn();
    }

    public void SpawnChicken()
    {
        canvasController.ButtonSpawn.SpawnChickenInGrid();
    }

    public virtual void ButtonClaim()
    {
        // Audio
        canvasController.AudioManager.PlaySFX(canvasController.AudioManager.effectEarnGold);
        
        OffTrackingWave();
        // Off panel
        canvasController.PanelVictoyLoseCtrl.PanelVictoryLose.PanelOff(1);
    }

    public virtual void ButtonClaimVD()
    {
        // Audio
        canvasController.AudioManager.PlaySFX(canvasController.AudioManager.effectEarnGold);

        OffTrackingWave();
        // Off panel victory
        canvasController.PanelVictoyLoseCtrl.PanelVictoryLose.PanelOff(2);
    }

    public virtual void ButtonUnclockChickenUpgrade()
    {
        canvasController.TWUpgradeChicken.TW_UpgradeOff();
    }

    protected virtual void OffTrackingWave()
    {
        if (isClaiming) return;

        // Audio
        canvasController.AudioManager.PlayMusic(canvasController.AudioManager.musicMain);

        isClaiming = true;
        isStarting = false;
        timePressButton = 0;
        canvasController.ChangeButtonStart.ChangeImageButtonStart();
        canvasController.GameObjectSpawner.OffObjInHolder();
        canvasController.ShieldUpdate.LoadBeginGame();

        // Off panel tracking wave
        canvasController.TrackingWaveController.TrackingWave.TrackingWaveOff();
    }
}