using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPanel : ErshenMonoBehaviour
{
    [SerializeField] protected TMP_Text textPanel;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadTextWaveDog();
    }

    protected virtual void LoadTextWaveDog()
    {
        if (textPanel != null) return;
        textPanel = transform.GetComponent<TMP_Text>();
    }

    public virtual void InputTextVictory(float wave)
    {
        textPanel.text = "Wave " + wave.ToString() + " Clear";
    }

    public virtual void InputTextLose()
    {
        textPanel.text = "Try Again";
    }
}
