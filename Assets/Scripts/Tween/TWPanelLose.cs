using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core.Easing;

public class TWPanelLose : ErshenMonoBehaviour
{
    [SerializeField] protected GameObject btClaimVD;
    [SerializeField] protected GameObject btClaim;

    public virtual void TW_PanelLoseOn()
    {
        this.transform.GetComponent<RectTransform>().DOAnchorPosY(0, 2f);
        btClaimVD.GetComponent<RectTransform>().DOScale(new Vector3(1.2f, 1.2f), 2f).SetEase(Ease.InOutQuint);
        btClaim.GetComponent<RectTransform>().DOScale(new Vector3(1.2f, 1.2f), 2f).SetEase(Ease.InOutQuint);
        Invoke(nameof(TW_ButtonOn), 1f);
    }

    protected virtual void TW_ButtonOn()
    {
        btClaimVD.GetComponent<RectTransform>().DOScale(new Vector3(1, 1, 1), 2f).SetEase(Ease.InOutQuint);
        btClaim.GetComponent<RectTransform>().DOScale(new Vector3(1, 1, 1), 2f).SetEase(Ease.InOutQuint);
    }

    public virtual void TW_PanelVLoseOff()
    {
        this.transform.GetComponent<RectTransform>().DOAnchorPosY(-1188, 2f);
    }
}