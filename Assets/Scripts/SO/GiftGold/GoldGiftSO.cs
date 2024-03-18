using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GoldGiftSO", menuName = "ScriptableObject/GoldGift")]
public class GoldGiftSO : ScriptableObject
{
    public List<GoldGift> listGoldGift;
}
