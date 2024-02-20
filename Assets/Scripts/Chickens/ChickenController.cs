using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChickenController : ErshenMonoBehaviour
{
    [Header("Connect Script")]
    [SerializeField] protected ChickenSO chickenSO;
    public ChickenSO ChickenSO => chickenSO;
    [SerializeField] protected GoldEarn goldEarn;
    public GoldEarn GoldEarn => goldEarn;

    [SerializeField] protected Image imageGun;
    [SerializeField] protected Image imageChicken;
    [SerializeField] protected Image imageLevel;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadChickenSO();
        LoadImageGun();
        LoadImageChicken();
        LoadImageLevel();
        LoadGoldEarn();
        LoadImageToObj();
    }

    protected virtual void LoadChickenSO()
    {
        if (chickenSO != null) return;
        string resPath = "SO/Chickens/Chickens";
        chickenSO = Resources.Load<ChickenSO>(resPath);
    }

    protected virtual void LoadImageGun()
    {
        if (imageGun != null) return;
        imageGun = this.transform.Find("Chicken - Gun").GetComponent<Image>();
    }

    protected virtual void LoadImageChicken()
    {
        if (imageChicken != null) return;
        imageChicken = this.transform.Find("Chicken - Anchor").GetComponentInChildren<Image>();
    }

    protected virtual void LoadImageLevel()
    {
        if (imageLevel != null) return;
        imageLevel = this.transform.Find("Level").GetComponent<Image>();
    }

    protected virtual void LoadGoldEarn()
    {
        if (goldEarn != null) return;
        goldEarn = this.transform.Find("Gold").GetComponent<GoldEarn>();
    }

    protected virtual void LoadImageToObj()
    {
        int indexChicken = chickenSO.GetIndexChicken(gameObject.name);
        imageChicken.sprite = chickenSO.levels[indexChicken].spriteChicken;
        imageGun.sprite = chickenSO.levels[indexChicken].spriteGun;
        imageLevel.sprite = chickenSO.levels[indexChicken].spriteLevel;
        goldEarn.gold = chickenSO.levels[indexChicken].gold;
    }
}
