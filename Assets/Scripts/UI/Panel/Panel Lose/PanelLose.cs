using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelLose : ErshenMonoBehaviour
{
    [Header("Connect controller")]
    [SerializeField] protected PanelLoseController panelLoseController;
    public PanelLoseController PanelLoseController => panelLoseController;

    [SerializeField] protected TMP_Text textKillDog;
    [SerializeField] protected TMP_Text textEarnGold;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPanelLoseController();
        LoadTextKillDog();
        LoadTextEarnGold();
    }

    protected virtual void LoadPanelLoseController()
    {
        if (panelLoseController != null) return;
        panelLoseController = this.transform.GetComponent<PanelLoseController>();
    }

    protected virtual void LoadTextKillDog()
    {
        if (textKillDog != null) return;
        textKillDog = transform.Find("Image - Lose").Find("Image - Total Kill").Find("Text - Kill").GetComponent<TMP_Text>();
    }

    protected virtual void LoadTextEarnGold()
    {
        if (textEarnGold != null) return;
        textEarnGold = transform.Find("Image - Lose").Find("Image - Your Earn").Find("Text - Earn").GetComponent<TMP_Text>();
    }

    public virtual void GetTextKillDog()
    {
        int numsDog = 0;
        textKillDog.text = numsDog.ToString("d2");
    }

    public virtual void GetTextEarnGold()
    {
        int goldEarn = 0;
        textEarnGold.text = goldEarn.ToString("d2");
    }
}
