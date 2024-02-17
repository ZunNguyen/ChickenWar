using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveDog", menuName = "ScriptableObject/WaveDog")]
public class WaveDogSO : ScriptableObject
{
    public List<Wave> waves;
}
