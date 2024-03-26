using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TW_PanelMission_3 : TWPanelMissionAbstract
{
    [Header("---Gold Position---")]
    [SerializeField] protected Vector2 savePositon = new(-31, -202);

    protected override Vector2 SavePosition()
    {
        Vector2 position = savePositon;
        return position;
    }
}
