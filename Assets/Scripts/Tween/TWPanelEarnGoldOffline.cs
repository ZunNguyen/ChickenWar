using UnityEngine;

public class TWPanelEarnGoldOffline : TWEarnGoldPanel
{
    [Header("---Connect Ctrl---")]
    [SerializeField] protected PanelEarnGoldOfflineCtrl panelEarnGoldOfflineCtrl;

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

    protected override void SetAudioEffectEarnGold()
    {
        panelEarnGoldOfflineCtrl.CanvasController.AudioManager.PlaySFX(panelEarnGoldOfflineCtrl.CanvasController.AudioManager.effectEarnGold);
    }
}