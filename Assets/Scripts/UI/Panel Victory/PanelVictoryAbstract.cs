using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PanelVictoryAbstract : ErshenMonoBehaviour
{
    [Header("Panel victory abstract")]
    [SerializeField] protected PanelVictoryController panelVictoryController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPanelVictoryController();
    }

    protected virtual void LoadPanelVictoryController()
    {
        if (panelVictoryController != null) return;
        panelVictoryController = transform.GetComponentInParent<PanelVictoryController>();
    }
} 
