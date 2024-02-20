using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldEarn : ErshenMonoBehaviour
{
    [Header("Connect Script")]
    [SerializeField] protected GameObject parent;

    [Header("Value")]
    [SerializeField] protected float timeCurrent;
    [SerializeField] protected float timeDelay = 2;
    public int gold;

    protected void Update()
    {
        EarningGold();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadParent();
    }

    protected virtual void LoadParent()
    {
        if (parent != null) return;
        parent = transform.GetComponentInParent<ChickenController>().gameObject;
    }

    protected virtual void EarningGold()
    {
        if (!CanEarnGold()) return;
        timeCurrent += Time.deltaTime;
        if (timeCurrent < timeDelay) return;
        timeCurrent = 0;
        GoldPlayer.Instance.gold += gold;
    }

    // Check can earn gold
    protected virtual bool CanEarnGold()
    {
        if (parent.activeSelf == false) return false;
        return true;
    }
}
