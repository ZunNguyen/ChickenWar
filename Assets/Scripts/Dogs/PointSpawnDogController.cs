using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class PointSpawnDogController : ErshenMonoBehaviour
{
    [Header("Connect Outside")]
    [SerializeField] protected WaveDogSO waveDogSO;

    [SerializeField] protected GameObjectSpawner gameObjectSpawner;
    public GameObjectSpawner GameObjectSpawner => gameObjectSpawner;

    [SerializeField] protected CanvasController canvasController;
    public CanvasController CanvasController => canvasController;

    [Header("Connect Inside")]
    [SerializeField] protected List<PointSpawnDog> listPointSpawnDog;

    [Header("Variable")]
    public int wave = 0;
    [SerializeField] protected int phase = 0;
    [SerializeField] protected int levelDog = 0;
    public int dogNum = 0;
    [SerializeField] protected float timeDelay;
    [SerializeField] protected string indexLine;
    public bool isSpawning = false;


    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadGameObjectSpawner();    
        LoadListPointSpawnDog();
        LoadWaveDogSO();
        LoadCanvasController();
    }

    protected virtual void LoadGameObjectSpawner()
    {
        if (gameObjectSpawner != null) return;
        gameObjectSpawner = GameObject.Find("GameObject Spawner").GetComponent<GameObjectSpawner>();
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

    protected virtual void LoadCanvasController()
    {
        if (canvasController != null) return;
        canvasController = GameObject.Find("Canvas").GetComponent<CanvasController>();
    }

    public virtual void OnObj()
    {
        gameObject.SetActive(true);
        phase = 0;
        levelDog = 0;
        dogNum = 0;
        isSpawning = false;
    }

    private void Update()
    {
        CanSpawn();
    }

    protected virtual void CanSpawn()
    {
        canvasController.ButtonManager.isStarting = true;
        if (isSpawning) return;
        if (CheckWaveIsMax()) return;
        if (CheckPhaseIsMax()) return;
        if (CheckLevelDogIsMax()) return;
        if (CheckNumDogIsMax()) return;
        Spawn();
    }

    protected virtual void Spawn()
    {
        indexLine = waveDogSO.waves[wave].phases[phase].levelDogs[levelDog].indexLine;
        string dogName = waveDogSO.waves[wave].phases[phase].levelDogs[levelDog].nameDog;
        timeDelay = waveDogSO.waves[wave].phases[phase].levelDogs[levelDog].timeDelay;
        int hpDogMax = waveDogSO.waves[wave].phases[phase].levelDogs[levelDog].hpDog;
        int damageDog = waveDogSO.waves[wave].phases[phase].levelDogs[levelDog].damageDog;
        foreach (PointSpawnDog pointSpawnDog in listPointSpawnDog)
        {
            // Check dog have index equal with index in wave dog data
            int index = pointSpawnDog.index;
            if (indexLine.Contains(index.ToString()))
            {
                StartCoroutine(listPointSpawnDog[index - 1].Spawning(dogName, timeDelay, hpDogMax, damageDog));
            }
        }
    }

    // Check Dog Number is Max?
    protected virtual bool CheckNumDogIsMax()
    {
        int countIndex = waveDogSO.waves[wave].phases[phase].levelDogs[levelDog].indexLine.Length - 1;
        if ((dogNum/ countIndex) == waveDogSO.waves[wave].phases[phase].levelDogs[levelDog].nums)
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
        if (levelDog == waveDogSO.waves[wave].phases[phase].levelDogs.Count)
        {
            levelDog = 0;
            phase += 1;

            // Delay 5s before change the new phase
            StartCoroutine(RunAfterDelay(7));

            return true;
        }
        return false;
    }

    // Check phase is max?
    protected virtual bool CheckPhaseIsMax()
    {
        if (phase == waveDogSO.waves[wave].phases.Count)
        {
            CheckWin();
            
            return true;
        }
        return false;
    }

    // Check wave is max?
    protected virtual bool CheckWaveIsMax()
    {
        if (wave == waveDogSO.waves.Count)
        {
            Debug.Log("Wave max");
            return true;
        }
        return false;
    }

    // Check Win
    protected virtual void CheckWin()
    {
        if (canvasController.TrackingWaveController.TrackingWave.CheckEndWave())
        {
            phase = 0;
            wave += 1;
            Time.timeScale = 1f;
            Debug.Log("Finish wave " + wave);
            canvasController.PanelController.Panel.PanelVictoryOn();
            gameObject.SetActive(false);
        }
    }

    protected virtual IEnumerator RunAfterDelay(float timeDelay)
    {
        isSpawning = true;
        yield return new WaitForSeconds(timeDelay);
        isSpawning = false;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        foreach (PointSpawnDog pointSpawnDog in listPointSpawnDog)
        {
            pointSpawnDog.x = 0.01f;
        }
    }
}