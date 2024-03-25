using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LoadIndexObj : ErshenMonoBehaviour
{
    [Header("---Index---")]
    public int index;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadIndex();
    }

    protected virtual void LoadIndex()
    {
        if (index > 0) return;
        string name = gameObject.name;
        index = name[name.Length - 1];
        index -= 48;
    }
}