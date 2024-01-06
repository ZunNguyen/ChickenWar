using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelChicken
{
    [Header("Name Chicken")]
    public string name;

    [Header("Name Bullet")]
    public string nameBullet = "Bullet01";

    [Header("Chicken Image")]
    public Sprite spriteChicken;

    [Header("Gun Image")]
    public Sprite spriteGun;

    [Header("Level Image")]
    public Sprite spriteLevel;
}
