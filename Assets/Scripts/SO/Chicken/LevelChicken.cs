using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelChicken
{
    public string nameChicken;

    public Sprite chickenImage;

    public Sprite gunImage;

    public Sprite levelImage;

    public int goldEarn;

    public int goldUpdate;

    public string nameBullet;

    public Sprite bulletImage;

    public int damage;

    public LevelChicken(string _nameChicken, Sprite _chickenImage, Sprite _gunImage, Sprite _levelImage, int _goldEarn, int _goldUpdate,string _nameBullet, Sprite _bulletImage, int _damage)
    {
        nameChicken = _nameChicken;
        chickenImage = _chickenImage;
        gunImage = _gunImage;
        levelImage = _levelImage;
        goldEarn = _goldEarn;
        goldUpdate = _goldUpdate;
        nameBullet = _nameBullet;
        bulletImage = _bulletImage;
        damage = _damage;
    }
}
