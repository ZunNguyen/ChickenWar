using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TWPanelPasue : ErshenMonoBehaviour
{
    public virtual void TW_PanelPasueOn()
    {
        transform.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 1.8f).SetEase(Ease.OutBack).SetUpdate(true);
    }

    public virtual void TW_PanelPasueOff()
    {
        transform.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, -1130), 1.8f).SetUpdate(true);
    }
}
