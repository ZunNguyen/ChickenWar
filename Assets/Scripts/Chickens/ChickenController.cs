using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChickenController : ErshenMonoBehaviour
{
    [SerializeField] protected ChickenSO chickenSO;
    public ChickenSO ChickenSO => chickenSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadChickenSO();
    }

    protected virtual void LoadChickenSO()
    {
        if (chickenSO != null) return;
        string resPath = "SO/Chickens/" + this.transform.name;
        chickenSO = Resources.Load<ChickenSO>(resPath);
    }
}
