using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GoldGiftSO", menuName = "ScriptableObject/GoldGift")]
public class GoldGiftSO : ScriptableObject
{
    [Header("Load Instance")]
    protected static GoldGiftSO instance;
    public static GoldGiftSO Instance => instance;

    public List<GoldGift> listGoldGift;

    private void Reset()
    {
        LoadInstance();
    }

    protected virtual void LoadInstance()
    {
        if (instance != null) return;
        instance = this;
    }

    public virtual void CreatNewGoldGift(int _wave, float _gold)
    {
        GoldGift goldGift = new (_wave, _gold);
        listGoldGift.Add(goldGift);
    }
}
