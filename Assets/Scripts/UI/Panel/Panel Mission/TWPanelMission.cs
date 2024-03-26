using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TWPanelMission : ErshenMonoBehaviour
{
    public virtual void TW_PanelMissionOn()
    {
        transform.GetComponent<RectTransform>().DOAnchorPosY(0, 2f).SetEase(Ease.OutBack);
    }

    public virtual void TW_PanelMissionOff()
    {
        transform.GetComponent<RectTransform>().DOAnchorPosY(-1150, 2f).SetEase(Ease.OutBack);
    }
}
