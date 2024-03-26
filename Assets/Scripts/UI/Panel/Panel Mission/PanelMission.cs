using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMission : ErshenMonoBehaviour
{
    [Header("---Connect Ctrl---")]
    [SerializeField] protected PanelMissionCtrl panelMissionCtrl;

    [SerializeField] protected GameObject mark;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPanelMissionCtrl();
        LoadMark();
    }

    protected virtual void LoadPanelMissionCtrl()
    {
        if (panelMissionCtrl != null) return;
        panelMissionCtrl = transform.GetComponent<PanelMissionCtrl>();
    }

    protected virtual void LoadMark()
    {
        if (mark != null) return;
        mark = transform.Find("Image - Mark").gameObject;
    }

    public virtual void PressMissionButton()
    {
        mark.SetActive(false);
        GetSFX();
        panelMissionCtrl.TWPanelMission.TW_PanelMissionOn();
        panelMissionCtrl.PanelMission_1.LoadMissionInformation();
        panelMissionCtrl.PanelMission_2.LoadMissionInformation();
        panelMissionCtrl.PanelMission_3.LoadMissionInformation();
        panelMissionCtrl.PanelMission_4.LoadMissionInformation();
    }

    public virtual void PressLoseButton()
    {
        GetSFX();
        panelMissionCtrl.TWPanelMission.TW_PanelMissionOff();
    }

    protected virtual void GetSFX()
    {
        panelMissionCtrl.CanvasController.AudioManager.PlaySFX(panelMissionCtrl.CanvasController.AudioManager.effectClick);
    }

    public virtual void OnMark()
    {
        mark.SetActive(true);
    }
}
