using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMissionCtrl : CanvasAbstract
{
    [Header("---Load SO---")]
    [SerializeField] protected MissionSO missionSO;
    public MissionSO MissionSO => missionSO;

    [Header("---Connect Inside---")]
    [SerializeField] protected TWPanelMission tWPanelMission;
    public TWPanelMission TWPanelMission => tWPanelMission;
    
    [SerializeField] protected PanelMission panelMission;
    public PanelMission PanelMission => panelMission;

    [Header("Connect Mission Children")]
    // Mission 1
    [SerializeField] protected TW_PanelMission_1 tW_PanelMission_1;
    public TW_PanelMission_1 TW_PanelMission_1 => tW_PanelMission_1;
    
    [SerializeField] protected PanelMission_1 panelMission_1;
    public PanelMission_1 PanelMission_1 => panelMission_1;

    // Mission 2
    [SerializeField] protected TW_PanelMission_2 tW_PanelMission_2;
    public TW_PanelMission_2 TW_PanelMission_2 => tW_PanelMission_2;

    [SerializeField] protected PanelMission_2 panelMission_2;
    public PanelMission_2 PanelMission_2 => panelMission_2;

    // Mission 3
    [SerializeField] protected TW_PanelMission_3 tW_PanelMission_3;
    public TW_PanelMission_3 TW_PanelMission_3 => tW_PanelMission_3;

    [SerializeField] protected PanelMission_3 panelMission_3;
    public PanelMission_3 PanelMission_3 => panelMission_3;

    // Mission 4
    [SerializeField] protected TW_PanelMission_4 tW_PanelMission_4;
    public TW_PanelMission_4 TW_PanelMission_4 => tW_PanelMission_4;

    [SerializeField] protected PanelMission_4 panelMission_4;
    public PanelMission_4 PanelMission_4 => panelMission_4;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadMissionSO();
        LoadTWPanelMission();
        LoadPanelMission();

        // Mission 1
        LoadTW_PanelMission_1();
        LoadPanelMission_1();

        // Mission 2
        LoadTW_PanelMission_2();
        LoadPanelMission_2();

        // Mission 3
        LoadTW_PanelMission_3();
        LoadPanelMission_3();

        // Mission 4
        LoadTW_PanelMission_4();
        LoadPanelMission_4();
    }

    protected virtual void LoadMissionSO()
    {
        if (missionSO != null) return;
        string resPath = "SO/Mission/MissionSO";
        missionSO = Resources.Load<MissionSO>(resPath);
    }

    protected virtual void LoadTWPanelMission()
    {
        if (tWPanelMission != null) return;
        tWPanelMission = transform.GetComponent<TWPanelMission>();
    }

    protected virtual void LoadPanelMission()
    {
        if (panelMission != null) return;
        panelMission = transform.GetComponent<PanelMission>();
    }

    // Mission 1
    protected virtual void LoadTW_PanelMission_1()
    {
        if (tW_PanelMission_1 != null) return;
        tW_PanelMission_1 = transform.GetComponentInChildren<TW_PanelMission_1>();
    }

    protected virtual void LoadPanelMission_1()
    {
        if (panelMission_1 != null) return;
        panelMission_1 = transform.GetComponentInChildren<PanelMission_1>();
    }

    // Mission 2
    protected virtual void LoadTW_PanelMission_2()
    {
        if (tW_PanelMission_2 != null) return;
        tW_PanelMission_2 = transform.GetComponentInChildren<TW_PanelMission_2>();
    }

    protected virtual void LoadPanelMission_2()
    {
        if (panelMission_2 != null) return;
        panelMission_2 = transform.GetComponentInChildren<PanelMission_2>();
    }

    // Mission 3
    protected virtual void LoadTW_PanelMission_3()
    {
        if (tW_PanelMission_3 != null) return;
        tW_PanelMission_3 = transform.GetComponentInChildren<TW_PanelMission_3>();
    }

    protected virtual void LoadPanelMission_3()
    {
        if (panelMission_3 != null) return;
        panelMission_3 = transform.GetComponentInChildren<PanelMission_3>();
    }

    // Mission 4
    protected virtual void LoadTW_PanelMission_4()
    {
        if (tW_PanelMission_4 != null) return;
        tW_PanelMission_4 = transform.GetComponentInChildren<TW_PanelMission_4>();
    }

    protected virtual void LoadPanelMission_4()
    {
        if (panelMission_4 != null) return;
        panelMission_4 = transform.GetComponentInChildren<PanelMission_4>();
    }
}
