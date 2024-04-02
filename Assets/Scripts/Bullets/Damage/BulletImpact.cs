using UnityEngine;

public class BulletImpact : BulletAbstract
{
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bullet Damage Sender") return;
        if (collision.gameObject.name == "Shield Damage Reciver") return;
        if (collision.gameObject.name == "Block Wall") bulletCtrl.BulletDespawn.DespawnObj();

        if (collision.gameObject.name == "Dog Damage Receiver")
        {
            DogAnimation dogAnimation = collision.transform.parent.GetComponent<DogAnimation>();
            dogAnimation.ChangeColorRed();
            bulletCtrl.BulletDamSender.Send(collision.transform);
            GameObject newObj = GameObjectSpawner.Instance.Spawn("Bullet Effect", this.transform.position, this.transform.rotation);
            newObj.SetActive(true);
            EffectDespawn effectDespawn = newObj.GetComponent<EffectDespawn>();
            effectDespawn.DespawnEffect();
        }
    }
}