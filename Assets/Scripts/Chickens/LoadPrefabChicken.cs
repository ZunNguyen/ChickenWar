using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class LoadPrefabChicken : MonoBehaviour
{
    [SerializeField] protected ChickenSO chickenSO;
    [SerializeField] protected GameObject chicken;

    private void Reset()
    {
        LoadChickenSO();
        LoadChicken();
        CreatNewGameObj();
    }

    protected virtual void LoadChickenSO()
    {
        if (chickenSO != null) return;
        string resPath = "SO/Chickens/Chickens";
        chickenSO = Resources.Load<ChickenSO>(resPath);
    }

    protected virtual void LoadChicken()
    {
        if (chicken != null) return;
        string objPath = "Prefabs/Chickens/Chicken";
        chicken = Resources.Load<GameObject>(objPath);
    }

    protected virtual void CreatNewGameObj()
    {
        for (int i = 1; i <= 40; i++)
        {
            GameObject newObj = Instantiate(chicken);
            newObj.transform.parent = this.transform;
            newObj.name = "Chicken" + i.ToString("D2");
            GetImageChicken(newObj, i-1);
            GetImageGun(newObj, i - 1);
            GetNameBullet(newObj, i - 1);
            GetImageLevel(newObj, i - 1);
            GetEarnGold(newObj, i - 1);
        }
    }

    protected virtual void GetImageChicken(GameObject chicken, int index)
    {
        Image imageChicken = chicken.transform.Find("Chicken - Anchor").GetComponentInChildren<Image>();
        imageChicken.sprite = chickenSO.levels[index].chickenImage;
    }

    protected virtual void GetImageGun(GameObject chicken, int index)
    {
        Image imageGun = chicken.transform.Find("Chicken - Gun").GetComponent<Image>();
        imageGun.sprite = chickenSO.levels[index].gunImage;
    }

    // Get name bullet and damage
    protected virtual void GetNameBullet(GameObject chicken, int index)
    {
        ChickenGun chickenGun = chicken.transform.Find("Chicken - Gun").GetComponent<ChickenGun>();
        chickenGun.nameBullet = chickenSO.levels[index].nameBullet;
        chickenGun.damage = chickenSO.levels[index].damage;
    }

    protected virtual void GetImageLevel(GameObject chicken, int index)
    {
        Image imagLevel = chicken.transform.Find("Level").GetComponent<Image>();
        imagLevel.sprite = chickenSO.levels[index].levelImage;
    }

    protected virtual void GetEarnGold(GameObject chicken, int index)
    {
        GoldEarn goldEarn = chicken.transform.Find("Gold").GetComponent<GoldEarn>();
        goldEarn.gold = chickenSO.levels[index].goldEarn;
    }
}