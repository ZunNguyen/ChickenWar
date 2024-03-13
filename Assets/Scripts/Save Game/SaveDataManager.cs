using JetBrains.Annotations;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveDataManager : ErshenMonoBehaviour
{
    [Header("Reset Game")]
    [SerializeField] protected bool resetGame = false;

    [Header("Load Script")]
    [SerializeField] protected CanvasController canvasController;

    protected override void LoadComponent()
    {
        LoadCanvasController();
        ResetGame();
        LoadGame();
    }
    protected virtual void LoadCanvasController()
    {
        if (canvasController != null) return;
        canvasController = GameObject.Find("Canvas").GetComponent<CanvasController>();
    }

    protected virtual void ResetGame()
    {
        if (resetGame)
        {
            string path = "Assets/DataGame.json";
            File.Delete(path);
        }
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
            levelSpawnChicken = canvasController.ButtonSpawn.levelSpawnChicken
        };
        canvasController.SpawnChicken.SaveSlotChicken(dataGame.indexSlot, dataGame.nameChicken);

        string json = JsonUtility.ToJson(dataGame);
        File.WriteAllText(Application.dataPath + "/DataGame.json", json);
    }

    // Load value from playerprefs
    protected virtual void LoadGame()
    {
        if (resetGame) return;
        string json = File.ReadAllText(Application.dataPath + "/DataGame.json");
        DataGame dataGame = JsonUtility.FromJson<DataGame>(json);

        canvasController.GoldPlayer.gold = dataGame.goldPlayer;
        canvasController.PointSpawnDogController.wave = dataGame.waveDog;
        canvasController.ShieldUpdate.levelCurrent = dataGame.levelShield;
        canvasController.ButtonSpawn.highestLevelChicken = dataGame.highestLevelChicken;
        canvasController.ButtonSpawn.levelSpawnChicken = dataGame.levelSpawnChicken;
        canvasController.TWUpgradeChicken.indexLVHighest = dataGame.highestLevelChicken;

        for (int i  = 0; i < dataGame.indexSlot.Count; i++)
        {
            canvasController.SpawnChicken.InstantiatePrefab(dataGame.nameChicken[i],dataGame.indexSlot[i]);
        }
    }
}
