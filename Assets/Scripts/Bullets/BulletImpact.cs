using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : BulletAbstract
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bullet Damage Sender") return;
        if (collision.gameObject.name == "Shield Damage Reciver") return;
        bulletCtrl.BulletDamSender.Send(collision.transform);
    }
}