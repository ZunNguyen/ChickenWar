using UnityEngine;

public class ButtonArange : CanvasAbstract
{
    [SerializeField] protected Transform btnBattle;
    [SerializeField] protected Transform btnUpgradeShield;
    [SerializeField] protected Transform btnSpawnChicken;
    [SerializeField] protected Transform btnMission;
    [SerializeField] protected Transform btnDelete;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadBtnBattle();
        LoadBtnUpgradeShield();
        LoadBtnSpawnChicken();
        LoadBtnMission();
        LoadBtnDelete();
    }

    protected virtual void LoadBtnBattle()
    {
        if (btnBattle != null) return;
        btnBattle = transform.Find("Button - Battle");
    }

    protected virtual void LoadBtnUpgradeShield()
    {
        if (btnUpgradeShield != null) return;
        btnUpgradeShield = transform.Find("Button - Update Shield");
    }

    protected virtual void LoadBtnSpawnChicken()
    {
        if (btnSpawnChicken != null) return;
        btnSpawnChicken = transform.Find("Button - Spawn");
    }

    protected virtual void LoadBtnMission()
    {
        if (btnMission != null) return;
        btnMission = transform.Find("Button - Mission");
    }

    protected virtual void LoadBtnDelete()
    {
        if (btnDelete != null) return;
        btnDelete = transform.Find("Button - Delete");
    }

    protected virtual void LoadPosBtn()
    {
        ProcessArangeBtn();
    }

    private void Start()
    {
        LoadPosBtn();
    }

    protected virtual void ProcessArangeBtn()
    {
        RectTransform rectCanvas = canvasController.GetComponent<RectTransform>();
        RectTransform rectBtnDelete = btnDelete.GetComponent<RectTransform>();
        RectTransform rectBtnBattle = btnBattle.GetComponent<RectTransform>();
        RectTransform rectBtnMission = btnMission.GetComponent<RectTransform>();
        RectTransform rectBtnChickenSpawn = btnSpawnChicken.GetComponent<RectTransform>();
        RectTransform rectBtnUpgradeShield = btnUpgradeShield.GetComponent<RectTransform>();

        float widthRectCanvas = rectCanvas.sizeDelta.x;        
        float widthRectCanvasNew = widthRectCanvas - 2 * 100 - rectBtnDelete.sizeDelta.x - rectBtnBattle.sizeDelta.x;
        widthRectCanvasNew = widthRectCanvasNew - rectBtnMission.sizeDelta.x - rectBtnChickenSpawn.sizeDelta.x - rectBtnUpgradeShield.sizeDelta.x;
        float spaceBtn = widthRectCanvasNew / 4;

        rectBtnMission.anchoredPosition = GetPosBtn(rectBtnDelete.sizeDelta.x, rectBtnMission.sizeDelta.x/2, 0, 0, spaceBtn,1);
        rectBtnChickenSpawn.anchoredPosition = GetPosBtn(rectBtnDelete.sizeDelta.x, rectBtnMission.sizeDelta.x, 
            rectBtnChickenSpawn.sizeDelta.x/2, 0, spaceBtn, 2);
        rectBtnUpgradeShield.anchoredPosition = GetPosBtn(rectBtnDelete.sizeDelta.x, rectBtnMission.sizeDelta.x,
            rectBtnChickenSpawn.sizeDelta.x, rectBtnUpgradeShield.sizeDelta.x / 2, spaceBtn, 3);
    }

    protected virtual Vector2 GetPosBtn(float rectBtnDelete_x, float rectBtnMission_x, float rectBtnSpawnChicken_x,
        float rectBtnUpdateShield_x, float spaceBtn, int numSpace)
    {
        Vector2 pos;
        pos.x = 100 + rectBtnDelete_x + spaceBtn * numSpace + rectBtnMission_x + rectBtnSpawnChicken_x + rectBtnUpdateShield_x;
        pos.y = 100;
        return pos;
    }
}
