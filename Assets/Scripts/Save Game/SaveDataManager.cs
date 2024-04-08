using System;
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

    private void Start()
    {
        InvokeRepeating(nameof(SaveGame), 0, 20f);
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
        PlayerPrefs.SetString("SaveGame", json);
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
        string json = PlayerPrefs.GetString("SaveGame");
        if (json == "")
        {
            json = "{\"goldPlayer\":0,\"waveDog\":0,\"levelShield\":0,\"highestLevelChicken\":0,\"levelSpawnChicken\":0,\"indexSlot\":" +
            "[],\"nameChicken\":[],\"volumeMusic\":10.0,\"volumeSFX\":10.0,\"lastTimeExit\":\"\",\"achievementList\":" +
            "[1.0,115.0,1.0,1.0],\"missionCurrentList\":[5.0,1000.0,5.0,30.0],\"indexMissionList\":[0,0,0,0],\"learnTutorial\":false}";
            PlayerPrefs.SetString("SaveGame", json);
        }
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

        if (dataGame.indexSlot.Count != 0)
        {
            for (int i = 0; i < dataGame.indexSlot.Count; i++)
            {
                canvasController.SpawnChicken.InstantiatePrefab(dataGame.nameChicken[i], dataGame.indexSlot[i]);
            }
        }
        
        LoadAchievement(dataGame);
        LoadMissionCurrent(dataGame);
        LoadIndexMission(dataGame);

        if (!dataGame.learnTutorial)
        {
            canvasController.Tutorial.gameObject.SetActive(true);
            canvasController.Tutorial.TutorialGame();
        }

        SaveGame();
    }

    protected virtual void ProcessTimeGame(string timeLastGame)
    {
        if (timeLastGame == "") return;
        DateTime timeLastExit = DateTime.Parse(timeLastGame);
        TimeSpan offlineDuration = DateTime.Now - timeLastExit;
        int offlineSecond = (int)(offlineDuration.TotalSeconds);
        float goldCount = offlineSecond * 0.1f;
        int gold = (int)goldCount;
        if (gold < 100) return;
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
        string json = "";
        PlayerPrefs.SetString("SaveGame", json);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
