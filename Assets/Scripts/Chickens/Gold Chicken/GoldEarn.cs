using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GoldEarn : ChickenAbstract
{
    [Header("Value")]
    [SerializeField] protected float timeCurrent;
    public float timeDelay = 6;
    public int gold;

    protected void Update()
    {
        EarningGold();
    }

    protected virtual void EarningGold()
    {
        if (!CanEarnGold()) return;
        timeCurrent += Time.deltaTime;
        if (timeCurrent < timeDelay) return;
        timeCurrent = 0;
        GoldPlayer.Instance.AddGoldPlayer(gold);
        //coinCollect.gameObject.SetActive(true);
        GameObject newTrans = canvasController.CoinCollectionSpawner.Spawn("Coin Collection", this.transform.position, this.transform.rotation);
        CoinCollect coinCollect = newTrans.GetComponent<CoinCollect>();
        coinCollect.GetValueText(gold);
        coinCollect.TWCoinCollectOn();
        newTrans.SetActive(true);
    }

    // Check can earn gold
    protected virtual bool CanEarnGold()
    {
        if (chickenController.gameObject.activeSelf == false) return false;
        return true;
    }
}