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
        if (objTarget.gameObject.activeSelf == false)
        {
            transform.parent.Translate(speed * Time.fixedDeltaTime * Vector3.right);
        }
        if (objTarget.gameObject.activeSelf == true) transform.parent.position = Vector2.MoveTowards(transform.position, objTarget.position, speed * Time.fixedDeltaTime);
    }
}