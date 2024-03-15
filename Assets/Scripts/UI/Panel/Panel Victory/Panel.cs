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
        panelController.TWPanel.TW_PanelOn();
        float numsdogKill = panelController.CanvasController.TrackingWaveController.TrackingWave.sumDogCurrent;
        panelController.TextKill.GetTextKillDog(numsdogKill);
        float waveDog = panelController.CanvasController.PointSpawnDogController.wave;
        panelController.TextPanel.InputTextVictory(waveDog);
    }

    public virtual void PanelLoseOn()
    {
        panelController.TWPanel.TW_PanelOn();
        float numsdogKill = panelController.CanvasController.TrackingWaveController.TrackingWave.sumDogCurrent;
        panelController.TextKill.GetTextKillDog(numsdogKill);
        panelController.TextPanel.InputTextLose();
    }

    public virtual void PanelOff()
    {
        panelController.TWPanel.TW_PanelVictoryOff();
    }
}
