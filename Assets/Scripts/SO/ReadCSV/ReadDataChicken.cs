using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ReadDataChicken : ErshenMonoBehaviour
{
    [Header("Connect Script")]
    [SerializeField] protected TextAsset textAssetData;

    [Header("Variable")]
    [SerializeField] protected int length = 9;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadTextAssetData();
        ReadingAssetData();
    }

    protected virtual void LoadTextAssetData()
    {
        string resPath = "SO/Chickens/Data_Chicken";
        textAssetData = Resources.Load<TextAsset>(resPath);
    }

    protected virtual void ReadingAssetData()
    {
        // Take Data
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        int tableSize = data.Length / length - 1;

        ProcessData(data, tableSize);
    }

    protected virtual void ProcessData(string[] data, int tableSize)
    {
        for (int i = 0; i < tableSize; i++)
        {
            // Take value
            string nameChicken = data[length * (i + 1)];

            string chickenImage = data[length * (i + 1) + 1];
            Sprite chickenSprite = GetImage("Characters/Chickens and Guns/" + chickenImage);
            
            string gunImage = data[length * (i + 1) + 2];
            Sprite gunSprite = GetImage("Characters/Chickens and Guns/" + gunImage);

            string levelImage = data[length * (i + 1) + 3];
            Sprite levelSprite = GetImage("Characters/Level/" + levelImage);

            int goldEarn = int.Parse(data[length * (i + 1) + 4]);

            int goldUpdate = int.Parse(data[length * (i + 1) + 5]);

            string nameBullet = data[length * (i + 1) + 6];
            
            string bulletImage = data[length * (i + 1) + 7];
            Sprite bulletSprite = GetImage("Bullets/" + bulletImage);

            int damage = int.Parse(data[length * (i + 1) + 8]);

            // Creat data
            ChickenSO.Instance.CreatNewLevelChicken(nameChicken, chickenSprite, gunSprite, levelSprite, goldEarn, goldUpdate, nameBullet, bulletSprite, damage);
        }
    }

    protected virtual Sprite GetImage(string path)
    {
        string spritePath = "Assets/Asset/PNG/" + path;
        Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spritePath);
        return sprite;
    }
}
