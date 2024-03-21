using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TWPanelSetting : ErshenMonoBehaviour
{
    public virtual void TW_PaneSettingOn()
    {
        transform.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 1.8f).SetEase(Ease.OutBack).SetUpdate(true);

    }

    public virtual void TW_PaneSettingOff()
    {
        transform.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 1130), 1.8f).SetEase(Ease.OutBack).SetUpdate(true);
    }
}
