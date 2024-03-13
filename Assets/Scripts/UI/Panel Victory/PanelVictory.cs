using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelVictory : ErshenMonoBehaviour
{
    [Header("Connect controller")]
    [SerializeField] protected PanelVictoryController panelVictoryController;
    public PanelVictoryController PanelVictoryController => panelVictoryController;

    [SerializeField] protected TMP_Text textWaveDog;
    [SerializeField] protected TMP_Text textKillDog;
    [SerializeField] protected TMP_Text textEarnGold;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPanelVictoryController();
        LoadTextWaveDog();
        LoadTextKillDog();
        LoadTextEarnGold();
    }

    protected virtual void LoadPanelVictoryController()
    {
        if (panelVictoryController != null) return;
        panelVictoryController = this.transform.GetComponent<PanelVictoryController>();
    }

    protected virtual void LoadTextWaveDog()
    {
        if (textWaveDog != null) return;
        textWaveDog = transform.Find("Image - Victory").Find("Text - Victory").GetComponent<TMP_Text>();
    }

    protected virtual void LoadTextKillDog()
    {
        if (textKillDog != null) return;
        textKillDog = transform.Find("Image - Victory").Find("Image - Total Kill").Find("Text - Kill").GetComponent<TMP_Text>();
    }

    protected virtual void LoadTextEarnGold()
    {
        if (textEarnGold != null) return;
        textEarnGold = transform.Find("Image - Victory").Find("Image - Your Earn").Find("Text - Earn").GetComponent<TMP_Text>();
    }

    public virtual void GetTextWaveDog()
    {
        int index = panelVictoryController.CanvasController.PointSpawnDogController.wave + 1;
        textWaveDog.text = "Wave " + index.ToString("d2") + " Clear";
    }

    public virtual void GetTextKillDog()
    {
        int numsDog = 0;
        textWaveDog.text = numsDog.ToString("d2");
    }

    public virtual void GetTextEarnGold()
    {
        int goldEarn = 0;
        textWaveDog.text = goldEarn.ToString("d2");
    }
}
