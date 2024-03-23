using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelVictoryLose : ErshenMonoBehaviour
{
    [Header("Connect controller")]
    [SerializeField] protected PanelVictoyLoseCtrl panelVictoyLoseCtrl;
    public PanelVictoyLoseCtrl PanelVictoyLoseCtrl => panelVictoyLoseCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPanelVictoryLoseCtrl();
    }

    protected virtual void LoadPanelVictoryLoseCtrl()
    {
        if (panelVictoyLoseCtrl != null) return;
        panelVictoyLoseCtrl = this.transform.GetComponent<PanelVictoyLoseCtrl>();
    }

    public virtual void PanelVictoryOn()
    {
        // Audio
        panelVictoyLoseCtrl.CanvasController.AudioManager.PauseMusic(panelVictoyLoseCtrl.CanvasController.AudioManager.musicBattle);
        panelVictoyLoseCtrl.CanvasController.AudioManager.PlaySFX(panelVictoyLoseCtrl.CanvasController.AudioManager.effectWinWave);

        panelVictoyLoseCtrl.TWPanelVictoryLose.TW_PanelVictoryLoseOn();
        float numsdogKill = panelVictoyLoseCtrl.CanvasController.TrackingWaveController.TrackingWave.sumDogCurrent;
        panelVictoyLoseCtrl.TextKill.GetTextKillDog(numsdogKill);
        int waveDog = panelVictoyLoseCtrl.CanvasController.PointSpawnDogController.wave;
        panelVictoyLoseCtrl.TextPanel.InputTextVictory(waveDog);
        float goldEarn = panelVictoyLoseCtrl.GoldGiftSO.listGoldGift[waveDog].gold;
        panelVictoyLoseCtrl.TextEarnGold.InputGoldValue(goldEarn);
    }

    public virtual void PanelLoseOn()
    {
        // Audio
        panelVictoyLoseCtrl.CanvasController.AudioManager.PauseMusic(panelVictoyLoseCtrl.CanvasController.AudioManager.musicBattle);
        panelVictoyLoseCtrl.CanvasController.AudioManager.PlaySFX(panelVictoyLoseCtrl.CanvasController.AudioManager.effectGameOver);

        panelVictoyLoseCtrl.CanvasController.GameObjectSpawner.OffMovementObjInHolder();
        panelVictoyLoseCtrl.TWPanelVictoryLose.TW_PanelVictoryLoseOn();
        float numsdogKill = panelVictoyLoseCtrl.CanvasController.TrackingWaveController.TrackingWave.sumDogCurrent;
        panelVictoyLoseCtrl.TextKill.GetTextKillDog(numsdogKill);
        int waveDog = panelVictoyLoseCtrl.CanvasController.PointSpawnDogController.wave;
        float goldEarn = panelVictoyLoseCtrl.GoldGiftSO.listGoldGift[waveDog].gold;
        panelVictoyLoseCtrl.TextEarnGold.InputGoldValue(goldEarn/2);
        panelVictoyLoseCtrl.TextPanel.InputTextLose();
    }

    public virtual void PanelOff(int multiplier)
    {
        panelVictoyLoseCtrl.TWPanelVictoryLose.TW_PanelVictoryLoseOff(multiplier);
    }
}
