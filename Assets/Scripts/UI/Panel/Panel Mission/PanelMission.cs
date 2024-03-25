using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMission : ErshenMonoBehaviour
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
        panelMissionCtrl = transform.GetComponent<PanelMissionCtrl>();
    }
}
