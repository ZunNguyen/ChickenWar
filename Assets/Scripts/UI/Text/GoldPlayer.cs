using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldPlayer : ProcessGold
{
    public float gold;

    protected override void LoadText()
    {
        if (text != null) return;
        text = transform.GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        PrintText(gold);
    }
}
