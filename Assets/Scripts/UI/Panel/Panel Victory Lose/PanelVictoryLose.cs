using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelVictoryLose : ErshenMonoBehaviour
{
    [Header("---Connect controller---")]
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
        SetPanel();

        // Audio
        panelVictoyLoseCtrl.CanvasController.AudioManager.PlaySFX(panelVictoyLoseCtrl.CanvasController.AudioManager.effectWinWave);

        int waveDog = panelVictoyLoseCtrl.CanvasController.PointSpawnDogController.wave;
        panelVictoyLoseCtrl.TextPanel.InputTextVictory(waveDog);
        float goldEarn = panelVictoyLoseCtrl.GoldGiftSO.listGoldGift[waveDog].gold;
        panelVictoyLoseCtrl.TextEarnGold.InputGoldValue(goldEarn);
    }

    public virtual void PanelLoseOn()
    {
        SetPanel();

        // Audio
        panelVictoyLoseCtrl.CanvasController.AudioManager.PlaySFX(panelVictoyLoseCtrl.CanvasController.AudioManager.effectGameOver);

        panelVictoyLoseCtrl.CanvasController.GameObjectSpawner.OffMovementObjInHolder();
        
        int waveDog = panelVictoyLoseCtrl.CanvasController.PointSpawnDogController.wave;
        float goldEarn = panelVictoyLoseCtrl.GoldGiftSO.listGoldGift[waveDog].gold;
        panelVictoyLoseCtrl.TextEarnGold.InputGoldValue(goldEarn/2);
        panelVictoyLoseCtrl.TextPanel.InputTextLose();
    }

    protected virtual void SetPanel()
    {
        panelVictoyLoseCtrl.CanvasController.AudioManager.PauseMusic(panelVictoyLoseCtrl.CanvasController.AudioManager.musicBattle);
        panelVictoyLoseCtrl.TWPanelVictoryLose.TW_PanelOn();
        float numsdogKill = panelVictoyLoseCtrl.CanvasController.TrackingWaveController.TrackingWave.sumDogCurrent;
        panelVictoyLoseCtrl.TextKill.GetTextKillDog(numsdogKill);
    }

    public virtual void PanelOff(int multiplier)
    {
        float goldEarn = panelVictoyLoseCtrl.TextEarnGold.goldEarn;

        panelVictoyLoseCtrl.TWPanelVictoryLose.TW_PanelOff(multiplier, goldEarn);
    }
}
