using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingWave : ProcessSlider
{
    [Header("Value")]
    [SerializeField] protected float sumDogMax = 1;
    public float sumDogCurrent = 1;
    [SerializeField] protected float valueText = 1;

    [Header("Connect Script")]
    [SerializeField] protected WaveDogSO waveDogSO;
    [SerializeField] protected static TrackingWave instance;
    public static TrackingWave Instance => instance;

    [Header("Connect Script parent")]
    [SerializeField] protected TrackingWaveController trackingWaveController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadWaveDogSO();
        LoadInstance();
        LoadTrackingWaveController();
    }

    protected virtual void LoadWaveDogSO()
    {
        if (waveDogSO != null) return;
        string resPath = "SO/Wave Dog/WaveDog";
        waveDogSO = Resources.Load<WaveDogSO>(resPath);
    }

    protected virtual void LoadTrackingWaveController()
    {
        if (trackingWaveController != null) return;
        trackingWaveController = transform.GetComponentInParent<TrackingWaveController>();
    }

    protected virtual void LoadInstance()
    {
        if (instance != null) return;
        instance = this;
    }

    private void FixedUpdate()
    {
        Slidering();
    }

    protected virtual void Slidering()
    {
        valueText = sumDogCurrent / sumDogMax * 100;
        slider.value = valueText;
    }

    public virtual void GetSumDogMax()
    {
        int index = trackingWaveController.CanvasController.PointSpawnDogController.wave;
        sumDogMax = waveDogSO.waves[index].GetSumDogWave();
        sumDogCurrent = 0;
    }

    public virtual bool CheckEndWave()
    {
        if (sumDogCurrent == sumDogMax) return true;
        return false;
    }
}