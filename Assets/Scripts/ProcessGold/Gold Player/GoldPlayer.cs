using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldPlayer : ProcessGold
{
    protected static GoldPlayer instance;
    public static GoldPlayer Instance => instance;
    public float gold;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadInstance();
    }

    protected virtual void LoadInstance()
    {
        if (instance != null) return;
        instance = this;
    }

    private void Update()
    {
        PrintText(gold);
    }
}