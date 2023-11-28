using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErshenMonoBehaviour : MonoBehaviour
{
    protected void Start()
    {
        this.LoadComponent();
    }

    protected void Reset()
    {
        this.LoadComponent();
    }

    protected virtual void LoadComponent()
    {
        // For override
    }
}
