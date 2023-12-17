using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : ErshenMonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] protected BulletController bulletController;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadBulletController();
        Reborn();
    }

    protected virtual void LoadBulletController()
    {
        if (bulletController != null) return;
        bulletController = transform.GetComponentInParent<BulletController>();
    }

    protected virtual void Reborn()
    {
        damage = bulletController.BulletSO.damageSender;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "DamageReciver")
        {
            // Do something about damage
            Debug.Log(collision.gameObject.name);
            Spawner.Instance.Despawn(this.transform.parent);
        }
    }
}

