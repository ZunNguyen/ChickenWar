using System;
using UnityEngine;

public class GoldPlayer : ProcessGold
{
    [Header("---Load Instance---")]
    protected static GoldPlayer instance;
    public static GoldPlayer Instance => instance;

    [Header("---Connect CanvasCtrl")]
    [SerializeField] protected CanvasCtrl canvasController;

    [Header("---Value---")]
    public Int64 gold = 0;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadInstance();
        LoadCanvasCtrl();
    }

    protected virtual void LoadInstance()
    {
        if (instance != null) return;
        instance = this;
    }

    protected virtual void LoadCanvasCtrl()
    {
        if (canvasController != null) return;
        canvasController = transform.GetComponentInParent<CanvasCtrl>();
    }

    public virtual void LoadBegin(Int64 goldSave)
    {
        gold = goldSave;
        PrintText(gold);
    }

    public virtual void AddGoldPlayer(int addGold)
    {
        gold += addGold;
        PrintText(gold);
        canvasController.PanelMissionCtrl.PanelMission_2.AddAchievementPlayer(addGold);
    }

    public virtual void SubtractGoldPlayer(int subtractGold)
    {
        gold -= subtractGold;
        PrintText(gold);
    }
}