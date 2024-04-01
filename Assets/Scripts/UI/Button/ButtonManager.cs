using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : ErshenMonoBehaviour
{
    [Header("---Connect Ctrl---")]
    [SerializeField] protected CanvasCtrl canvasCtrl;
    public bool isStarting = false;
    public int timePressButton = 0;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadCanvasCtrl();
    }

    protected virtual void LoadCanvasCtrl()
    {
        if (canvasCtrl != null) return;
        canvasCtrl = this.transform.GetComponentInParent<CanvasCtrl>();
    }

    public virtual void ButtonBattle()
    {
        if (canvasCtrl.PointSpawnDogController.wave == 40)
        {
            Debug.Log("The Wave is max");
            return;
        }
        timePressButton += 1;
        if (timePressButton % 2 == 0 && timePressButton > 0) canvasCtrl.ChangeButtonStart.ChangeImageButtonXTime(5,1);
        if (timePressButton % 2 == 1 && timePressButton > 0) canvasCtrl.ChangeButtonStart.ChangeImageButtonXTime(1,2);
        if (isStarting) return;

        //Audio
        canvasCtrl.AudioManager.PlayMusic(canvasCtrl.AudioManager.musicBattle);

        // On Spawn Dog
        canvasCtrl.PointSpawnDogController.gameObject.SetActive(true);
        canvasCtrl.PointSpawnDogController.OnObj();
        // On Bullet
        canvasCtrl.PointSpawnBulletController.BulletOn();
        // On tracking wave
        canvasCtrl.TrackingWaveController.TrackingWave.TrackingWaveOn();

        canvasCtrl.SaveDataManager._learnTurorial = true;
        Destroy(canvasCtrl.Tutorial.gameObject);
        //canvasCtrl.Tutorial.gameObject.SetActive(false);
    }

    public void ButtonSpawnChicken()
    {
        canvasCtrl.ButtonSpawn.SpawnChickenInGrid();
    }

    public virtual void ButtonUnclockChickenUpgrade()
    {
        canvasCtrl.TWUpgradeChicken.TW_UpgradeOff();
    }
}