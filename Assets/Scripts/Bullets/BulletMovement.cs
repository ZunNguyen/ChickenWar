using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : ErshenMonoBehaviour
{
    [SerializeField] protected float speed;

    private void FixedUpdate()
    {
        Movement();
    }

    protected virtual void Movement()
    {
        transform.parent.Translate(Vector3.right * Time.fixedDeltaTime * speed);
    }
}
