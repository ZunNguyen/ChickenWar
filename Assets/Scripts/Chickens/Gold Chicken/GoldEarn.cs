using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GoldEarn : ErshenMonoBehaviour
{
    [Header("Connect Script")]
    [SerializeField] protected ChickenController chickenController;

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
        LoadChickenController();
    }

    protected virtual void LoadChickenController()
    {
        if (chickenController != null) return;
        chickenController = transform.GetComponentInParent<ChickenController>();
    }
    
    protected virtual void EarningGold()
    {
        if (!CanEarnGold()) return;
        timeCurrent += Time.deltaTime;
        if (timeCurrent < timeDelay) return;
        timeCurrent = 0;
        GoldPlayer.Instance.gold += gold;
        //coinCollect.gameObject.SetActive(true);
        GameObject newTrans = CoinCollectSpawner.Instance.Spawn("Coin Collection", this.transform.position, this.transform.rotation);
        CoinCollect coinCollect = newTrans.GetComponent<CoinCollect>();
        coinCollect.GetValueText(gold);
        newTrans.gameObject.SetActive(true);
    }

    // Check can earn gold
    protected virtual bool CanEarnGold()
    {
        if (chickenController.gameObject.activeSelf == false) return false;
        return true;
    }
}