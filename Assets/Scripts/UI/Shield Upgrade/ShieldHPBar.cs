using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShieldHPBar : ProcessSlider
{
    [Header("Load Controller")]
    [SerializeField] protected ShieldUpdateController shieldUpdateController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadShieldUpdateController();
    }

    protected virtual void LoadShieldUpdateController()
    {
        if (shieldUpdateController != null) return;
        shieldUpdateController = transform.parent.GetComponent<ShieldUpdateController>();
    }

    public virtual void ChangeSlider(float hpCurrent, float hpMax)
    {
        if (hpCurrent <= 0)
        {
            shieldUpdateController.CanvasController.PanelController.Panel.PanelLoseOn();
            hpCurrent = 0;
        }
        float value = (hpCurrent * 100 / hpMax);
        slider.value = value;
    }
}
