using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUpdate : CanvasAbstract
{
    [Header("---Connect Ctrl---")]
    [SerializeField] protected ShieldUpdateController shieldUpdateController;

    [Header("---Value---")]
    [SerializeField] protected float goldPlayer;
    [SerializeField] protected float goldUpgrade = 300;
    public float hpMax = 100;
    public float hpCurrent;
    public int levelCurrent;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadShieldUpdateController();
    }

    protected virtual void LoadShieldUpdateController()
    {
        if (shieldUpdateController != null) return;
        shieldUpdateController = this.transform.GetComponent<ShieldUpdateController>();
    }

    public virtual void LoadBeginGame()
    {
        UpdateGoldUpgradeShield(levelCurrent);
        LoadShielHPBegin();
    }

    // The HP Shield will be updated
    public virtual void PressUpdateShield()
    {
        if (CanUpdate())
        {
            //SFX
            shieldUpdateController.CanvasController.AudioManager.PlaySFX(shieldUpdateController.CanvasController.AudioManager.effectSpawnButton);

            levelCurrent += 1;
            LoadBeginGame();
        }
    }

    // Check gold of player enough to update
    protected virtual bool CanUpdate()
    {
        // The level current is highest?
        if (levelCurrent >= shieldUpdateController.ShieldSO.listLevelShields.Count - 1)
        {
            // Text for shield Max
            canvasController.TWTextSpawner.SpawnText(transform.position, transform.rotation, "Level is highest");
            return false;
        }

        // Enough gold?
        if (!GoldEnough())
        {
            // Audio
            canvasController.AudioManager.PlaySFX(canvasController.AudioManager.effectSpawnError);
            canvasController.TWTextSpawner.SpawnText(transform.position, transform.rotation, "Not Enough Gold");
            return false;
        }
        return true;
    }

    protected virtual bool GoldEnough()
    {
        goldPlayer = shieldUpdateController.CanvasController.GoldPlayer.gold;
        
        if (goldUpgrade > goldPlayer) return false;
        UpdateGoldPlayer(goldPlayer, goldUpgrade);
        return true;
    }

    protected virtual void UpdateGoldPlayer(float goldPlayer, float goldUpgrade)
    {
        shieldUpdateController.CanvasController.GoldPlayer.SubtractGoldPlayer((int)goldUpgrade);
    }

    protected virtual void UpdateGoldUpgradeShield(int levelCurrent)
    {
        if (levelCurrent < shieldUpdateController.ShieldSO.listLevelShields.Count - 1)
        {
            int index = levelCurrent + 1;
            goldUpgrade = shieldUpdateController.ShieldSO.listLevelShields[index].gold;
            shieldUpdateController.ShieldGoldUpdate.PrintText(goldUpgrade);
        }
        if (levelCurrent == shieldUpdateController.ShieldSO.listLevelShields.Count - 1)
        {
            shieldUpdateController.ShieldGoldUpdate.PrintMaxShield();
        }
    }

    protected virtual void LoadShielHPBegin()
    {
        if (levelCurrent == shieldUpdateController.ShieldSO.listLevelShields.Count - 1)
        {
            hpMax = shieldUpdateController.ShieldSO.listLevelShields[levelCurrent].hp;
        }
        if (levelCurrent != shieldUpdateController.ShieldSO.listLevelShields.Count - 1)
        {
            hpMax = shieldUpdateController.ShieldSO.listLevelShields[levelCurrent].hp;
        }
        hpCurrent = hpMax;
        shieldUpdateController.ShieldHPText.Print(hpCurrent, hpMax);
        shieldUpdateController.ShieldHPBar.ChangeSlider(hpCurrent, hpMax);
    }

    public virtual void SubtractHPShield(float subtractHp)
    {
        hpCurrent -= subtractHp;
        if(hpCurrent <= 0)
        {
            // Game Over
            shieldUpdateController.CanvasController.PointSpawnDogController.gameObject.SetActive(false);
            shieldUpdateController.CanvasController.PanelVictoyLoseCtrl.PanelVictoryLose.PanelLoseOn();
            shieldUpdateController.CanvasController.TrackingWaveController.TWTrackingWave.TW_TrackingWaveOff();
            shieldUpdateController.CanvasController.ChangeButtonStart.ChangeImageButtonStart();
            Time.timeScale = 1f;
            hpCurrent = 0;
        }
        shieldUpdateController.ShieldHPBar.ChangeSlider(hpCurrent, hpMax);
    }
}