using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class TWPanelEarnGoldOffline : ErshenMonoBehaviour
{
    [Header("---Connect Ctrl---")]
    [SerializeField] protected PanelEarnGoldOfflineCtrl panelEarnGoldOfflineCtrl;

    [SerializeField] protected List<GameObject> golds;
    [SerializeField] protected Vector2 savePosition = new(-40, -9);

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPanelEarnGoldOffllineCtrl();
    }

    protected virtual void LoadPanelEarnGoldOffllineCtrl()
    {
        if (panelEarnGoldOfflineCtrl != null) return;
        panelEarnGoldOfflineCtrl = this.transform.GetComponent<PanelEarnGoldOfflineCtrl>();
    }

    public virtual void TW_PanelEarnGoldOfflineOn()
    {
        this.transform.GetComponent<RectTransform>().DOAnchorPosY(0, 1.5f);
    }

    public virtual void TW_PanelEarnGoldOfflineOff(int multiplier)
    {
        TW_EarnGold(multiplier);
        Invoke(nameof(TW_PanelOff), 2f);
    }

    protected virtual void TW_PanelOff()
    {
        this.transform.GetComponent<RectTransform>().DOAnchorPosY(-1188, 2f).OnComplete(() =>
        {
            panelEarnGoldOfflineCtrl.CanvasController.ButtonManager.isClaiming = false;
        });
    }

    protected virtual void TW_EarnGold(int multiplier)
    {
        float delay = 0;
        foreach (GameObject gold in golds)
        {
            gold.transform.DOScale(1f, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);
            gold.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-620, 570), 1f).SetDelay(delay).SetEase(Ease.OutBack).OnComplete(() =>
            {
                gold.transform.DOScale(0f, 0.3f).SetEase(Ease.OutBack).OnComplete(() =>
                {
                    // Audio
                    panelEarnGoldOfflineCtrl.CanvasController.AudioManager.PlaySFX(panelEarnGoldOfflineCtrl.CanvasController.AudioManager.effectEarnGold);
                    gold.GetComponent<RectTransform>().anchoredPosition = savePosition;
                    AddGoldEarn(multiplier);
                });
            });
            delay += 0.2f;
        }
    }

    protected virtual void AddGoldEarn(int multiplier)
    {
        float goldEarn = panelEarnGoldOfflineCtrl.TextEarnGoldOffline.goldEarn / 5;
        int addGold = (int)goldEarn * multiplier;
        GoldPlayer.Instance.AddGoldPlayer(addGold);
    }
}
