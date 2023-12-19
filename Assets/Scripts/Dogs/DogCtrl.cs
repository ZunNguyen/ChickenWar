using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCtrl : ErshenMonoBehaviour
{
    [SerializeField] protected DogMovement dogMovement;
    public DogMovement DogMovement { get => dogMovement; }

    [SerializeField] protected DogDespawn dogDespawn;
    public DogDespawn DogDespawn { get => dogDespawn; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadDogDespawn();
        LoadDogMovement();
    }

    protected virtual void LoadDogMovement()
    {
        if (dogMovement != null) return;
        dogMovement = transform.GetComponentInChildren<DogMovement>();
    }

    protected virtual void LoadDogDespawn()
    {
        if (dogDespawn != null) return;
        dogDespawn = transform.GetComponentInChildren<DogDespawn>();
    }
}
