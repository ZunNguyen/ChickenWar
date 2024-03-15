using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLoseController : CanvasAbstract
{
    [SerializeField] protected TWPanelLose tWPanelLose;
    public TWPanelLose TWPanelLose => tWPanelLose;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadTWPanelLose();
    }

    protected virtual void LoadTWPanelLose()
    {
        if (tWPanelLose != null) return;
        tWPanelLose = this.transform.GetComponent<TWPanelLose>();
    }
}
