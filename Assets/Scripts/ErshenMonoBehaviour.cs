using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErshenMonoBehaviour : MonoBehaviour
{
    protected void Awake()
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

    protected virtual void ResetValue()
    {
        // For override
    }

    protected virtual void OnEnable()
    {
        // For override
    }

    protected virtual void OnDisable()
    {
        // For override
    }
}
