using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class DogAnimation : ErshenMonoBehaviour
{
    [SerializeField] protected Animator anima;
    [SerializeField] protected SpriteRenderer spriteRenderer;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadAnimatior();
        LoadSprite();
    }

    protected virtual void LoadAnimatior()
    {
        if (anima != null) return;
        anima = transform.GetComponent<Animator>();
    }

    protected virtual void LoadSprite()
    {
        if (spriteRenderer != null) return;
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
    }

    public void Dead()
    {
        anima.SetBool("isDead", true);
    }

    public void Attack()
    {
        anima.SetBool("isAttack", true);
    }

    public virtual void ChangeColorRed()
    {
        spriteRenderer.color = new Color(1f, 0.5f, 0.5f, 1f);
        StartCoroutine(ChangeColorNormal());
    }

    IEnumerator ChangeColorNormal()
    {
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = new Color(1f,1f,1f,1f);
    }
}