using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shield", menuName = "ScriptableObject/Shield")]
public class ShieldSO : ScriptableObject
{
    public List<LevelShield> levels;
}