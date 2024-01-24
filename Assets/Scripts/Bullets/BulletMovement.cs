using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : ErshenMonoBehaviour
{
    [SerializeField] protected float speed;
    public Transform objTarget;

    private void FixedUpdate()
    {
        Movement();
    }

    protected virtual void Movement()
    {
        if (objTarget == null) transform.parent.Translate(Vector3.right * Time.fixedDeltaTime * speed); ;
        transform.parent.position = Vector2.MoveTowards(transform.position, objTarget.position, speed * Time.fixedDeltaTime);
    }
}