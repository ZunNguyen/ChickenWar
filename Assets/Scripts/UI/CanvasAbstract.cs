using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CanvasAbstract : ErshenMonoBehaviour
{
    [Header("Canvas Abstract")]
    [SerializeField] protected CanvasController canvasController;

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
