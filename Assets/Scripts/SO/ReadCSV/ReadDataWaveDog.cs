using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ReadDataWaveDog : ErshenMonoBehaviour
{
    [Header("Connect Script")]
    [SerializeField] protected TextAsset textAssetData;

    [Header("Variable")]
    [SerializeField] protected int horizolNums = 10;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadTextAssetData();
        ReadingAssetData();
    }

    protected virtual void LoadTextAssetData()
    {
        if (textAssetData != null) return;
        string resPath = "SO/Wave Dog/Data_WaveDog";
        textAssetData = Resources.Load<TextAsset>(resPath);
    }

    public virtual void ReadingAssetData()
    {
        // Take Data
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        int tableSize = data.Length / horizolNums - 1;

        ProcessWave(tableSize, data);
    }

    // Process Wave
    protected virtual void ProcessWave(int tableSize, string[] data)
    {
        int countSameWave = 0;
        int wave = -1;
        for (int i = 0; i < tableSize - 1; i++)
        {
            // Take value
            int waveBefore = int.Parse(data[horizolNums * (i + 1)]);
            int waveAfter = int.Parse(data[horizolNums * (i + 2)]);

            // Count wave each the wave through with same one
            countSameWave += 1;

            if (waveAfter != waveBefore)
            {
                wave += 1;
                WaveDogSO.Instance.CreatNewWave(wave);
                ProcessPhase(i - countSameWave + 1, i, data, wave);
                countSameWave = 0;
            }
        }
    }

    // Process Phase
    protected virtual void ProcessPhase(int i_begin, int i_finish, string[] data, int waveIndex)
    {
        int countSamePhase = 0;
        int phase = -1;
        for (int i = i_begin; i <= i_finish; i++)
        {
            // Take value
            int phaseBefore = int.Parse(data[horizolNums * (i + 1) + 1]);
            int phaseAfter = int.Parse(data[horizolNums * (i + 2) + 1]);

            countSamePhase += 1;

            // Check next phase
            if (phaseBefore != phaseAfter)
            {
                phase += 1;
                //Debug.Log(countSamePhase);
                WaveDogSO.Instance.CreatNewPhase(WaveDogSO.Instance.waves[waveIndex], phase);
                ProcessLevelDog(i - countSamePhase + 1, i, data, waveIndex, phase);
                countSamePhase = 0;
            }
        }
    }

    // Process Level Dog
    protected virtual void ProcessLevelDog(int i_begin, int i_finish, string[] data, int waveIndex, int phaseIndex)
    {
        int countSameLevelDog = 0;
        int levelDog = -1;
        for (int i = i_begin; i <= i_finish; i++)
        {
            // Take value
            int phaseBefore = int.Parse(data[horizolNums * (i + 1) + 2]);
            int phaseAfter = int.Parse(data[horizolNums * (i + 2) + 2]);

            countSameLevelDog += 1;

            // Check next phase
            if (phaseBefore != phaseAfter)
            {
                levelDog += 1;

                // Take value
                string nameDog = data[horizolNums * (i + 1) + 3];
                float scaleValue = float.Parse(data[horizolNums * (i + 1) + 4]);
                int nums = int.Parse(data[horizolNums * (i + 1) + 5]);
                int hpDog = int.Parse(data[horizolNums * (i + 1) + 6]);
                int damageDog = int.Parse(data[horizolNums * (i + 1) + 7]);
                int timeDelay = int.Parse(data[horizolNums * (i + 1) + 8]);
                string indexLine = data[horizolNums * (i + 1) + 9];
                WaveDogSO.Instance.CreatNewLevelDog(WaveDogSO.Instance.waves[waveIndex].phases[phaseIndex], levelDog, nameDog, scaleValue,nums, hpDog, damageDog, timeDelay, indexLine);
                countSameLevelDog = 0;
            }
        }
    }
}