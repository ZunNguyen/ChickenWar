using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TW_PanelMission_4 : TWPanelMissionAbstract
{
    [Header("---Gold Position---")]
    [SerializeField] protected Vector2 savePositon = new(-32, -202);

    protected override Vector2 GetPositionGoldPlayer()
    {
        Vector2 position = new (-1088,724);
        return position;
    }

    protected override Vector2 SavePosition()
    {
        Vector2 position = savePositon;
        return position;
    }
}
