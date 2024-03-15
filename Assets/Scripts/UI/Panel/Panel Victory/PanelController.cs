using UnityEngine;

public class PanelController : CanvasAbstract
{
    [Header("Connect Inside")]
    [SerializeField] protected Panel panel;
    public Panel Panel => panel;

    [SerializeField] protected TWPanel tWPanel;
    public TWPanel TWPanel => tWPanel;

    [SerializeField] protected TextKill textKill;
    public TextKill TextKill => textKill;

    [SerializeField] protected TextEarnGold textEarnGold;
    public TextEarnGold TextEarnGold => textEarnGold;

    [SerializeField] protected TextPanel textPanel;
    public TextPanel TextPanel => textPanel;

    protected override void LoadCanvasController()
    {
        base.LoadCanvasController();
        LoadPanel();
        LoadTWPanel();
        LoadTextKill();
        LoadTextEarnGold();
        LoadTextPanel();
    }

    protected virtual void LoadPanel()
    {
        if (panel != null) return;
        panel = transform.GetComponent<Panel>();
    }

    protected virtual void LoadTWPanel()
    {
        if (tWPanel != null) return;
        tWPanel = transform.GetComponent<TWPanel>();
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
}