using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core.Easing;
using Unity.VisualScripting;

public class TWPanelVictoryLose : ErshenMonoBehaviour
{
    [Header("Connect Ctrl")]
    [SerializeField] protected PanelVictoyLoseCtrl panelVictoyLoseCtrl;

    [SerializeField] protected List<GameObject> golds;
    [SerializeField] protected Vector2 savePosition = new(-32, -3);

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPanelVictoryLoseCtrl();
    }

    protected virtual void LoadPanelVictoryLoseCtrl()
    {
        if (panelVictoyLoseCtrl != null) return;
        panelVictoyLoseCtrl = this.transform.GetComponent<PanelVictoyLoseCtrl>();
    }

    public virtual void TW_PanelVictoryLoseOn()
    {
        this.transform.GetComponent<RectTransform>().DOAnchorPosY(0, 1.5f);
    }

    public virtual void TW_PanelVictoryLoseOff(int multiplier)
    {
        TW_EarnGold(multiplier);
        Invoke(nameof(TW_PanelOff), 2f);
    }

    protected virtual void TW_PanelOff()
    {
        this.transform.GetComponent<RectTransform>().DOAnchorPosY(-1188, 2f).OnComplete(() =>
        {
            panelVictoyLoseCtrl.CanvasController.ButtonManager.isClaiming = false;
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
        panelVictoyLoseCtrl.CanvasController.AudioManager.PlaySFX(panelVictoyLoseCtrl.CanvasController.AudioManager.effectEarnGold);

        float goldEarn = panelVictoyLoseCtrl.TextEarnGold.goldEarn / 5;
        float addGold = goldEarn * multiplier;
        GoldPlayer.Instance.AddGoldPlayer((int)addGold);
    }
}