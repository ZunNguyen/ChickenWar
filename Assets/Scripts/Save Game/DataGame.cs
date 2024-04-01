using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataGame
{
    // Gold player
    public Int64 goldPlayer;

    // Wave Dog
    public int waveDog;

    // Shield Update
    public int levelShield;

    // Button Spawn
    public int highestLevelChicken;
    public int levelSpawnChicken;

    // Save chicken in board
    public List<int> indexSlot = new();
    public List<string> nameChicken = new();

    // Save Volume
    public float volumeMusic;
    public float volumeSFX;

    // Save Time Game
    public string lastTimeExit;

    // Save achievement player
    public List<float> achievementList = new();
    public List<float> missionCurrentList = new();
    public List<int> indexMissionList = new();

    // Save tutorial
    public bool learnTutorial;
}
