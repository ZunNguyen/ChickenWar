using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.IO;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataManager : ErshenMonoBehaviour
{
    [Header("Load Script")]
    [SerializeField] protected CanvasController canvasController;

    protected override void LoadComponent()
    {
        LoadCanvasController();
        LoadGame();
    }
    protected virtual void LoadCanvasController()
    {
        if (canvasController != null) return;
        canvasController = GameObject.Find("Canvas").GetComponent<CanvasController>();
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
            lastTimeExit = DateTime.Now.ToString(),
        };
        canvasController.SpawnChicken.SaveSlotChicken(dataGame.indexSlot, dataGame.nameChicken);
        string json = JsonUtility.ToJson(dataGame);
        File.WriteAllText(Application.dataPath + "/DataGame.json", json);
    }

    // Load value from playerprefs
    protected virtual void LoadGame()
    {
        if (!File.Exists(Application.dataPath + "/DataGame.json"))
        {
            canvasController.ButtonPauseCtrl.SettingVolume.volumeMusic = 10;
            canvasController.ButtonPauseCtrl.SettingVolume.volumeSFX = 10;
            
            return;
        }
        
        string json = File.ReadAllText(Application.dataPath + "/DataGame.json");
        DataGame dataGame = JsonUtility.FromJson<DataGame>(json);
        
        canvasController.GoldPlayer.AddGoldPlayer(dataGame.goldPlayer);
        canvasController.PointSpawnDogController.wave = dataGame.waveDog;
        canvasController.ShieldUpdate.levelCurrent = dataGame.levelShield;
        canvasController.ButtonSpawn.highestLevelChicken = dataGame.highestLevelChicken;
        canvasController.ButtonSpawn.levelSpawnChicken = dataGame.levelSpawnChicken;
        canvasController.TWUpgradeChicken.indexLVHighest = dataGame.highestLevelChicken;
        canvasController.ButtonPauseCtrl.SettingVolume.volumeMusic = dataGame.volumeMusic;
        canvasController.ButtonPauseCtrl.SettingVolume.volumeSFX = dataGame.volumeSFX;
        ProcessTimeGame(dataGame.lastTimeExit);

        for (int i  = 0; i < dataGame.indexSlot.Count; i++)
        {
            canvasController.SpawnChicken.InstantiatePrefab(dataGame.nameChicken[i],dataGame.indexSlot[i]);
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

    public virtual void ResetGame()
    {
        string path = "Assets/DataGame.json";
        File.Delete(path);
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
