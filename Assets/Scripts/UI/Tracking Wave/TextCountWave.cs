using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCountWave : ErshenMonoBehaviour
{
    [SerializeField] protected Text text;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadText();
    }

    protected virtual void LoadText()
    {
        if (text != null) return;
        text = transform.GetComponent<Text>();
    }

    public virtual void ChangeText(int indexWave)
    {
        text.text = "Wave " + indexWave.ToString();
    }
}