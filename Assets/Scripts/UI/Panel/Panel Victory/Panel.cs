using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Panel : ErshenMonoBehaviour
{
    [Header("Connect controller")]
    [SerializeField] protected PanelController panelController;
    public PanelController PanelController => panelController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPanelController();
    }

    protected virtual void LoadPanelController()
    {
        if (panelController != null) return;
        panelController = this.transform.GetComponent<PanelController>();
    }

    public virtual void PanelVictoryOn()
    {
        // Audio
        panelController.CanvasController.AudioManager.PauseMusic(panelController.CanvasController.AudioManager.musicBattle);
        panelController.CanvasController.AudioManager.PlaySFX(panelController.CanvasController.AudioManager.effectWinWave);

        panelController.TWPanel.TW_PanelOn();
        float numsdogKill = panelController.CanvasController.TrackingWaveController.TrackingWave.sumDogCurrent;
        panelController.TextKill.GetTextKillDog(numsdogKill);
        int waveDog = panelController.CanvasController.PointSpawnDogController.wave;
        panelController.TextPanel.InputTextVictory(waveDog);
        float goldEarn = panelController.GoldGiftSO.listGoldGift[waveDog].gold;
        panelController.TextEarnGold.InputGoldValue(goldEarn);
    }

    public virtual void PanelLoseOn()
    {
        // Audio
        panelController.CanvasController.AudioManager.PauseMusic(panelController.CanvasController.AudioManager.musicBattle);
        panelController.CanvasController.AudioManager.PlaySFX(panelController.CanvasController.AudioManager.effectGameOver);

        panelController.CanvasController.GameObjectSpawner.OffMovementObjInHolder();
        panelController.TWPanel.TW_PanelOn();
        float numsdogKill = panelController.CanvasController.TrackingWaveController.TrackingWave.sumDogCurrent;
        panelController.TextKill.GetTextKillDog(numsdogKill);
        int waveDog = panelController.CanvasController.PointSpawnDogController.wave;
        float goldEarn = panelController.GoldGiftSO.listGoldGift[waveDog].gold;
        panelController.TextEarnGold.InputGoldValue(goldEarn/2);
        panelController.TextPanel.InputTextLose();
    }

    public virtual void PanelOff(int multiplier)
    {
        panelController.TWPanel.TW_PanelVictoryOff(multiplier);
    }
}
