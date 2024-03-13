using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TWUpgradeChicken : CanvasAbstract
{
    [SerializeField] protected GameObject chicken_1;
    [SerializeField] protected GameObject chicken_2;
    [SerializeField] protected GameObject chickenUpgrade;
    [SerializeField] protected GameObject fireWork;

    public int indexLVHighest = 1;

    public virtual void TW_UpgradeOn()
    {
        chicken_2.GetComponent<RectTransform>().DOAnchorPosX(0f, 2f);
        chicken_1.GetComponent<RectTransform>().DOAnchorPosX(0f, 2f).OnComplete(() =>
        {
            canvasController.ChickenSpawner.Despawn(chicken_1.transform);
            canvasController.ChickenSpawner.Despawn(chicken_2.transform);
            chickenUpgrade.SetActive(true);
            fireWork.SetActive(true);
        });
    }

    public virtual void TW_UpgradeOff()
    {
        canvasController.ChickenSpawner.Despawn(chickenUpgrade.transform);
        gameObject.SetActive(false);
        fireWork.SetActive(false);
    }

    public void ProcessShowUpgradePanel(int indexLV, Transform oldChicken, Transform newChicken)
    {
        if (indexLV < indexLVHighest) return;

        indexLVHighest += 1;
        gameObject.SetActive(true);
        
        chicken_1 = SpawnChicken(oldChicken,300).gameObject;
        chicken_2 = SpawnChicken(oldChicken,-300).gameObject;
        chickenUpgrade = SpawnChicken(newChicken,0).gameObject;
        chickenUpgrade.SetActive(false);

        TW_UpgradeOn();
    }

    protected virtual Transform SpawnChicken(Transform chicken, int rectX)
    {
        Transform newPrefab = canvasController.ChickenSpawner.Spawn(chicken, transform.position, transform.rotation);
        newPrefab.SetParent(transform);
        newPrefab.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
        newPrefab.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
        newPrefab.GetComponent<RectTransform>().DOAnchorPos(new Vector2(rectX, 80), 0);
        newPrefab.gameObject.SetActive(true);
        return newPrefab;
    }
}
