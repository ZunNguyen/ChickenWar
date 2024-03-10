using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ShieldHPSum : ErshenMonoBehaviour
{
    [Header("Connect Script")]
    [SerializeField] protected CanvasController canvasController;

    [SerializeField] protected List<Transform> shields;

    [Header("Variable")]
    public int sumHpMax = 100;
    [SerializeField] protected int sumHpCurrent;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadListShields();
        LoadCanvasController();
    }

    protected virtual void LoadCanvasController()
    {
        if (canvasController != null) return;
        canvasController = GameObject.Find("Canvas").GetComponent<CanvasController>();
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
        canvasController.ShieldHPBar.ChangeSlider(sumHpCurrent, sumHpMax);
        canvasController.ShieldHPText.Print(sumHpCurrent, sumHpMax);
    }

    // Load Hp Max
    protected virtual int LoadHpMax()
    {
        int levelCurrent = canvasController.ShieldUpdate.levelCurrent;
        int HpMax = canvasController.ShieldUpdate.shieldSO.levels[levelCurrent].hp;
        return HpMax;
    }
}