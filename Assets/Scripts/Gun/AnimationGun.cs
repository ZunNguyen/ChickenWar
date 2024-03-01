using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimationGun : ErshenMonoBehaviour
{
    [SerializeField] protected Animator anima;
    [SerializeField] protected CanvasController canvasController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadAnimation();
        LoadCanvasController();
    }

    protected virtual void LoadAnimation()
    {
        if (anima != null) return;
        anima = transform.GetComponent<Animator>();
    }

    protected virtual void LoadCanvasController()
    {
        if (canvasController != null) return;
        canvasController = transform.GetComponentInParent<CanvasController>();
    }

    public void SetAnimationOn()
    {
        anima.SetTrigger("Shooting");
    }

    //protected virtual void SpawnBullet()
    //{
    //    canvasController.PointSpawnBulletController.PointSpawnBullet.SpawnBulletByTime();
    //}
}