using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TW_PanelMission_2 : TWPanelMissionAbstract
{
    [Header("---Gold Position---")]
    [SerializeField] protected Vector2 savePositon = new(-33, -202);

    protected override Vector2 GetPositionGoldPlayer()
    {
        Vector2 position = new(-444,726);
        return position;
    }

    protected override Vector2 SavePosition()
    {
        Vector2 position = savePositon;
        return position;
    }
}
