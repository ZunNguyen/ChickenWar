using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TWPanelMission : ErshenMonoBehaviour
{
    [Header("---Connect Ctrl---")]
    [SerializeField] protected PanelMissionCtrl panelMissionCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPanelMissionCtrl();
    }

    protected virtual void LoadPanelMissionCtrl()
    {
        if (panelMissionCtrl != null) return;
        panelMissionCtrl = transform.GetComponent<PanelMissionCtrl>();
    }

    public virtual void TW_PanelMissionOn()
    {
        transform.GetComponent<RectTransform>().DOAnchorPosY(0, 2f).SetEase(Ease.OutBack);
    }

    public virtual void TW_PanelMissionOff()
    {
        transform.GetComponent<RectTransform>().DOAnchorPosY(-1150, 2f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            panelMissionCtrl.PanelMission.isActingPanel = false;
        });
    }
}
