using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldShake : ErshenMonoBehaviour
{
    [SerializeField] protected Animator animator;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadAniamtion();
    }

    protected virtual void LoadAniamtion()
    {
        if (animator != null) return;
        animator = transform.GetComponent<Animator>();
    }

    public virtual void Animating()
    {
        animator.SetBool("isShaking", true);

        // Audio
        CanvasController.Instance.AudioManager.PlaySFX(CanvasController.Instance.AudioManager.effectShieldCollision);
    }

    protected virtual void SetFalseShaking()
    {
        animator.SetBool("isShaking", false);
    }
}
