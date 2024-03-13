using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingWaveController : CanvasAbstract
{
    [Header("Load script in childrent")]
    [SerializeField] protected CountWave countWave;
    public CountWave CountWave => countWave;

    [SerializeField] protected TrackingWave trackingWave;
    public TrackingWave TrackingWave => trackingWave;

    [SerializeField] protected TWTrackingWave tWTrackingWave;
    public TWTrackingWave TWTrackingWave => tWTrackingWave;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadCountWave();
        LoadTrackingWave();
        LoadTWTrackingWave();
    }

    protected virtual void LoadCountWave()
    {
        if (countWave != null) return;
        countWave = transform.GetComponentInChildren<CountWave>();
    }

    protected virtual void LoadTrackingWave()
    {
        if (trackingWave != null) return;
        trackingWave = transform.GetComponentInChildren<TrackingWave>();
    }

    protected virtual void LoadTWTrackingWave()
    {
        if (tWTrackingWave != null) return;
        tWTrackingWave = transform.GetComponentInChildren<TWTrackingWave>();
    }
}
