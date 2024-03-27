using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMission_3 : PanelMissionAbstract
{
    protected override float GetEarnGold()
    {
        float goldEarn = panelMissionCtrl.MissionSO.mission_3[indexMission].prize;
        return goldEarn;
    }

    protected override void InputTextDescription()
    {
        indexMissionMax = panelMissionCtrl.MissionSO.missionMax_3;
        if (indexMission == indexMissionMax)
        {
            textDescription.text = "Max";
            return;
        }
        missionCurrent = panelMissionCtrl.MissionSO.mission_3[indexMission].mission;
        string _achievementPlayer = ChangeValueFromTextToString(achievementPlayer);
        string _missionCurrent = ChangeValueFromTextToString(missionCurrent);
        textDescription.text = "Reach the wave dog at level " + _missionCurrent + "\r\n" + "Process: " + _achievementPlayer + "/" + _missionCurrent;
    }

    protected override void TW_EarnGold()
    {
        panelMissionCtrl.TW_PanelMission_3.TW_EarnGold(1, goldPrice);
        panelMissionCtrl.TW_PanelMission_3.SetIsClaimingIsFalse();
    }
}
