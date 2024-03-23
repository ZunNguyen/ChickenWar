using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUpdate : CanvasAbstract
{
    [Header("Connect InSide")]
    [SerializeField] protected ShieldUpdateController shieldUpdateController;
    public ShieldUpdateController ShieldUpdateController => shieldUpdateController;

    public ShieldSO shieldSO;
    public int levelCurrent;
    [SerializeField] protected int goldPlayer;
    [SerializeField] protected int goldUpgrade;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadShieldSO();
        LoadShieldUpdateController();
    }

    protected virtual void LoadShieldSO()
    {
        if (shieldSO != null) return;
        string resPath = "SO/Shield/Shield";
        shieldSO = Resources.Load<ShieldSO>(resPath);
    }

    protected virtual void LoadShieldUpdateController()
    {
        if (shieldUpdateController != null) return;
        shieldUpdateController = this.transform.GetComponent<ShieldUpdateController>();
    }

    private void Start()
    {
        LoadBeginGame();
    }

    public virtual void LoadBeginGame()
    {
        UpdateGoldUpgradeShield(levelCurrent);
        ChangeValueSumHpShield(levelCurrent);
        LoadShielHPBegin();
    }

    // The HP Shield will be updated
    public virtual void Updating()
    {
        if (CanUpdate())
        {
            //SFX
            shieldUpdateController.CanvasController.AudioManager.PlaySFX(shieldUpdateController.CanvasController.AudioManager.effectSpawnButton);

            levelCurrent += 1;
            UpdateGoldUpgradeShield(levelCurrent);
            // Change Value Hp Max for Sum HP Shield
            ChangeValueSumHpShield(levelCurrent);
            shieldUpdateController.CanvasController.ShieldHPSum.LoadSumHpCurrent();
            Debug.Log("Level Shield: " + levelCurrent);
        }
    }

    // Check gold of player enough to update
    protected virtual bool CanUpdate()
    {
        // The level current is highest?
        if (levelCurrent >= shieldSO.levels.Count - 1)
        {
            Debug.Log("The level shield is highest level");
            return false;
        }
        // Enough gold?
        if (!GoldEnough())
        {
            Debug.Log("Haven't enough gold");

            // Audio
            canvasController.AudioManager.PlaySFX(canvasController.AudioManager.effectSpawnError);
            GameObject newPrefab = CoinCollectSpawner.Instance.Spawn("Not Enough Gold", transform.position, transform.rotation);
            NotEnoughGold notEnoughGold = newPrefab.GetComponent<NotEnoughGold>();
            notEnoughGold.TWTextOn();
            newPrefab.SetActive(true);

            return false;
        }
        return true;
    }

    protected virtual bool GoldEnough()
    {
        goldPlayer = shieldUpdateController.CanvasController.GoldPlayer.gold;
        goldUpgrade = shieldSO.levels[levelCurrent + 1].gold;
        if (goldUpgrade > goldPlayer) return false;
        UpdateGoldPlayer(goldPlayer, goldUpgrade);
        return true;
    }

    protected virtual void UpdateGoldPlayer(int goldPlayer, int goldUpgrade)
    {
        shieldUpdateController.CanvasController.GoldPlayer.SubtractGoldPlayer(goldUpgrade);
    }

    protected virtual void UpdateGoldUpgradeShield(int levelCurrent)
    {
        if (levelCurrent < shieldSO.levels.Count - 1)
        {
            int index = levelCurrent + 1;
            shieldUpdateController.ShieldGoldUpdate.PrintText(shieldSO.levels[index].gold);
        }
        if (levelCurrent == shieldSO.levels.Count - 1)
        {
            shieldUpdateController.ShieldGoldUpdate.PrintMaxShield();
        }
    }

    // Change Value Hp Max for Sum HP Shield
    protected virtual void ChangeValueSumHpShield(int levelCurrent)
    {
        shieldUpdateController.CanvasController.ShieldHPSum.sumHpMax = shieldSO.levels[levelCurrent].hp;
    }

    protected virtual void LoadShielHPBegin()
    {
        int hp = shieldSO.levels[levelCurrent].hp;
        shieldUpdateController.ShieldHPText.Print(hp, hp);
        shieldUpdateController.ShieldHPBar.ChangeSlider(hp, hp);
    }
}