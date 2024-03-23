using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingWaveCtrl : CanvasAbstract
{
    [Header("---Connect Inside---")]
    [SerializeField] protected TextCountWave textCountWave;
    public TextCountWave TextCountWave => textCountWave;

    [SerializeField] protected TrackingWave trackingWave;
    public TrackingWave TrackingWave => trackingWave;

    [SerializeField] protected TWTrackingWave tWTrackingWave;
    public TWTrackingWave TWTrackingWave => tWTrackingWave;

    [SerializeField] protected SliderTrackingWave sliderTrackingWave;
    public SliderTrackingWave SliderTrackingWave => sliderTrackingWave;

    [Header("---Load WaveDogSO---")]
    [SerializeField] protected WaveDogSO waveDogSO;
    public WaveDogSO WaveDogSO => waveDogSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadTextCountWave();
        LoadTrackingWave();
        LoadTWTrackingWave();
        LoadSliderTrackingWave();
        LoadWaveDogSO();
    }

    protected virtual void LoadTextCountWave()
    {
        if (textCountWave != null) return;
        textCountWave = transform.GetComponentInChildren<TextCountWave>();
    }

    protected virtual void LoadTrackingWave()
    {
        if (trackingWave != null) return;
        trackingWave = transform.GetComponent<TrackingWave>();
    }

    protected virtual void LoadTWTrackingWave()
    {
        if (tWTrackingWave != null) return;
        tWTrackingWave = transform.GetComponent<TWTrackingWave>();
    }

    protected virtual void LoadSliderTrackingWave()
    {
        if (sliderTrackingWave != null) return;
        sliderTrackingWave = transform.GetComponentInChildren<SliderTrackingWave>();
    }

    protected virtual void LoadWaveDogSO()
    {
        if (waveDogSO != null) return;
        string resPath = "SO/Wave Dog/WaveDog";
        waveDogSO = Resources.Load<WaveDogSO>(resPath);
    }
}
