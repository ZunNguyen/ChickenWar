using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class UpdateChickenSpawn : ErshenMonoBehaviour
{
    [SerializeField] protected TMP_Text text;
    [SerializeField] protected int levelSpawnChicken = 1;
    [SerializeField] public string nameChicken = "Chicken01";

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadText();
    }

    protected virtual void LoadText()
    {
        if (text != null) return;
        text = transform.GetComponent<TMP_Text>();
    }

    public virtual void GetLevelChickenToSpawn(int levelChicken)
    {
        if (levelChicken >= 4)
        {
            int level = levelChicken - 3;
            UpdateNameChickenSpawn(level);
        }
    }

    protected virtual void UpdateNameChickenSpawn(int levelChicken)
    {
        if (levelSpawnChicken > levelChicken) return;
        levelSpawnChicken = levelChicken;
        nameChicken = "Chicken0" + levelChicken.ToString();
        text.text = nameChicken;
        Debug.Log(nameChicken);
    }
}