using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public abstract class TWEarnGold : ErshenMonoBehaviour
{
    [SerializeField] protected List<GameObject> golds;
    [SerializeField] protected int countGolds = 5;
    [SerializeField] protected bool isClaiming = false;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadGameObjGold();
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

    public virtual void TW_EarnGold(int multiplier, float goldEarn)
    {
        if (isClaiming) return;
        isClaiming = true;
        float delay = 0;
        foreach (GameObject gold in golds)
        {
            gold.transform.DOScale(1f, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);
            gold.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-615, 555), 1f).SetDelay(delay).SetEase(Ease.OutBack).OnComplete(() =>
            {
                gold.transform.DOScale(0f, 0.3f).SetEase(Ease.OutBack).OnComplete(() =>
                {
                    gold.GetComponent<RectTransform>().anchoredPosition = SavePosition();
                    AddGoldEarn(multiplier, goldEarn);
                });
            });
            delay += 0.2f;
        }
    }

    public virtual void SetIsClaimingIsFalse()
    {
        isClaiming = false;
    }

    protected abstract Vector2 SavePosition();

    protected virtual void AddGoldEarn(int multiplier, float goldEarn)
    {
        SetAudioEffectEarnGold();

        float goldAdd = goldEarn / countGolds;
        float addGold = goldAdd * multiplier;
        GoldPlayer.Instance.AddGoldPlayer((int)addGold);
    }

    protected abstract void SetAudioEffectEarnGold();
}
