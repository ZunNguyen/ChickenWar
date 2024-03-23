using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelEarnGoldOfflineCtrl : CanvasAbstract
{
    [Header("Connect Script")]
    [SerializeField] protected TextEarnGoldOffline textEarnGoldOffline;
    public TextEarnGoldOffline TextEarnGoldOffline => textEarnGoldOffline;

    [SerializeField] protected TWPanelEarnGoldOffline tWPanelEarnGoldOffline;
    public TWPanelEarnGoldOffline TWPanelEarnGoldOffline => tWPanelEarnGoldOffline;

    [SerializeField] protected PanelEarnGoldOffline panelEarnGoldOffline;
    public PanelEarnGoldOffline PanelEarnGoldOffline => panelEarnGoldOffline;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadTextEarnGoldOffline();
        LoadTWPanelEarnGoldOffline();
        LoadPanelEarnGoldOffline();
    }

    protected virtual void LoadTextEarnGoldOffline()
    {
        if (textEarnGoldOffline != null) return;
        textEarnGoldOffline = transform.GetComponentInChildren<TextEarnGoldOffline>();
    }

    protected virtual void LoadTWPanelEarnGoldOffline()
    {
        if (tWPanelEarnGoldOffline != null) return;
        tWPanelEarnGoldOffline = transform.GetComponent<TWPanelEarnGoldOffline>();
    }

    protected virtual void LoadPanelEarnGoldOffline()
    {
        if (panelEarnGoldOffline != null) return;
        panelEarnGoldOffline = transform.GetComponent<PanelEarnGoldOffline>();
    }
}
