using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class TWEarnGoldPanel : TWEarnGold
{
    public virtual void TW_PanelOn()
    {
        this.transform.GetComponent<RectTransform>().DOAnchorPosY(0, 1.5f);
    }

    public virtual void TW_PanelOff(int multiplier, float goldEarn)
    {
        TW_EarnGold(multiplier, goldEarn);
        Invoke(nameof(TW_PanelOff_2), 2f);
    }

    protected virtual void TW_PanelOff_2()
    {
        this.transform.GetComponent<RectTransform>().DOAnchorPosY(-1188, 2f).OnComplete(() =>
        {
            // Set Claiming is false -> for button
            ResetStatusBtn();
        });
    }

    protected abstract void ResetStatusBtn();
}
