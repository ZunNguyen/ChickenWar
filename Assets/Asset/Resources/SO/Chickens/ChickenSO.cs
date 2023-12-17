using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObject/Chickens")]
public class ChickenSO : ScriptableObject
{
    //[Header("Chicken")]
    //public string chickenName = "";

    [Header("Gun")]
    //public string chickenGun = "";
    public Sprite spriteGun;

    [Header("Bullet")]
    public string nameBullet = "";
    //public int damgeSender = 0;
    //public Sprite spriteBullet;
}
