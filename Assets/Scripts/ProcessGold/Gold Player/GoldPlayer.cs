using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldPlayer : ProcessGold
{
    [SerializeField] protected static GoldPlayer instance;
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

    protected override void LoadText()
    {
        if (text != null) return;
        text = transform.GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        PrintText(gold);
    }
}