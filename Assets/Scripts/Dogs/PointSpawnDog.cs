using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawnDog : ErshenMonoBehaviour
{
    [Header("Connect Script")]
    [SerializeField] protected PointSpawnDogController pointSpawnDogController;

    [Header("Variable")]
    [SerializeField] protected float currentTime = 0f;
    [SerializeField] protected float timeDelay = 4f;
    [SerializeField] protected int index;

    [Header("Load ScriptableObject")]
    [SerializeField] protected WaveDogSO waveDog;

    [Header("Test")]
    [SerializeField] protected string dogName;
    [SerializeField] protected int dogNum;
    [SerializeField] protected int dogNumMax;
    [SerializeField] protected int wave = 0;
    [SerializeField] protected int phase = 0;
    [SerializeField] protected int levelDog = 0;

    private void Update()
    {
        SpawnDog();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPointSpawnDogController();
        LoadIndex();
        LoadWaveDogSO();
        SetOffScript();
    }

    protected virtual void LoadPointSpawnDogController()
    {
        if (pointSpawnDogController != null) return;
        pointSpawnDogController = transform.GetComponentInParent<PointSpawnDogController>();
    }

    protected virtual void LoadIndex()
    {
        if (index > 0) return;
        string name = gameObject.name;
        index = name[name.Length - 1];
        index -= 48;
    }

    protected virtual void LoadWaveDogSO()
    {
        if (waveDog != null) return;
        string resPath = "SO/Wave Dog/WaveDog";
        waveDog = Resources.Load<WaveDogSO>(resPath);
    }

    protected virtual void SetOffScript()
    {
        PointSpawnDog pointSpawnDog = this.transform.GetComponent<PointSpawnDog>();
        pointSpawnDog.enabled = false;
    }

    protected virtual void SpawnDog()
    {
        if (!CanSpawning()) return;
        // Get name dog to spawn
        dogName = waveDog.waves[wave].phases[phase].levelDogs[levelDog].dog.gameObject.name;
        // Get time delay to spawn
        timeDelay = waveDog.waves[wave].phases[phase].levelDogs[levelDog].timeDelay;
        // Spawning
        Spawning(dogName, timeDelay);
    }

    protected virtual bool CanSpawning()
    {
        if (CheckWaveIsMax()) return false;
        if (CheckPhaseIsMax()) return false;
        if (CheckLevelDogIsMax()) return false;
        if (CheckNumDogIsMax()) return false;
        if (!CheckLineAllowSpawn()) return false;
        return true;
    }
    
    // Check dog line had allow to spawn
    protected virtual bool CheckLineAllowSpawn()
    {
        if (waveDog.waves[wave].phases[phase].levelDogs[levelDog].CheckDogInList(index) == false) return false;
        return true;
    }

    // Check Dog Number is Max?
    protected virtual bool CheckNumDogIsMax()
    {
        dogNumMax = waveDog.waves[wave].phases[phase].levelDogs[levelDog].nums;
        if (dogNum == dogNumMax)
        {
            dogNum = 0;
            levelDog += 1;
            return true;
        }
        return false;
    }

    // Check level dog is max?
    protected virtual bool CheckLevelDogIsMax()
    {
        if (levelDog == waveDog.waves[wave].phases[phase].levelDogs.Count)
        {
            levelDog = 0;
            phase += 1; 
            return true;
        }
        return false;
    }

    // Check phase is max?
    protected virtual bool CheckPhaseIsMax()
    {
        if (phase == waveDog.waves[wave].phases.Count)
        {
            phase = 0;
            wave += 1;
            return true;
        }
        return false;
    }

    // Check wave is max?
    protected virtual bool CheckWaveIsMax()
    {
        if (wave == waveDog.waves.Count)
        {
            Debug.Log("You win");
            return true;
        }
        return false;
    }


    protected virtual void Spawning(string nameDog, float timeDelay)
    {
        currentTime += Time.deltaTime;
        if (currentTime < timeDelay) return;
        if (currentTime > timeDelay)
        {
            Transform newDogSpawn = pointSpawnDogController.DogSpawner.Spawn(nameDog, transform.position, transform.rotation);
            newDogSpawn.gameObject.SetActive(true);
            DogCtrl dogCtrl = newDogSpawn.GetComponent<DogCtrl>();
            dogCtrl.DogIndex.indexDog = index;
            currentTime = 0;
            dogNum += 1;
        }
    }
}