using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPauseCtrl : CanvasAbstract
{
    [Header("---Connect InSide---")]
    [SerializeField] protected TWPanelPasue tWPanelPasue;
    public TWPanelPasue TWPanelPasue => tWPanelPasue;

    [SerializeField] protected TWPanelSetting tWPanelSetting;
    public TWPanelSetting TWPanelSetting => tWPanelSetting;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadTWPanelPause();
        LoadTWPanelSetting();
    }

    protected virtual void LoadTWPanelPause()
    {
        if (tWPanelPasue != null) return;
        tWPanelPasue = GameObject.Find("Panel - Pause").GetComponent<TWPanelPasue>();
    }

    protected virtual void LoadTWPanelSetting()
    {
        if (tWPanelSetting != null) return;
        tWPanelSetting = GameObject.Find("Panel - Setting").GetComponent<TWPanelSetting>();
    }
}
