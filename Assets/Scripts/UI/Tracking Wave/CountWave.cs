using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountWave : ErshenMonoBehaviour
{
    [Header("Connect Script")]
    [SerializeField] protected TrackingWaveController trackingWaveController;

    [SerializeField] protected Text text;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadTextTMP();
        LoadTrackingWave();
    }

    protected virtual void LoadTextTMP()
    {
        if (text != null) return;
        text = transform.GetComponent<Text>();
    }

    protected virtual void LoadTrackingWave()
    {
        if (trackingWaveController != null) return;
        trackingWaveController = transform.parent.GetComponent<TrackingWaveController>();
    }

    public virtual void LoadText()
    {
        int index = trackingWaveController.CanvasController.PointSpawnDogController.wave + 1;
        text.text = "Wave " + index.ToString();
    }
}