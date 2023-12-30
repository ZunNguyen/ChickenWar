using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChickenController : ErshenMonoBehaviour
{
    [SerializeField] protected Image imageGun;
    [SerializeField] protected Image imageChicken;
    [SerializeField] protected Image imageLevel;
    [SerializeField] protected ChickenSO chickenSO;
    public ChickenSO ChickenSO => chickenSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadChickenSO();
        LoadImageGun();
        LoadImageChicken();
        LoadImageLevel();
        LoadImageToObj();
    }

    protected virtual void LoadChickenSO()
    {
        if (chickenSO != null) return;
        string resPath = "SO/Chickens/" + this.transform.name;
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

    protected virtual void LoadImageToObj()
    {
        imageChicken.sprite = chickenSO.spriteChicken;
        imageGun.sprite = chickenSO.spriteGun;
        imageLevel.sprite = chickenSO.spriteLevel;
    }
}
