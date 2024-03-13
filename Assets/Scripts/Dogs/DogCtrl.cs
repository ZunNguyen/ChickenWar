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

    [SerializeField] protected Transform canvasHP;
    public Transform CanvasHP => canvasHP;

    [SerializeField] protected DogIndex dogIndex;
    public DogIndex DogIndex => dogIndex;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadDogDespawn();
        LoadDogMovement();
        LoadDogAnimation();
        LoadDogDamageReceiver();
        LoadDogDamageSender();
        LoadCanvasHP();
        LoadDogIndex();
    }

    protected virtual void LoadDogMovement()
    {
        if (dogMovement != null) return;
        dogMovement = transform.Find("DogMovement").GetComponent<DogMovement>();
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
        dogDamageReceiver = transform.Find("Animation").transform.Find("Dog Damage Receiver").GetComponent<DogDamageReceiver>();
    }

    protected virtual void LoadDogDamageSender()
    {
        if (dogDamageSender != null) return;
        dogDamageSender = transform.GetComponentInChildren<DogDamageSender>();
    }

    protected virtual void LoadCanvasHP()
    {
        if (canvasHP != null) return;
        canvasHP = transform.Find("CanvasHP");
    }

    protected virtual void LoadDogIndex()
    {
        if (dogIndex != null) return;
        dogIndex = transform.GetComponentInChildren<DogIndex>();
    }

    // DisableComponents
    public virtual void DisaleComponents()
    {
        // Off Hp canvas
        canvasHP.gameObject.SetActive(false);
        // Disable obj movement
        dogMovement.gameObject.SetActive(false);
        // Disable obj damage recieve
        DogDamageReceiver.gameObject.SetActive(false);
    }

    // EnableComponents
    public virtual void EnableComponent()
    {
        // On Hp canvas
        canvasHP.gameObject.SetActive(true);
        // Enable obj movement
        dogMovement.gameObject.SetActive(true);
        // Enable obj damage recieve
        DogDamageReceiver.gameObject.SetActive(true);
    }
}