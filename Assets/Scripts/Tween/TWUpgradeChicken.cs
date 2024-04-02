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
    [SerializeField] protected bool tw_UpgradeOff_On = false;

    public int indexLVHighest = 0;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadFireWork();
    }

    protected virtual void LoadFireWork()
    {
        if (fireWork != null) return;
        fireWork = transform.Find("Image - Fire").gameObject;
    }

    public virtual void TW_UpgradeOn()
    {
        // Audio
        canvasController.AudioManager.PlaySFX(canvasController.AudioManager.effectUpgradeNewChickenHigher);
        
        chicken_2.GetComponent<RectTransform>().DOAnchorPosX(0f, 1.5f);
        chicken_1.GetComponent<RectTransform>().DOAnchorPosX(0f, 1.5f).OnComplete(() =>
        {
            canvasController.ChickenSpawner.Despawn(chicken_1.transform);
            canvasController.ChickenSpawner.Despawn(chicken_2.transform);
            if (tw_UpgradeOff_On) return;
            chickenUpgrade.SetActive(true);
            fireWork.SetActive(true);
        });
    }

    public virtual void TW_UpgradeOff()
    {
        tw_UpgradeOff_On = true;
        canvasController.ChickenSpawner.Despawn(chickenUpgrade.transform);
        fireWork.SetActive(false);
        gameObject.SetActive(false);
    }

    public void ProcessShowUpgradePanel(int indexLV, Transform oldChicken, Transform newChicken)
    {
        tw_UpgradeOff_On = false;

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
        newPrefab.GetComponent<RectTransform>().DOAnchorPos(new Vector2(rectX, 0), 0);
        newPrefab.gameObject.SetActive(true);
        DragItem dragItem = newPrefab.GetComponent<DragItem>();
        dragItem.enabled = false;
        return newPrefab;
    }
}
