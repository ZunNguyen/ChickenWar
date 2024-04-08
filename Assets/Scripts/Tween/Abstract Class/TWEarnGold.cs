using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public abstract class TWEarnGold : ErshenMonoBehaviour
{
    [SerializeField] protected List<GameObject> golds;
    [SerializeField] protected GameObject goldPlayer;
    [SerializeField] protected int countGolds = 5;
    [SerializeField] protected bool isClaiming = false;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadGameObjGold();
        LoadGoldPlayer();
    }

    protected virtual void LoadGameObjGold()
    {
        if (golds.Count == countGolds) return;
        Transform goldParent = transform.Find("Gold");
        foreach (Transform gold in goldParent)
        {
            golds.Add(gold.gameObject);
        }
    }

    protected virtual void LoadGoldPlayer()
    {
        if (goldPlayer != null) return;
        goldPlayer = GameObject.Find("Gold Player").transform.Find("Image - Gold Player").gameObject;
    }

    public virtual void TW_EarnGold(int multiplier, float goldEarn)
    {
        if (isClaiming) return;
        isClaiming = true;
        float delay = 0;
        Vector2 posSave = GetPositionSave();
        Vector2 posTarget = GetPositionGoldPlayer();
        foreach (GameObject gold in golds)
        {
            gold.transform.DOScale(1f, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);
            gold.GetComponent<RectTransform>().DOAnchorPos(posTarget, 1f).SetDelay(delay).SetEase(Ease.OutBack).OnComplete(() =>
            {
                gold.transform.DOScale(0f, 0.3f).SetEase(Ease.OutBack).OnComplete(() =>
                {
                    gold.GetComponent<RectTransform>().anchoredPosition = posSave;
                    ;
                    AddGoldEarn(multiplier, goldEarn);
                });
            });
            delay += 0.2f;
        }
    }

    protected virtual Vector2 GetPositionGoldPlayer()
    {
        RectTransform rectCanvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        float widthCanvas = rectCanvas.sizeDelta.x;
        float heightCanvas = rectCanvas.sizeDelta.y;
        RectTransform rectTransform = goldPlayer.GetComponent<RectTransform>();
        float xGoldPlayer = rectTransform.anchoredPosition.x;
        float yGoldPlayer = rectTransform.anchoredPosition.y;
        Vector2 posTarget;
        posTarget.x = -(widthCanvas / 2) + xGoldPlayer;
        posTarget.y = (heightCanvas / 2) + yGoldPlayer;
        return posTarget;
    }

    public virtual void SetIsClaimingIsFalse()
    {
        isClaiming = false;
    }

    protected virtual Vector2 GetPositionSave()
    {
        Vector2 temp;
        RectTransform rectTransform = golds[0].GetComponent<RectTransform>();
        temp = rectTransform.anchoredPosition;
        return temp;
    }

    protected virtual void AddGoldEarn(int multiplier, float goldEarn)
    {
        SetAudioEffectEarnGold();

        float goldAdd = goldEarn / countGolds;
        float addGold = goldAdd * multiplier;
        GoldPlayer.Instance.AddGoldPlayer((int)addGold);
    }

    protected abstract void SetAudioEffectEarnGold();
}
