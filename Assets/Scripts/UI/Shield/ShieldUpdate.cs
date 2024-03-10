using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUpdate : CanvasAbstract
{
    public ShieldSO shieldSO;
    public int levelCurrent;
    [SerializeField] protected int goldPlayer;
    [SerializeField] protected int goldUpgrade;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadShieldSO();
    }

    protected virtual void LoadShieldSO()
    {
        if (shieldSO != null) return;
        string resPath = "SO/Shield/Shield";
        shieldSO = Resources.Load<ShieldSO>(resPath);
    }

    private void Start()
    {
        LoadBeginGame();
    }

    protected virtual void LoadBeginGame()
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
            levelCurrent += 1;
            UpdateGoldUpgradeShield(levelCurrent);
            // Change Value Hp Max for Sum HP Shield
            ChangeValueSumHpShield(levelCurrent);
            canvasController.ShieldHPSum.LoadSumHpCurrent();
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
        if (!GoldEnough()) return false;
        return true;
    }

    protected virtual bool GoldEnough()
    {
        goldPlayer = canvasController.GoldPlayer.gold;
        goldUpgrade = shieldSO.levels[levelCurrent + 1].gold;
        if (goldUpgrade > goldPlayer) return false;
        UpdateGoldPlayer(goldPlayer, goldUpgrade);
        return true;
    }

    protected virtual void UpdateGoldPlayer(int goldPlayer, int goldUpgrade)
    {
        canvasController.GoldPlayer.gold = goldPlayer - goldUpgrade;
    }

    protected virtual void UpdateGoldUpgradeShield(int levelCurrent)
    {
        if (levelCurrent < shieldSO.levels.Count - 1)
        {
            int index = levelCurrent + 1;
            canvasController.ShieldGoldUpdate.goldUpgrade = shieldSO.levels[index].gold;
        }
    }

    // Change Value Hp Max for Sum HP Shield
    protected virtual void ChangeValueSumHpShield(int levelCurrent)
    {
        canvasController.ShieldHPSum.sumHpMax = shieldSO.levels[levelCurrent].hp;
    }

    protected virtual void LoadShielHPBegin()
    {
        int hp = shieldSO.levels[levelCurrent].hp;
        canvasController.ShieldHPText.Print(hp, hp);
    }
}