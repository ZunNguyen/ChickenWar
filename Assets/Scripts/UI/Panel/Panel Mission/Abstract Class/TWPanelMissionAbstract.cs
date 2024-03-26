using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TWPanelMissionAbstract : TWEarnGold
{
    [Header("---Connect Ctrl---")]
    [SerializeField] protected PanelMissionCtrl panelMissionCtrl;
        
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPanelMissionCtrl();
    }

    protected virtual void LoadPanelMissionCtrl()
    {
        if (panelMissionCtrl != null) return;
        panelMissionCtrl = transform.parent.parent.GetComponent<PanelMissionCtrl>();
    }

    protected override void SetAudioEffectEarnGold()
    {
        panelMissionCtrl.CanvasController.AudioManager.PlaySFX(panelMissionCtrl.CanvasController.AudioManager.effectEarnGold);
    }
}
