using Mono.Cecil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingWave : ErshenMonoBehaviour
{
    [Header("---Connect Ctrl---")]
    [SerializeField] protected TrackingWaveCtrl trackingWaveCtrl;

    [Header("---Value---")]
    [SerializeField] protected int sumDogMax;
    public int sumDogCurrent;
    public int sumDogDeath;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadTrackingWaveCtrl();
    }

    protected virtual void LoadTrackingWaveCtrl()
    {
        if (trackingWaveCtrl != null) return;
        trackingWaveCtrl = transform.GetComponent<TrackingWaveCtrl>();
    }

    public virtual void TrackingWaveOn()
    {
        int index = trackingWaveCtrl.CanvasController.PointSpawnDogController.wave;
        if (index == 40)
        {
            Debug.Log("The Wave is Max");
            return;
        } 
        GetSumDog(index);
        GetTextWaveDog(index);
        trackingWaveCtrl.TWTrackingWave.TW_TrackingWaveOn();
    }

    public virtual void TrackingWaveOff()
    {
        trackingWaveCtrl.TWTrackingWave.TW_TrackingWaveOff();
    }

    protected virtual void GetSumDog(int indexWave)
    {
        sumDogMax = trackingWaveCtrl.WaveDogSO.waves[indexWave].GetSumDogWave();
        sumDogCurrent = 0;
        sumDogDeath = 0;

        // Reset slider
        trackingWaveCtrl.SliderTrackingWave.Slidering(sumDogCurrent, sumDogMax);
    }

    public virtual void GetTextWaveDog(int indexWave)
    {
        // Because indexWave begin is 0, but the text must show 1
        trackingWaveCtrl.TextCountWave.ChangeText(indexWave + 1);
    }

    public virtual void AddNumDogCurrent()
    {
        sumDogCurrent += 1;
        trackingWaveCtrl.SliderTrackingWave.Slidering(sumDogCurrent, sumDogMax);
    }

    public virtual bool CheckEndWave()
    {
        if (sumDogDeath == sumDogMax) return true;
        return false;
    }
}