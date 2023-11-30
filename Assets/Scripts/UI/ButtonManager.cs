using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : ErshenMonoBehaviour
{
    [SerializeField] protected DogController dogController;
    [SerializeField] protected static ButtonManager instance;
    public static ButtonManager Instance { get => instance; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadDogController();
        LoadInstance();
    }

    protected virtual void LoadDogController()
    {
        if (dogController != null) return;
        dogController = GameObject.Find("Dog01").GetComponent<DogController>();
    }

    protected virtual void LoadInstance()
    {
        if (instance != null) return;
        ButtonManager.instance = this;
    }

    public virtual void StartMovementDog()
    {
        dogController.DogMovement.enabled = true;
    }
}
