using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ShieldHPSum : ErshenMonoBehaviour
{
    [SerializeField] protected List<Transform> shields;

    [Header("Variable")]
    public int sumHpMax = 100;
    public int sum = 0;
    [SerializeField] protected int sumHpCurrent;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadListShields();
    }

    protected virtual void LoadListShields()
    {
        if (shields.Count > 0) return;
        foreach (Transform shield in this.transform)
        {
            shields.Add(shield);
        }
    }

    public virtual void LoadSumHpCurrent()
    {
        sumHpMax = LoadHpMax();
        sumHpCurrent = sumHpMax;
        int sum = 0;
        foreach (Transform shield in shields)
        {
            ShieldDamageReciever shieldDamageReciever = shield.GetComponentInChildren<ShieldDamageReciever>();
            int tem = shieldDamageReciever.hpMax - shieldDamageReciever.hpCurrent;
            sum += tem;
        }
        sumHpCurrent -= sum;
        CanvasController.Instance.ShieldUpdateController.ShieldHPBar.ChangeSlider(sumHpCurrent, sumHpMax);
        CanvasController.Instance.ShieldUpdateController.ShieldHPText.Print(sumHpCurrent, sumHpMax);
    }

    // Load Hp Max
    protected virtual int LoadHpMax()
    {
        int levelCurrent = CanvasController.Instance.ShieldUpdate.levelCurrent;
        int HpMax = CanvasController.Instance.ShieldUpdate.shieldSO.levels[levelCurrent].hp;
        return HpMax;
    }
}