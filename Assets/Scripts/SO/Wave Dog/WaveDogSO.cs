using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveDog", menuName = "ScriptableObject/WaveDog")]
public class WaveDogSO : ScriptableObject
{
    [SerializeField] protected static WaveDogSO instance;
    public static WaveDogSO Instance => instance;

    public List<Wave> waves;

    private void Reset()
    {
        LoadInstance();
    }

    protected virtual void LoadInstance()
    {
        if (instance != null) return;
        instance = this;
    }

    public virtual void CreatNewWave(int _wave)
    {
        Wave wave = new Wave(_wave);
        waves.Add(wave);
    }

    public virtual void CreatNewPhase(Wave wave, int _phase)
    {
        Phase phase = new Phase(_phase);
        wave.phases.Add(phase);
    }

    public virtual void CreatNewLevelDog(Phase phase, int _levelDog, string _nameDog, int _nums, int _hpDog,float _timeDelay, string _indexLine)
    {
        LevelDog levelDog = new LevelDog(_levelDog, _nameDog, _nums, _hpDog, _timeDelay, _indexLine);
        phase.levelDogs.Add(levelDog);
    }
}