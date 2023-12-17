using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class ChickenGun : ErshenMonoBehaviour
{
    [SerializeField] protected Image image;
    [SerializeField] protected ChickenController chickenController;
    public string nameBullet;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadImage();
        LoadChickenController();
        Reborn();
    }

    protected virtual void LoadImage()
    {
        if (image != null) return;
        image = transform.GetComponent<Image>();
    }

    protected virtual void LoadChickenController()
    {
        if (chickenController != null) return;
        chickenController = transform.GetComponentInParent<ChickenController>();
    }

    protected virtual void Reborn()
    {
        image.sprite = chickenController.ChickenSO.spriteGun;
        nameBullet = chickenController.ChickenSO.nameBullet;
    }
}