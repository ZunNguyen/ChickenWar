using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChickenController : CanvasAbstract
{
    [Header("Connect Script")]
    [SerializeField] protected ChickenSO chickenSO;
    public ChickenSO ChickenSO => chickenSO;

    [SerializeField] protected GoldEarn goldEarn;
    public GoldEarn GoldEarn => goldEarn;

    [SerializeField] protected ChickenGun chickenGun;
    public ChickenGun ChickenGun => chickenGun;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadChickenSO();
        LoadGoldEarn();
        LoadChickenGun();
    }

    protected virtual void LoadChickenSO()
    {
        if (chickenSO != null) return;
        string resPath = "SO/Chickens/Chickens";
        chickenSO = Resources.Load<ChickenSO>(resPath);
    }

    protected virtual void LoadGoldEarn()
    {
        if (goldEarn != null) return;
        goldEarn = this.transform.GetComponentInChildren<GoldEarn>();
    }

    protected virtual void LoadChickenGun()
    {
        if (chickenGun != null) return;
        chickenGun = this.transform.GetComponentInChildren<ChickenGun>();
    }
}
