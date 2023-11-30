using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : ErshenMonoBehaviour
{
    [SerializeField] protected DogMovement dogMovement;
    public DogMovement DogMovement { get => dogMovement; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadDogMovement();
    }

    protected virtual void LoadDogMovement()
    {
        if (dogMovement != null) return;
        dogMovement = transform.GetComponentInChildren<DogMovement>();
    }
}
