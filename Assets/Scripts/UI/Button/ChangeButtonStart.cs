using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonStart : CanvasAbstract
{
    [Header("Connect InSide")]
    [SerializeField] protected Text text;
    [SerializeField] protected GameObject imageChicken;
    [SerializeField] protected GameObject imageClock;


    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadText();
        LoadImageChicken();
        LoadClock();
    }

    protected virtual void LoadText()
    {
        if (text != null) return;
        text = transform.GetComponentInChildren<Text>();
    }

    protected virtual void LoadImageChicken()
    {
        if (imageChicken != null) return;
        imageChicken = GameObject.Find("Image - Chicken");
    }

    protected virtual void LoadClock()
    {
        if (imageClock != null) return;
        imageClock = transform.Find("Image - Clock").gameObject;
    }

    public virtual void ChangeImageButtonStart()
    {
        text.text = "BATTLE";
        imageChicken.SetActive(true);
        imageClock.SetActive(false);
    }

    public virtual void ChangeImageButtonXTime(int _timeScale, int _timeText)
    {
        Time.timeScale = _timeScale;
        text.text = "Time " + "X" + _timeText;
        if (!imageClock.activeSelf) imageClock.SetActive(true);
        if (imageChicken.activeSelf) imageChicken.SetActive(false);
    }
}