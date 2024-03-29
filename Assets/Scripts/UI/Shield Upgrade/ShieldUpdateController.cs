using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUpdateController : CanvasAbstract
{
    [Header("---Connect InSide---")]
    [SerializeField] protected ShieldHPBar shieldHPBar;
    public ShieldHPBar ShieldHPBar => shieldHPBar;

    [SerializeField] protected ShieldGoldUpdate shieldGoldUpdate;
    public ShieldGoldUpdate ShieldGoldUpdate => shieldGoldUpdate;

    [SerializeField] protected ShieldHPText shieldHPText;
    public ShieldHPText ShieldHPText => shieldHPText;

    [SerializeField] protected ShieldUpdate shieldUpdate;
    public ShieldUpdate ShieldUpdate => shieldUpdate;

    [SerializeField] protected ShieldSO shieldSO;
    public ShieldSO ShieldSO => shieldSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadShieldHPBar();
        LoadShieldGoldUpdate();
        LoadShieldHPText();
        LoadShieldUpdate();
        LoadShieldSO();
    }

    protected virtual void LoadShieldHPBar()
    {
        if (shieldHPBar != null) return;
        shieldHPBar = transform.GetComponentInChildren<ShieldHPBar>();
    }

    protected virtual void LoadShieldGoldUpdate()
    {
        if (shieldGoldUpdate != null) return;
        shieldGoldUpdate = transform.GetComponentInChildren<ShieldGoldUpdate>();
    }

    protected virtual void LoadShieldHPText()
    {
        if (shieldHPText != null) return;
        shieldHPText = transform.GetComponentInChildren<ShieldHPText>();
    }

    protected virtual void LoadShieldUpdate()
    {
        if (shieldUpdate != null) return;
        shieldUpdate = transform.GetComponent<ShieldUpdate>();
    }

    protected virtual void LoadShieldSO()
    {
        if (shieldSO != null) return;
        string resPath = "SO/Shield/Shield";
        shieldSO = Resources.Load<ShieldSO>(resPath);
    }
}
