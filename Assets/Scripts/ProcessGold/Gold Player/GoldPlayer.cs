using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldPlayer : ProcessGold
{
    [Header("---Load Instance---")]
    protected static GoldPlayer instance;
    public static GoldPlayer Instance => instance;

    [Header("---Connect CanvasCtrl")]
    [SerializeField] protected CanvasController canvasController;

    [Header("---Value---")]
    public int gold = 0;

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
        canvasController = transform.GetComponentInParent<CanvasController>();
    }

    public virtual void LoadBegin(int goldSave)
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