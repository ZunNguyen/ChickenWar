using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DogAnimation : ErshenMonoBehaviour
{
    [SerializeField] protected Animator anima;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadAnimatior();
    }

    protected virtual void LoadAnimatior()
    {
        if (anima != null) return;
        anima = transform.GetComponent<Animator>();
    }

    public void Dead()
    {
        anima.SetBool("isDead", true);
    }

    public void Attack()
    {
        anima.SetBool("isAttack", true);
    }
}