using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TWTextSpawner : Spawner
{
    public virtual void SpawnText(Vector3 pos, Quaternion rot, string text)
    {
        GameObject newPrefab = Spawn("TW Text", pos, rot);
        TWText twText = newPrefab.GetComponent<TWText>();
        twText.TWTextOn(text);
        newPrefab.SetActive(true);
    }
}
