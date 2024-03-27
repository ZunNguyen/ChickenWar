using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TW_PanelMission_1 : TWPanelMissionAbstract
{
    [Header("---Gold Position---")]
    [SerializeField] protected Vector2 savePositon = new(-34, -202);

    protected override Vector2 GetPositionGoldPlayer()
    {
        Vector2 position = new(-124,725);
        return position;
    }

    protected override Vector2 SavePosition()
    {
        Vector2 position = savePositon;
        return position;
    }
}
