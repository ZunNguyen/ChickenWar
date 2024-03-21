using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core.Easing;

public class TWPanel : ErshenMonoBehaviour
{
    [Header("Connect Ctrl")]
    [SerializeField] protected PanelController panelController;

    [SerializeField] protected List<GameObject> golds;
    [SerializeField] protected GameObject btClaimVD;
    [SerializeField] protected GameObject btClaim;
    [SerializeField] protected Vector2 savePosition = new(-32, -3);

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPanelController();
    }

    protected virtual void LoadPanelController()
    {
        if (panelController != null) return;
        panelController = this.transform.GetComponent<PanelController>();
    }

    public virtual void TW_PanelOn()
    {
        this.transform.GetComponent<RectTransform>().DOAnchorPosY(0, 1.5f);
        btClaimVD.GetComponent<RectTransform>().DOScale(new Vector3(1.2f, 1.2f), 1.5f).SetEase(Ease.InOutQuint);
        btClaim.GetComponent<RectTransform>().DOScale(new Vector3(1.2f, 1.2f), 1.5f).SetEase(Ease.InOutQuint);
        Invoke(nameof(TW_ButtonOn), 0.5f);
    }

    protected virtual void TW_ButtonOn()
    {
        btClaimVD.GetComponent<RectTransform>().DOScale(new Vector3(1, 1, 1), 2f).SetEase(Ease.InOutQuint);
        btClaim.GetComponent<RectTransform>().DOScale(new Vector3(1, 1, 1), 2f).SetEase(Ease.InOutQuint);
    }

    public virtual void TW_PanelVictoryOff(int multiplier)
    {
        TW_EarnGold(multiplier);
        Invoke(nameof(TW_PanelOff), 2f);
    }

    protected virtual void TW_PanelOff()
    {
        this.transform.GetComponent<RectTransform>().DOAnchorPosY(-1188, 2f).OnComplete(() =>
        {
            panelController.CanvasController.ButtonManager.isClaiming = false;
        });
    }

    protected virtual void TW_EarnGold(int multiplier)
    {
        float delay = 0;
        foreach (GameObject gold in golds)
        {
            gold.transform.DOScale(1f, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);
            gold.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-615, 555), 1f).SetDelay(delay).SetEase(Ease.OutBack).OnComplete(() =>
            {
                gold.transform.DOScale(0f, 0.3f).SetEase(Ease.OutBack).OnComplete(() =>
                {
                    gold.GetComponent<RectTransform>().anchoredPosition = savePosition;
                    AddGoldEarn(multiplier);
                });
            });
            delay += 0.2f;
        }
    }

    protected virtual void AddGoldEarn(int multiplier)
    {
        // Audio
        panelController.CanvasController.AudioManager.PlaySFX(panelController.CanvasController.AudioManager.effectEarnGold);

        float goldEarn = panelController.TextEarnGold.goldEarn / 5;
        GoldPlayer.Instance.gold += goldEarn * multiplier;
    }
}