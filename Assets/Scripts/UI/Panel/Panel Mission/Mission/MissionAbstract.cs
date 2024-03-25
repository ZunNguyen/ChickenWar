using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MissionAbstract : ErshenMonoBehaviour
{
    [Header("---Connect Ctrl---")]
    [SerializeField] protected PanelMissionCtrl panelMissionCtrl;

    [Header("---Load Text---")]
    [SerializeField] protected Text textDescription;

    [SerializeField] protected Text textGold;

    [Header("---Value---")]
    [SerializeField] protected float goldPrice;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPanelMissionCtrl();
        LoadTextDescription();
        LoadTextGold();
    }

    protected virtual void LoadPanelMissionCtrl()
    {
        if (panelMissionCtrl != null) return;
        panelMissionCtrl = transform.parent.parent.GetComponent<PanelMissionCtrl>();
    }

    protected virtual void LoadTextDescription()
    {
        if (textDescription != null) return;
        textDescription = transform.Find("Text - Description").GetComponent<Text>();
    }

    protected virtual void LoadTextGold()
    {
        if (textDescription != null) return;
        textDescription = transform.Find("Button - Mission").GetComponentInChildren<Text>();
    }

    protected abstract void InputTextDescription();

    protected virtual void InputTextButton(float gold)
    {
        goldPrice = gold;
        string goldString = ChangeValueFromTextToString(gold);
        textGold.text = goldString;
    }

    protected virtual string ChangeValueFromTextToString(float value)
    {
        if (value < 1000)
        {
            return value.ToString();
        }
        if (value >= 1000 && value < 1000000)
        {
            return (value / 1000).ToString("n1") + "K";
        }
        if (value >= 1000000 && value < 1000000000)
        {
            return (value / 1000000).ToString("n1") + "M";
        }
        if (value >= 1000000000 && value < 1000000000000)
        {
            return (value / 1000000000).ToString("n1") + "B";
        }
        return "";
    }
    
    protected virtual void PressButtonClaim()
    {
        // Audio
        panelMissionCtrl.CanvasController.AudioManager.PlaySFX(panelMissionCtrl.CanvasController.AudioManager.effectClick);

        // Add gold
        panelMissionCtrl.CanvasController.GoldPlayer.AddGoldPlayer((int)goldPrice);

        // Animation for earn gold
        TW_EarnGold();
    }

    protected virtual void TW_EarnGold()
    {

    }
}
