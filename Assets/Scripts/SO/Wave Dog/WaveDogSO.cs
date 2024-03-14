using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveDog", menuName = "ScriptableObject/WaveDog")]
public class WaveDogSO : ScriptableObject
{
    protected static WaveDogSO instance;
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
        Wave wave = new (_wave);
        waves.Add(wave);
    }

    public virtual void CreatNewPhase(Wave wave, int _phase)
    {
        Phase phase = new (_phase);
        wave.phases.Add(phase);
    }

    public virtual void CreatNewLevelDog(Phase phase, int _levelDog, string _nameDog, int _nums, int _hpDog, int _damgeDog, float _timeDelay, string _indexLine)
    {
        LevelDog levelDog = new (_levelDog, _nameDog, _nums, _hpDog, _damgeDog, _timeDelay, _indexLine);
        phase.levelDogs.Add(levelDog);
    }
}