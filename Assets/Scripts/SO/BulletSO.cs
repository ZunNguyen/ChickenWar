using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObject/Bullet")]

public class BulletSO : ScriptableObject
{
    [Header("Bullet")]
    public int damageSender;
    public Sprite bulletSprite;
}
