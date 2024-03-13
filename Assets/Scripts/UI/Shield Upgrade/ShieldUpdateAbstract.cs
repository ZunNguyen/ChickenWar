using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShieldUpdateAbstract : ErshenMonoBehaviour
{
    [Header("Abstract Shield Update")]
    [SerializeField] protected ShieldUpdateController shieldUpdateController;
    public ShieldUpdateController ShieldUpdateController => shieldUpdateController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadShieldUpdateController();

    }

    protected virtual void LoadShieldUpdateController()
    {
        if (shieldUpdateController != null) return;
        shieldUpdateController = transform.GetComponentInParent<ShieldUpdateController>();
    }
}
