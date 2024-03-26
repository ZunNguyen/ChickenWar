using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MissionSO", menuName = "ScriptableObject/Mission")]
public class MissionSO : ScriptableObject
{
    [Header("Instance")]
    protected static MissionSO instance;
    public static MissionSO Instance => instance;

    public float missionMax_1;
    public List<Mission> mission_1;

    public float missionMax_2;
    public List<Mission> mission_2;

    public float missionMax_3;
    public List<Mission> mission_3;

    public float missionMax_4;
    public List<Mission> mission_4;

    private void Reset()
    {
        LoadInstance();
    }

    protected virtual void LoadInstance()
    {
        if (instance != null) return;
        instance = this;
    }

    public void CreatNewMission(string _missionIndex, float _mission, float _prize, List<Mission> missionName)
    {
        Mission mission = new(_missionIndex, _mission, _prize);
        missionName.Add(mission);
    }
}
