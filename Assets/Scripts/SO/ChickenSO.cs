using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObject/Chickens")]
public class ChickenSO : ScriptableObject
{
    [Header("Chicken")]
    public Sprite spriteChicken;

    [Header("Gun")]
    public Sprite spriteGun;

    [Header("Level")]
    public Sprite spriteLevel;

    [Header("Bullet")]
    public string nameBullet = "";
}