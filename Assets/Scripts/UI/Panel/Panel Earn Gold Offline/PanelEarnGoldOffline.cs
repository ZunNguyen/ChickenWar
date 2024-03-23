using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelEarnGoldOffline : ErshenMonoBehaviour
{
    [Header("---Connect Ctrl---")]
    [SerializeField] protected PanelEarnGoldOfflineCtrl panelEarnGoldOfflineCtrl;
    public PanelEarnGoldOfflineCtrl PanelEarnGoldOfflineCtrl => panelEarnGoldOfflineCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPanelEarnGoldOfflineCtrl();
    }

    protected virtual void LoadPanelEarnGoldOfflineCtrl()
    {
        if (panelEarnGoldOfflineCtrl != null) return;
        panelEarnGoldOfflineCtrl = transform.GetComponent<PanelEarnGoldOfflineCtrl>();
    }

    public virtual void PanelEarnGoldOfflineOn()
    {
        panelEarnGoldOfflineCtrl.TWPanelEarnGoldOffline.TW_PanelEarnGoldOfflineOn();
    }

    public virtual void PanelEarnGoldOfflineOff(int multiplier)
    {
        // Audio
        panelEarnGoldOfflineCtrl.CanvasController.AudioManager.PlaySFX(panelEarnGoldOfflineCtrl.CanvasController.AudioManager.effectClick);
        
        panelEarnGoldOfflineCtrl.TWPanelEarnGoldOffline.TW_PanelEarnGoldOfflineOff(multiplier);
    }
}
