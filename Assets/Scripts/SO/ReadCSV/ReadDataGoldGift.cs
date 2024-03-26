using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadDataGoldGift : ErshenMonoBehaviour
{
    [Header("Connect Script")]
    [SerializeField] protected TextAsset textAssetData;

    [Header("Variable")]
    [SerializeField] protected int length = 2;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadTextAssetData();
        ReadingAssetData();
    }

    protected virtual void LoadTextAssetData()
    {
        if (textAssetData != null) return;
        string resPath = "SO/Gold Gift/Data_GoldGift";
        textAssetData = Resources.Load<TextAsset>(resPath);
    }

    public virtual void ReadingAssetData()
    {
        // Take Data
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        int tableSize = data.Length / length - 1;
        ProcessData(data, tableSize);
    }

    protected virtual void ProcessData(string[] data, int tableSize)
    {
        for (int i = 0; i < tableSize; i++)
        {
            int wave = int.Parse(data[length * (i + 1)]);
            float gold = float.Parse(data[length * (i + 1) + 1]);
            GoldGiftSO.Instance.CreatNewGoldGift(wave, gold);
        }
    }
}