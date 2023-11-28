using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : ErshenMonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected Rigidbody2D rb;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigibody2D();
    }

    protected virtual void LoadRigibody2D()
    {
        if (rb != null) return;
        rb = GameObject.Find("Prefabs").transform.Find("Bullets2").GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    protected virtual void Movement()
    {
        rb.velocity = transform.right * speed;
    }
}
