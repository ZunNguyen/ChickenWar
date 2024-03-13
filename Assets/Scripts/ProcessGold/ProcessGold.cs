using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
using System;

public abstract class ProcessGold :ErshenMonoBehaviour
{
    [Header("Process Gold")]
    [SerializeField] protected TMP_Text text;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadText();
    }

    protected virtual void LoadText()
    {
        if (text != null) return;
        text = transform.GetComponentInChildren<TMP_Text>();
    }

    protected virtual void PrintText(Int32 value)
    {
        string printValue = ShortText(value);
        text.text = printValue;
    }

    protected virtual string ShortText(Int64 value)
    {
        if (value < 1000)
        {
            return value.ToString();
        }
        if (value >= 1000 && value < 1000000)
        {
            return (value / 1000).ToString("n1") + "K";
        }
        if (value >= 1000000 && value < 1000000000)
        {
            return (value / 1000000).ToString("n1") + "M";
        }
        if (value >= 1000000000 && value < 1000000000000)
        {
            return (value / 1000000000).ToString("n1") + "B";
        }
        return "";
    }
}