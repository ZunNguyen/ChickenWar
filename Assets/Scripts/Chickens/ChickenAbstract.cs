using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChickenAbstract : ErshenMonoBehaviour
{
    [Header("Connect Controller")]
    [SerializeField] protected ChickenController chickenController;
    public ChickenController ChickenController => chickenController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadChickenController();
    }
    
    protected virtual void LoadChickenController()
    {
        if (chickenController != null) return;
        chickenController = transform.parent.GetComponent<ChickenController>();
    }
}
