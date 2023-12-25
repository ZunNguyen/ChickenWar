using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class TextGold : ErshenMonoBehaviour
{
    [SerializeField] protected TMP_Text text;
    [SerializeField] protected float gold;

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

    private void FixedUpdate()
    {

        ShortCutGold(gold);
    }

    protected virtual void ShortCutGold(float gold)
    {
        if (gold < 1000)
        {
            PrintText(gold.ToString());
        }
        if (gold >= 1000 && gold < 1000000)
        {
            string printGold = (gold / 1000).ToString("n2");
            GetPrintGold(printGold, "K");
        }
        if (gold >= 1000000 && gold < 1000000000)
        {
            string printGold = (gold / 1000000).ToString("n2");
            GetPrintGold(printGold, "M");
        }
    }

    protected virtual void GetPrintGold(string printGold, string character)
    {
        
        printGold = printGold.Replace(".", character);
        PrintText(printGold);
    }

    protected virtual void PrintText(string printWant)
    {
        text.text = printWant;
    }
}