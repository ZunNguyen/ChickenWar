using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TWText : CanvasAbstract
{
    [Header("Connect Script")]
    [SerializeField] protected RectTransform rectTransform;
    [SerializeField] protected Text text;

    [Header("Value")]
    [SerializeField] protected float posTarget = 150f;
    [SerializeField] protected float durTimeMove = 1.5f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadRectTransform();
        LoadText();
    }

    protected virtual void LoadRectTransform()
    {
        if (rectTransform != null) return;
        rectTransform = transform.GetComponent<RectTransform>();
    }

    protected virtual void LoadText()
    {
        if (text != null) return;
        text = transform.GetComponentInChildren<Text>();
    }

    public virtual void TWTextOn(string inputText)
    {
        text.text = inputText;
        rectTransform.DOAnchorPosY(rectTransform.anchoredPosition.y + posTarget, durTimeMove).OnComplete(()=>
        {
            canvasController.TWTextSpawner.Despawn(gameObject.transform);
        });
    }
}