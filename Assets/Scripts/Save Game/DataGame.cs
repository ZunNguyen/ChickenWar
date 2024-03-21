using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataGame
{
    // Gold player
    public float goldPlayer;

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
}
