using UnityEngine;

public class PanelVictoyLoseCtrl : CanvasAbstract
{
    [Header("Connect Inside")]
    [SerializeField] protected PanelVictoryLose panelVictoryLose;
    public PanelVictoryLose PanelVictoryLose => panelVictoryLose;

    [SerializeField] protected TWPanelVictoryLose tWPanelVictoryLose;
    public TWPanelVictoryLose TWPanelVictoryLose => tWPanelVictoryLose;

    [SerializeField] protected TextKill textKill;
    public TextKill TextKill => textKill;

    [SerializeField] protected TextEarnGold textEarnGold;
    public TextEarnGold TextEarnGold => textEarnGold;

    [SerializeField] protected TextPanel textPanel;
    public TextPanel TextPanel => textPanel;

    [Header("Connect GiftGold SO")]
    [SerializeField] protected GoldGiftSO goldGiftSO;
    public GoldGiftSO GoldGiftSO => goldGiftSO;

    protected override void LoadCanvasController()
    {
        base.LoadCanvasController();
        LoadPanelVictoryLose();
        LoadTWPanelVictoryLose();
        LoadTextKill();
        LoadTextEarnGold();
        LoadTextPanel();
        LoadGoldGiftSO();
    }

    protected virtual void LoadPanelVictoryLose()
    {
        if (panelVictoryLose != null) return;
        panelVictoryLose = transform.GetComponentInChildren<PanelVictoryLose>();
    }

    protected virtual void LoadTWPanelVictoryLose()
    {
        if (tWPanelVictoryLose != null) return;
        tWPanelVictoryLose = transform.GetComponentInChildren<TWPanelVictoryLose>();
    }

    protected virtual void LoadTextKill()
    {
        if (textKill != null) return;
        textKill = transform.GetComponentInChildren<TextKill>();
    }

    protected virtual void LoadTextEarnGold()
    {
        if (textEarnGold != null) return;
        textEarnGold = transform.GetComponentInChildren<TextEarnGold>();
    }

    protected virtual void LoadTextPanel()
    {
        if (textPanel != null) return;
        textPanel = transform.GetComponentInChildren<TextPanel>();
    }

    protected virtual void LoadGoldGiftSO()
    {
        if (goldGiftSO != null) return;
        string resPath = "SO/Gold Gift/GoldGiftSO";
        goldGiftSO = Resources.Load<GoldGiftSO>(resPath);
    }
}