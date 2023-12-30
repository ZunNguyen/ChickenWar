using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePositionUI : MonoBehaviour
{
    [SerializeField] protected RectTransform rectTransform;
    [SerializeField] protected float x = -75;
    [SerializeField] protected float y = 12;

    public void Start()
    {
        LoadRectTransform();
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.anchoredPosition = new Vector2(x, y);
    }

    protected virtual void LoadRectTransform()
    {
        if (rectTransform != null) return;
        rectTransform = this.transform.GetComponent<RectTransform>();
    }
}
