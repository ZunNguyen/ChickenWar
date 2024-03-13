using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core.Easing;

public class TWPanelVictory : ErshenMonoBehaviour
{
    [SerializeField] protected GameObject btClaimVD;
    [SerializeField] protected GameObject btClaim;

    public virtual void TW_PanelVictoryOn()
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
        Debug.Log("havbe");
    }

    public virtual void TW_PanelVictoryOff()
    {
        this.transform.GetComponent<RectTransform>().DOAnchorPosY(-1188, 2f);
    }
}