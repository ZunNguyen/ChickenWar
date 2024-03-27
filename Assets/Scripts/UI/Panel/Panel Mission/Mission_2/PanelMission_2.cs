using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMission_2 : PanelMissionAbstract
{
    protected override float GetEarnGold()
    {
        float goldEarn = panelMissionCtrl.MissionSO.mission_2[indexMission].prize;
        return goldEarn;
    }

    protected override void InputTextDescription()
    {
        indexMissionMax = panelMissionCtrl.MissionSO.missionMax_2;
        if (indexMission == indexMissionMax)
        {
            textDescription.text = "Max";
            return;
        }
        missionCurrent = panelMissionCtrl.MissionSO.mission_2[indexMission].mission;
        string _achievementPlayer = ChangeValueFromTextToString(achievementPlayer);
        string _missionCurrent = ChangeValueFromTextToString(missionCurrent);
        textDescription.text = "Reach collect " + _missionCurrent + " gold" + "\r\n" + "Process: " + _achievementPlayer + "/" + _missionCurrent;
    }

    protected override void TW_EarnGold()
    {
        panelMissionCtrl.TW_PanelMission_2.TW_EarnGold(1, goldPrice);
        panelMissionCtrl.TW_PanelMission_2.SetIsClaimingIsFalse();
    }
}
