using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPanel : ErshenMonoBehaviour
{
    [SerializeField] protected Text textPanel;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadTextWaveDog();
    }

    protected virtual void LoadTextWaveDog()
    {
        if (textPanel != null) return;
        textPanel = transform.GetComponent<Text>();
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
