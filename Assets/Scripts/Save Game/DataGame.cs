using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataGame
{
    // Gold player
    public int goldPlayer;

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
}
