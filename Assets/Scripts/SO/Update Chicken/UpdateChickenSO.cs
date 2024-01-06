using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpdateChickenSO", menuName = "ScriptableObject/UpdateChicken")]
public class UpdateChickenSO : ScriptableObject
{
    public List<UpdateChickenLevel> levels;
}
