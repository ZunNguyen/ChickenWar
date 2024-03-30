using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using TMPro;

public class CoinCollect : ProcessGold
{
    [Header("Connect Script")]
    [SerializeField] protected RectTransform rectTransform;

    [Header("Value")]
    [SerializeField] protected Transform textCoin;
    [SerializeField] protected float posTarget = 150f;
    [SerializeField] protected float durTimeMove = 1.5f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadTextCoin();
        LoadRectTransform();
    }

    protected virtual void LoadTextCoin()
    {
        if (textCoin != null) return;
        textCoin = GameObject.Find("Text Coin").transform;
    }

    protected virtual void LoadRectTransform()
    {
        if (rectTransform != null) return;
        rectTransform = transform.GetComponent<RectTransform>();
    }

    public virtual void TWCoinCollectOn()
    {
        CanvasCtrl.Instance.AudioManager.PlaySFX(CanvasCtrl.Instance.AudioManager.effectEarnGold);
        rectTransform.DOAnchorPosY(rectTransform.anchoredPosition.y + posTarget, durTimeMove).OnComplete(() =>
        {
            CoinCollectSpawner.Instance.Despawn(gameObject);
        });
    }

    public void GetValueText(int value)
    {
        PrintText(value);
    }
}