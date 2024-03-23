using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CanvasAbstract : ErshenMonoBehaviour
{
    [Header("---Connect CanvasCtrl---")]
    [SerializeField] protected CanvasController canvasController;
    public CanvasController CanvasController => canvasController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadCanvasController();
    }

    protected virtual void LoadCanvasController()
    {
        if (canvasController != null) return;
        canvasController = GameObject.Find("Canvas").GetComponent<CanvasController>();
    }
}
