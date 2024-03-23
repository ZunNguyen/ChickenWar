using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextKill : ErshenMonoBehaviour
{
    [SerializeField] protected Text textKillDog;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadTextKillDog();
    }

    protected virtual void LoadTextKillDog()
    {
        if (textKillDog != null) return;
        textKillDog = transform.GetComponentInChildren<Text>();
    }

    public virtual void GetTextKillDog(float numsDog)
    {
        int _numsDog = (int)numsDog;
        textKillDog.text = _numsDog.ToString("d2");
    }
}
