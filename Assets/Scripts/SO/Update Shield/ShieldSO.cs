using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shield", menuName = "ScriptableObject/Shield")]
public class ShieldSO : ScriptableObject
{
    [Header("---Load Instance---")]
    protected static ShieldSO instance;
    public static ShieldSO Instance => instance;

    public List<LevelShield> listLevelShields;

    private void Reset()
    {
        LoadInstance();
    }

    protected virtual void LoadInstance()
    {
        if (instance != null) return;
        instance = this;
    }

    public virtual void CreatNewLevelShield(float _gold, int _hp)
    {
        LevelShield levelShield = new (_gold, _hp);
        listLevelShields.Add(levelShield);
    }
}