using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core.Easing;
using Unity.VisualScripting;

public class TWPanelVictoryLose : TWEarnGoldPanel
{
    [Header("---Connect Ctrl---")]
    [SerializeField] protected PanelVictoyLoseCtrl panelVictoyLoseCtrl;

    [Header("---Position gold---")]
    [SerializeField] protected Vector2 savePosition = new(-32, -3);
    
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

    protected override void ResetStatusBtn()
    {
        panelVictoyLoseCtrl.TWPanelVictoryLose.SetIsClaimingIsFalse();
    }

    protected override void SetAudioEffectEarnGold()
    {
        CanvasCtrl.Instance.AudioManager.PlaySFX(CanvasCtrl.Instance.AudioManager.effectEarnGold);
    }
}