using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : ErshenMonoBehaviour
{
    [SerializeField] protected float speed;

    private void FixedUpdate()
    {
        this.Walking();
    }

    protected virtual void Walking()
    {
        transform.parent.Translate(speed * Time.fixedDeltaTime * Vector3.left);
    }
}
