using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ProcessSlider : ErshenMonoBehaviour
{
    [Header("Get Component")]
    [SerializeField] protected Slider slider;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadSlider();
    }

    protected virtual void LoadSlider()
    {
        if (slider != null) return;
        slider = transform.GetComponent<Slider>();
    }
}
