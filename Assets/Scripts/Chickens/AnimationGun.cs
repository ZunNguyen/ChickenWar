using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimationGun : ErshenMonoBehaviour
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
        anima.SetTrigger("Shooting");
    }
}
