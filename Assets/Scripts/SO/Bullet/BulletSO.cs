using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObject/Bullet")]

public class BulletSO : ScriptableObject
{
    public List<LevelBullet> levels;
}
