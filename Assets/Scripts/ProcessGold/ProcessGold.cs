using UnityEngine;
using UnityEngine.UI;

public abstract class ProcessGold :ErshenMonoBehaviour
{
    [Header("Process Gold")]
    [SerializeField] protected Text text;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadText();
    }

    protected virtual void LoadText()
    {
        if (text != null) return;
        text = transform.GetComponentInChildren<Text>();
    }

    public virtual void PrintText(float value)
    {
        string printValue = ShortText(value);
        text.text = printValue;
    }

    protected virtual string ShortText(float value)
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
        if (value >= 1000000000000 && value < 1000000000000000)
        {
            return (value / 1000000000000).ToString("n1") + "T";
        }
        return "";
    }
}