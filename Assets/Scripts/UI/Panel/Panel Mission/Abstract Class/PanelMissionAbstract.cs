using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PanelMissionAbstract : ErshenMonoBehaviour
{
    [Header("---Connect Ctrl---")]
    [SerializeField] protected PanelMissionCtrl panelMissionCtrl;

    [Header("---Load Text---")]
    [SerializeField] protected Text textDescription;
    [SerializeField] protected Text textGold;

    [Header("---Load Image---")]
    [SerializeField] protected Image imageButton;
    [SerializeField] protected Image imageGold;

    [Header("---Value---")]
    [SerializeField] protected float goldPrice;
    [SerializeField] protected float indexMissionMax;
    public float achievementPlayer = 1;
    public float missionCurrent;
    public int indexMission;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPanelMissionCtrl();
        LoadTextDescription();
        LoadTextGold();
        LoadImageButton();
        LoadImageGold();
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
        if (textGold != null) return;
        textGold = transform.Find("Button - Mission").GetComponentInChildren<Text>();
    }

    protected virtual void LoadImageButton()
    {
        if (imageButton != null) return;
        imageButton = transform.Find("Button - Mission").GetComponent<Image>();
    }

    protected virtual void LoadImageGold()
    {
        if (imageGold != null) return;
        imageGold = transform.Find("Button - Mission").Find("Image - Gold").GetComponent<Image>();
    }

    private void Start()
    {
        LoadBegin();
    }

    protected virtual void LoadBegin()
    {
        LoadMissionInformation();
        AddAchievementPlayer(0);
    }

    public virtual void PressButtonClaim()
    {
        // Audio
        panelMissionCtrl.CanvasController.AudioManager.PlaySFX(panelMissionCtrl.CanvasController.AudioManager.effectClick);

        // Check can claim
        if (!CanClaim())
        {
            //Debug.Log("Can not claim " + this.gameObject.name);
            return;
        }

        // Animation for earn gold
        TW_EarnGold();
        indexMission += 1;

        imageButton.color = Color.gray;
        imageGold.color = Color.gray;

        LoadMissionInformation();
    }

    protected virtual bool CanClaim()
    {
        if(indexMission == indexMissionMax) return false;
        if(achievementPlayer < missionCurrent) return false;
        return true;
    }

    protected abstract void TW_EarnGold();

    public virtual void LoadMissionInformation()
    {
        InputTextDescription();
        InputTextButton();
    }

    protected abstract void InputTextDescription();

    protected virtual void InputTextButton()
    {
        if (indexMission == indexMissionMax)
        {
            textGold.text = "Max";
            return;
        }
        goldPrice = GetEarnGold();
        string goldString = ChangeValueFromTextToString(goldPrice);
        textGold.text = goldString;
    }

    protected abstract float GetEarnGold();

    protected virtual string ChangeValueFromTextToString(float value)
    {
        if (value < 1000)
        {
            return value.ToString();
        }
        if (value >= 1000 && value < 1000000)
        {
            return (value / 1000).ToString("n0") + "K";
        }
        if (value >= 1000000 && value < 1000000000)
        {
            return (value / 1000000).ToString("n0") + "M";
        }
        if (value >= 1000000000 && value < 1000000000000)
        {
            return (value / 1000000000).ToString("n0") + "B";
        }
        if (value >= 1000000000000 && value < 1000000000000000)
        {
            return (value / 1000000000000).ToString("n0") + "T";
        }
        return "";
    }

    public virtual void AddAchievementPlayer(float add)
    {
        achievementPlayer += add;
        if (achievementPlayer >= missionCurrent && indexMission != indexMissionMax)
        {
            imageButton.color = Color.white;
            imageGold.color = Color.white;
            if(!panelMissionCtrl.PanelMission.isActingPanel) panelMissionCtrl.PanelMission.OnMark();
        }
    }
}
