using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingWaveController : CanvasAbstract
{
    [Header("Load script in childrent")]
    [SerializeField] protected CountWave countWave;
    public CountWave CountWave => countWave;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadCountWave();
    }

    protected virtual void LoadCountWave()
    {
        if (countWave != null) return;
        countWave = transform.GetComponentInChildren<CountWave>();
    }
}
