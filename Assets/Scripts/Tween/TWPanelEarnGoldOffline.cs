using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class TWPanelEarnGoldOffline : TWEarnGoldPanel
{
    [Header("---Connect Ctrl---")]
    [SerializeField] protected PanelEarnGoldOfflineCtrl panelEarnGoldOfflineCtrl;

    [Header("---Gold Position---")]
    [SerializeField] protected Vector2 savePosition = new(-40, -9);

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPanelEarnGoldOffllineCtrl();
    }

    protected virtual void LoadPanelEarnGoldOffllineCtrl()
    {
        if (panelEarnGoldOfflineCtrl != null) return;
        panelEarnGoldOfflineCtrl = this.transform.GetComponent<PanelEarnGoldOfflineCtrl>();
    }

    protected override void ResetStatusBtn()
    {
        panelEarnGoldOfflineCtrl.TWPanelEarnGoldOffline.SetIsClaimingIsFalse();
    }

    protected override Vector2 SavePosition()
    {
        Vector2 position = savePosition;
        return position;
    }

    protected override void SetAudioEffectEarnGold()
    {
        panelEarnGoldOfflineCtrl.CanvasController.AudioManager.PlaySFX(panelEarnGoldOfflineCtrl.CanvasController.AudioManager.effectEarnGold);
    }
}
