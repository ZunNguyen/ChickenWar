using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ReadDataMission : ErshenMonoBehaviour
{
    [Header("Connect Script")]
    [SerializeField] protected TextAsset textAssetData;

    [Header("Variable")]
    [SerializeField] protected int length = 12;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadTextAssetData();
        ReadingAssetData();
    }

    protected virtual void LoadTextAssetData()
    {
        if (textAssetData != null) return;
        string resPath = "SO/Mission/Data_Mission";
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
        for (int i = 0; i <= tableSize - 2; i++)
        {
            CreatMission_1(data, i);
            CreatMission_2(data, i);
            CreatMission_3(data, i);
            CreatMission_4(data, i);
        }
    }

    protected virtual void CreatMission_1(string[] data, int index)
    {
        string missionIndex = data[length * (index + 2)];
        float mission = int.Parse(data[length * (index + 2) + 1]);
        float prize = int.Parse(data[length * (index + 2) + 2]);
        MissionSO.Instance.CreatNewMission(missionIndex, mission, prize, MissionSO.Instance.mission_1);
    }

    protected virtual void CreatMission_2(string[] data, int index)
    {
        string missionIndex = data[length * (index + 2) + 3];
        float mission = int.Parse(data[length * (index + 2) + 4]);
        float prize = int.Parse(data[length * (index + 2) + 5]);
        MissionSO.Instance.CreatNewMission(missionIndex, mission, prize, MissionSO.Instance.mission_2);
    }

    protected virtual void CreatMission_3(string[] data, int index)
    {
        string missionIndex = data[length * (index + 2) + 6];
        float mission = int.Parse(data[length * (index + 2) + 7]);
        float prize = int.Parse(data[length * (index + 2) + 8]);
        MissionSO.Instance.CreatNewMission(missionIndex, mission, prize, MissionSO.Instance.mission_3);
    }

    protected virtual void CreatMission_4(string[] data, int index)
    {
        string missionIndex = data[length * (index + 2) + 9];
        float mission = int.Parse(data[length * (index + 2) + 10]);
        float prize = int.Parse(data[length * (index + 2) + 11]);
        MissionSO.Instance.CreatNewMission(missionIndex, mission, prize, MissionSO.Instance.mission_4);
    }
}
