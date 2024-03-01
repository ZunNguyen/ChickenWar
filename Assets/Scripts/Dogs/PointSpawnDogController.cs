using System.Collections.Generic;
using UnityEngine;

public class PointSpawnDogController : ErshenMonoBehaviour
{
    [Header("Connect Script Outside")]
    [SerializeField] protected DogSpawner dogSpawner;
    public DogSpawner DogSpawner { get => dogSpawner; }
    [SerializeField] protected WaveDogSO waveDogSO;

    [Header("Connect Script Childrent")]
    [SerializeField] protected List<PointSpawnDog> listPointSpawnDog;

    [Header("Variable")]
    [SerializeField] protected int wave = 0;
    [SerializeField] protected int phase = 0;
    [SerializeField] protected int levelDog = 0;
    [SerializeField] protected float timeDelay;
    public int dogNum = 0;
    [SerializeField] protected string indexLine;
    public bool isSpawning = false;

    [Header("Debug")]
    [SerializeField] protected bool checkWaveMax;
    [SerializeField] protected bool checkPhaseMax;
    [SerializeField] protected bool checkLevelDogMax;
    [SerializeField] protected bool checkDogMax;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadDogSpawner();
        LoadListPointSpawnDog();
        LoadWaveDogSO();
    }

    protected virtual void LoadDogSpawner()
    {
        if (dogSpawner != null) return;
        dogSpawner = GameObject.Find("Dog Spawner").GetComponent<DogSpawner>();
    }

    protected virtual void LoadListPointSpawnDog()
    {
        if (listPointSpawnDog.Count > 0) return;
        foreach (Transform obj in this.transform)
        {
            PointSpawnDog pointSpawnDog = obj.GetComponent<PointSpawnDog>();
            listPointSpawnDog.Add(pointSpawnDog);
        }
    }

    protected virtual void LoadWaveDogSO()
    {
        if (waveDogSO != null) return;
        string resPath = "SO/Wave Dog/WaveDog";
        waveDogSO = Resources.Load<WaveDogSO>(resPath);
    }

    public virtual void OnList()
    {
        foreach (PointSpawnDog pointSpawnDog in listPointSpawnDog)
        {
            pointSpawnDog.enabled = true;
        }
    }

    public virtual void OffList()
    {
        foreach (PointSpawnDog pointSpawnDog in listPointSpawnDog)
        {
            pointSpawnDog.enabled = false;
        }
    }

    private void Update()
    {
        CanSpawn();
    }

    protected virtual void CanSpawn()
    {
        if (isSpawning) return;
        if (CheckNumDogIsMax()) return;
        if (CheckLevelDogIsMax()) return;
        if (CheckPhaseIsMax()) return;
        if (CheckWaveIsMax()) return;
        Spawn();
    }

    protected virtual void Spawn()
    {
        indexLine = waveDogSO.waves[wave].phases[phase].levelDogs[levelDog].indexLine;
        string dogName = waveDogSO.waves[wave].phases[phase].levelDogs[levelDog].nameDog;
        timeDelay = waveDogSO.waves[wave].phases[phase].levelDogs[levelDog].timeDelay;
        foreach (PointSpawnDog pointSpawnDog in listPointSpawnDog)
        {
            int index = pointSpawnDog.index;
            if (indexLine.Contains(index.ToString()))
            {
                StartCoroutine(listPointSpawnDog[index - 1].Spawning(dogName, timeDelay));
            }
        }
    }

    // Check Dog Number is Max?
    protected virtual bool CheckNumDogIsMax()
    {
        if (dogNum == waveDogSO.waves[wave].phases[phase].levelDogs[levelDog].nums)
        {
            dogNum = 0;
            levelDog += 1;
            checkDogMax = true;
            return true;
        }
        checkDogMax = false;
        return false;
    }

    // Check level dog is max?
    protected virtual bool CheckLevelDogIsMax()
    {
        if (levelDog == waveDogSO.waves[wave].phases[phase].levelDogs.Count)
        {
            levelDog = 0;
            phase += 1;
            checkLevelDogMax = true;
            return true;
        }
        checkLevelDogMax = false;
        return false;
    }

    // Check phase is max?
    protected virtual bool CheckPhaseIsMax()
    {
        if (phase == waveDogSO.waves[wave].phases.Count)
        {
            phase = 0;
            wave += 1;
            Debug.Log("Finish wave " + wave);
            checkPhaseMax = true;
            return true;
        }
        checkPhaseMax = false;
        return false;
    }

    // Check wave is max?
    protected virtual bool CheckWaveIsMax()
    {
        if (wave == waveDogSO.waves.Count)
        {
            Debug.Log("Wave max");
            checkWaveMax = true;
            return true;
        }
        checkWaveMax = false;
        return false;
    }
}