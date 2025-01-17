using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimationGun : ChickenAbstract
{
    [SerializeField] protected Animator anima;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadAnimation();
    }

    protected virtual void LoadAnimation()
    {
        if (anima != null) return;
        anima = transform.GetComponent<Animator>();
    }

    public void SetAnimationOn()
    {
        chickenController.CanvasController.AudioManager.PlaySFX(chickenController.CanvasController.AudioManager.effectShooting);
        anima.SetTrigger("Shooting");
    }
}