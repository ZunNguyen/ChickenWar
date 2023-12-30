using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCtrl : ErshenMonoBehaviour
{
    [SerializeField] protected DogMovement dogMovement;
    public DogMovement DogMovement => dogMovement;

    [SerializeField] protected DogDespawn dogDespawn;
    public DogDespawn DogDespawn => dogDespawn;

    [SerializeField] protected DogAnimation dogAniamtion;
    public DogAnimation DogAniamtion => dogAniamtion;

    [SerializeField] protected DogDamageReceiver dogDamageReceiver;
    public DogDamageReceiver DogDamageReceiver => dogDamageReceiver;

    [SerializeField] protected DogDamageSender dogDamageSender;
    public DogDamageSender DogDamageSender => dogDamageSender;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadDogDespawn();
        LoadDogMovement();
        LoadDogAnimation();
        LoadDogDamageReceiver();
        LoadDogDamageSender();
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

    protected virtual void LoadDogAnimation()
    {
        if (dogAniamtion != null) return;
        dogAniamtion = transform.GetComponentInChildren<DogAnimation>();
    }

    protected virtual void LoadDogDamageReceiver()
    {
        if (dogDamageReceiver != null) return;
        dogDamageReceiver = transform.GetComponentInChildren<DogDamageReceiver>();
    }

    protected virtual void LoadDogDamageSender()
    {
        if (dogDamageSender != null) return;
        dogDamageSender = transform.GetComponentInChildren<DogDamageSender>();
    }
}