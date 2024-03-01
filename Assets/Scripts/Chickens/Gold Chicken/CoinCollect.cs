using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using TMPro;

public class CoinCollect : ErshenMonoBehaviour
{
    [SerializeField] protected static CoinCollect instance;
    public static CoinCollect Instance => instance;

    [Header("Connect Script")]
    [SerializeField] protected TMP_Text text;
    [SerializeField] protected RectTransform rectTransform;

    [Header("Value")]
    [SerializeField] protected Transform textCoin;
    [SerializeField] protected float posTarget = 30f;
    [SerializeField] protected float durTimeMove = 1.5f;
    [SerializeField] protected float durTimeDes = 2f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadText();
        LoadSpriteCoin();
        LoadInstance();
        LoadRectTransform();
    }

    protected virtual void LoadSpriteCoin()
    {
        if (textCoin != null) return;
        textCoin = GameObject.Find("Text Coin").transform;
    }

    protected virtual void LoadInstance()
    {
        if (instance != null) return;
        instance = this;
    }

    protected virtual void LoadText()
    {
        if (text != null) return;
        text = GameObject.Find("Text Coin").GetComponent<TMP_Text>();
    }

    protected virtual void LoadRectTransform()
    {
        if (rectTransform != null) return;
        rectTransform = transform.GetComponent<RectTransform>();
    }

    private void Update()
    {
        transform.DOMoveY(rectTransform.position.y + posTarget, durTimeMove);
        Invoke("DestroyObj", durTimeDes);
    }
    
    protected virtual void DestroyObj()
    {
        rectTransform.anchoredPosition = new Vector2(0, 0);
        Destroy(gameObject);
        //CoinCollectSpawner.Instance.Despawn(gameObject);
    }

    public void GetValueText(int value)
    {
        text.text = "+" + value.ToString();
    }
}