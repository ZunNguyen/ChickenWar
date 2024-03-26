using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMission_1 : PanelMissionAbstract
{
    protected override float GetEarnGold()
    {
        float goldEarn = panelMissionCtrl.MissionSO.mission_1[indexMission].prize;
        return goldEarn;
    }

    protected override float GetMissionCurrent()
    {
        return panelMissionCtrl.MissionSO.mission_1[indexMission].mission;
    }

    protected override void InputTextDescription()
    {
        indexMissionMax = panelMissionCtrl.MissionSO.missionMax_1;
        if (indexMission == indexMissionMax)
        {
            textDescription.text = "Max";
            return;
        }
        missionCurrent = panelMissionCtrl.MissionSO.mission_1[indexMission].mission;
        string _achievementPlayer = ChangeValueFromTextToString(achievementPlayer);
        string _missionCurrent = ChangeValueFromTextToString(missionCurrent);
        textDescription.text = "Reach upgrade level chicken to level " + _missionCurrent + "\r\n" + "Process: "+ _achievementPlayer + "/" + _missionCurrent;
    }

    protected override void TW_EarnGold()
    {
        panelMissionCtrl.TW_PanelMission_1.TW_EarnGold(1, goldPrice);
        panelMissionCtrl.TW_PanelMission_1.SetIsClaimingIsFalse();
    }
}
