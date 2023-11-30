using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : ErshenMonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "DamageReciver")
        {
            Debug.Log(collision.gameObject.name);
            Spawner.Instance.Despawn(this.transform.parent);
        }
    }

}
