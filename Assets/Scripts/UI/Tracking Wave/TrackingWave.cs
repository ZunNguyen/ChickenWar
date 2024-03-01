using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingWave : ProcessSlider
{
    [Header("Value")]
    [SerializeField] protected int sumDogMax;
    public int sumDogCurrent;
    [SerializeField] protected float test;

    [Header("Connect Script")]
    [SerializeField] protected WaveDogSO waveDogSO;
    [SerializeField] protected static TrackingWave instance;
    public static TrackingWave Instance => instance;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadWaveDogSO();
        LoadInstance();
    }

    protected virtual void LoadWaveDogSO()
    {
        if (waveDogSO != null) return;
        string resPath = "SO/Wave Dog/WaveDog";
        waveDogSO = Resources.Load<WaveDogSO>(resPath);
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
        test = 90 / sumDogMax * sumDogCurrent;
        slider.value = test;
    }

    public virtual void GetSumDogMax()
    {
        sumDogMax = waveDogSO.waves[0].GetSumDogWave();
        sumDogCurrent = sumDogMax;
    }
}