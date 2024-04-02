using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataManager : ErshenMonoBehaviour
{
    [Header("Load Script")]
    [SerializeField] protected CanvasCtrl canvasController;
    public bool _learnTurorial;

    protected override void LoadComponent()
    {
        LoadCanvasController();
        LoadGame();
    }
    protected virtual void LoadCanvasController()
    {
        if (canvasController != null) return;
        canvasController = GameObject.Find("Canvas").GetComponent<CanvasCtrl>();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus) SaveGame();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus) SaveGame();
    }

    // Save value to playerprefs
    protected virtual void SaveGame()
    {
        DataGame dataGame = new()
        {
            goldPlayer = canvasController.GoldPlayer.gold,
            waveDog = canvasController.PointSpawnDogController.wave,
            levelShield = canvasController.ShieldUpdate.levelCurrent,
            highestLevelChicken = canvasController.ButtonSpawn.highestLevelChicken,
            levelSpawnChicken = canvasController.ButtonSpawn.levelSpawnChicken,
            volumeMusic = canvasController.ButtonPauseCtrl.SettingVolume.volumeMusic,
            volumeSFX = canvasController.ButtonPauseCtrl.SettingVolume.volumeSFX,
            learnTutorial = _learnTurorial,
            lastTimeExit = DateTime.Now.ToString(),
        };
        SaveAchievement(dataGame);
        SaveMissionCurrent(dataGame);
        SaveIndexMission(dataGame);

        canvasController.SpawnChicken.SaveSlotChicken(dataGame.indexSlot, dataGame.nameChicken);
        string json = JsonUtility.ToJson(dataGame);
        File.WriteAllText(Application.dataPath + "/DataGame.json", json);
    }

    protected virtual void SaveAchievement(DataGame dataGame)
    {
        dataGame.achievementList.Add(canvasController.PanelMissionCtrl.PanelMission_1.achievementPlayer);
        dataGame.achievementList.Add(canvasController.PanelMissionCtrl.PanelMission_2.achievementPlayer);
        dataGame.achievementList.Add(canvasController.PanelMissionCtrl.PanelMission_3.achievementPlayer);
        dataGame.achievementList.Add(canvasController.PanelMissionCtrl.PanelMission_4.achievementPlayer);
    }

    protected virtual void SaveMissionCurrent(DataGame dataGame)
    {
        dataGame.missionCurrentList.Add(canvasController.PanelMissionCtrl.PanelMission_1.missionCurrent);
        dataGame.missionCurrentList.Add(canvasController.PanelMissionCtrl.PanelMission_2.missionCurrent);
        dataGame.missionCurrentList.Add(canvasController.PanelMissionCtrl.PanelMission_3.missionCurrent);
        dataGame.missionCurrentList.Add(canvasController.PanelMissionCtrl.PanelMission_4.missionCurrent);
    }

    protected virtual void SaveIndexMission(DataGame dataGame)
    {
        dataGame.indexMissionList.Add(canvasController.PanelMissionCtrl.PanelMission_1.indexMission);
        dataGame.indexMissionList.Add(canvasController.PanelMissionCtrl.PanelMission_2.indexMission);
        dataGame.indexMissionList.Add(canvasController.PanelMissionCtrl.PanelMission_3.indexMission);
        dataGame.indexMissionList.Add(canvasController.PanelMissionCtrl.PanelMission_4.indexMission);
    }

    // Load value from playerprefs
    protected virtual void LoadGame()
    {
        if (!File.Exists(Application.dataPath + "/DataGame.json"))
        {
            canvasController.ButtonPauseCtrl.SettingVolume.volumeMusic = 10;
            canvasController.ButtonPauseCtrl.SettingVolume.volumeSFX = 10;
            canvasController.GoldPlayer.LoadBegin(0);
            canvasController.Tutorial.gameObject.SetActive(true);
            canvasController.Tutorial.TutorialGame();
            return;
        }
        
        string json = File.ReadAllText(Application.dataPath + "/DataGame.json");
        DataGame dataGame = JsonUtility.FromJson<DataGame>(json);
        
        canvasController.GoldPlayer.LoadBegin(dataGame.goldPlayer);
        canvasController.PointSpawnDogController.wave = dataGame.waveDog;
        canvasController.ShieldUpdate.levelCurrent = dataGame.levelShield;
        canvasController.ShieldUpdate.LoadBeginGame();
        canvasController.ButtonSpawn.highestLevelChicken = dataGame.highestLevelChicken;
        canvasController.ButtonSpawn.levelSpawnChicken = dataGame.levelSpawnChicken;
        canvasController.TWUpgradeChicken.indexLVHighest = dataGame.highestLevelChicken;
        canvasController.ButtonPauseCtrl.SettingVolume.volumeMusic = dataGame.volumeMusic;
        canvasController.ButtonPauseCtrl.SettingVolume.volumeSFX = dataGame.volumeSFX;
        _learnTurorial = dataGame.learnTutorial;
        ProcessTimeGame(dataGame.lastTimeExit);

        for (int i  = 0; i < dataGame.indexSlot.Count; i++)
        {
            canvasController.SpawnChicken.InstantiatePrefab(dataGame.nameChicken[i],dataGame.indexSlot[i]);
        }
        LoadAchievement(dataGame);
        LoadMissionCurrent(dataGame);
        LoadIndexMission(dataGame);

        if (!dataGame.learnTutorial)
        {
            canvasController.Tutorial.gameObject.SetActive(true);
            canvasController.Tutorial.TutorialGame();
        }
    }

    protected virtual void ProcessTimeGame(string timeLastGame)
    {
        if (timeLastGame == "") return;
        DateTime timeLastExit = DateTime.Parse(timeLastGame);
        TimeSpan offlineDuration = DateTime.Now - timeLastExit;
        int offlineSecond = (int)(offlineDuration.TotalSeconds);
        float goldCount = offlineSecond * 0.1f;
        int gold = (int)goldCount;
        if (gold < 10) return;
        canvasController.PanelEarnGoldOfflineCtrl.PanelEarnGoldOffline.PanelEarnGoldOfflineOn();
        canvasController.PanelEarnGoldOfflineCtrl.TextEarnGoldOffline.InputGoldValue(gold);
        canvasController.PanelEarnGoldOfflineCtrl.TextEarnGoldOffline.goldEarn = gold;
    }

     protected virtual void LoadAchievement(DataGame dataGame)
     {
        if (dataGame.achievementList.Count < 4) return;
        canvasController.PanelMissionCtrl.PanelMission_1.achievementPlayer = dataGame.achievementList[0];
        canvasController.PanelMissionCtrl.PanelMission_2.achievementPlayer = dataGame.achievementList[1];
        canvasController.PanelMissionCtrl.PanelMission_3.achievementPlayer = dataGame.achievementList[2];
        canvasController.PanelMissionCtrl.PanelMission_4.achievementPlayer = dataGame.achievementList[3];
     }

    protected virtual void LoadMissionCurrent(DataGame dataGame)
    {
        if (dataGame.missionCurrentList.Count < 4) return;
        canvasController.PanelMissionCtrl.PanelMission_1.missionCurrent = dataGame.missionCurrentList[0];
        canvasController.PanelMissionCtrl.PanelMission_2.missionCurrent = dataGame.missionCurrentList[1];
        canvasController.PanelMissionCtrl.PanelMission_3.missionCurrent = dataGame.missionCurrentList[2];
        canvasController.PanelMissionCtrl.PanelMission_4.missionCurrent = dataGame.missionCurrentList[3];
    }

    protected virtual void LoadIndexMission(DataGame dataGame)
    {
        if (dataGame.indexMissionList.Count < 4) return;
        canvasController.PanelMissionCtrl.PanelMission_1.indexMission = dataGame.indexMissionList[0];
        canvasController.PanelMissionCtrl.PanelMission_2.indexMission = dataGame.indexMissionList[1];
        canvasController.PanelMissionCtrl.PanelMission_3.indexMission = dataGame.indexMissionList[2];
        canvasController.PanelMissionCtrl.PanelMission_4.indexMission = dataGame.indexMissionList[3];
    }

    public virtual void ResetGame()
    {
        string path = "Assets/DataGame.json";
        File.Delete(path);
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
