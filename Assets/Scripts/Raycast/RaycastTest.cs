using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : ErshenMonoBehaviour
{
    [Header("Connect script")]
    [SerializeField] protected List<PointSpawnBullet> listPointSpawnBullet;

    [Header("Value")]
    [SerializeField] protected float rayLength = 13f;
    [SerializeField] protected LayerMask layer;
    [SerializeField] protected int indexPointSpawnBullet;

    [Header("Dog information")]
    [SerializeField] protected int indexPointSpawnDog;
    public Transform dogTransf;

    protected override void LoadComponent()
    {
        base.LoadComponent();
    }

    protected virtual void LoadIndex(PointSpawnBullet pointSpawnBullet)
    {
        if (indexPointSpawnBullet > 0) return;
        string pointSpawn = pointSpawnBullet.gameObject.name;
        indexPointSpawnBullet = pointSpawn[pointSpawn.Length - 1];
        indexPointSpawnBullet -= 48;
    }

    private void Update()
    {
        RaycastProcess();
    }

    protected virtual void RaycastProcess()
    {
        Debug.DrawRay(transform.position, transform.right * rayLength, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, rayLength, layer);
        if (hit)
        {
            CheckDogStatus();
            if (hit.collider.name == "Dog Damage Receiver" && dogTransf == null)
            {
                DogDamageReceiver dogDamageReceiver = hit.transform.GetComponent<DogDamageReceiver>();
                dogTransf = dogDamageReceiver.transform;
                foreach (PointSpawnBullet pointSpawnBullet in listPointSpawnBullet)
                {
                    pointSpawnBullet.listDog.Add(dogTransf);
                }
                indexPointSpawnDog = dogDamageReceiver.DogCtrl.DogIndex.indexDog;
            }
        }
        if (!hit)
        {
            dogTransf = null;
            
        }
    }

    protected virtual void CheckDogStatus()
    {
        if (dogTransf == null) return;
        if (dogTransf.gameObject.activeSelf == false) dogTransf = null;
    }
}