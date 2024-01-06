using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObject/Chickens")]
public class ChickenSO : ScriptableObject
{
    public List<LevelChicken> levels;

    public virtual int GetIndexChicken(string name)
    {
        foreach(LevelChicken level in levels)
        {
            if (name == level.name) return levels.IndexOf(level);
        }
        return -1;
    }
}