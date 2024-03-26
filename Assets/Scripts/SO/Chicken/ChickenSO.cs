using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObject/Chickens")]
public class ChickenSO : ScriptableObject
{
    protected static ChickenSO instance;
    public static ChickenSO Instance => instance;

    public List<LevelChicken> levels;

    protected void Reset()
    {
        LoadInstance();
    }

    protected virtual void LoadInstance()
    {
        if (instance != null) return;
        instance = this;
    }

    public void CreatNewLevelChicken(string _nameChicken, Sprite _chickenImage, Sprite _gunImage, Sprite _levelImage, int _goldEarn, int _timeDelayEarnGold, int _goldUpdate,string _nameBullet, Sprite _bulletImage, int _damage)
    {
        LevelChicken levelChicken = new (_nameChicken, _chickenImage, _gunImage, _levelImage, _goldEarn, _timeDelayEarnGold,_goldUpdate, _nameBullet, _bulletImage, _damage);
        levels.Add(levelChicken);
    }

    public virtual int GetIndexChicken(string name)
    {
        foreach(LevelChicken level in levels)
        {
            if (name == level.nameChicken) return levels.IndexOf(level);
        }
        return -1;
    }
}