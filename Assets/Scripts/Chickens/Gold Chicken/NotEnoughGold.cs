using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class NotEnoughGold : CanvasAbstract
{
    [Header("Connect Script")]
    [SerializeField] protected RectTransform rectTransform;

    [Header("Value")]
    [SerializeField] protected float posTarget = 150f;
    [SerializeField] protected float durTimeMove = 1.5f;
    [SerializeField] protected float durTimeDes = 1.3f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadRectTransform();
    }

    protected virtual void LoadRectTransform()
    {
        if (rectTransform != null) return;
        rectTransform = transform.GetComponent<RectTransform>();
    }

    public virtual void TWTextOn()
    {
        rectTransform.DOAnchorPosY(rectTransform.anchoredPosition.y + posTarget, durTimeMove);
        Invoke(nameof(DestroyObj), durTimeDes);
    }
    
    protected virtual void DestroyObj()
    {
        CoinCollectSpawner.Instance.Despawn(gameObject);
    }
}