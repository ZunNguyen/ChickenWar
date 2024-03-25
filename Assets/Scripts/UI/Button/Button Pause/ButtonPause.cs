using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : ErshenMonoBehaviour
{
    [Header("---Connect Ctrl---")]
    [SerializeField] protected ButtonPauseCtrl buttonPauseCtrl;
    [SerializeField] protected GameObject panelConfirm;
    [SerializeField] protected GameObject panelPause;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadButtonPauseCtrl();
        LoadPanelConfirm();
        LoadPanelPause();
    }

    protected virtual void LoadButtonPauseCtrl()
    {
        if (buttonPauseCtrl != null) return;
        buttonPauseCtrl = transform.GetComponent<ButtonPauseCtrl>();
    }

    protected virtual void LoadPanelConfirm()
    {
        if (panelConfirm != null) return;
        panelConfirm = transform.Find("Panel - Confirm").gameObject;
    }

    protected virtual void LoadPanelPause()
    {
        if (panelPause != null) return;
        panelPause = transform.Find("Panel - Pause").gameObject;
    }

    public virtual void PressPauseButton()
    {
        // Audio
        buttonPauseCtrl.CanvasController.AudioManager.PlaySFX(buttonPauseCtrl.CanvasController.AudioManager.effectClick);

        buttonPauseCtrl.TWPanelPasue.TW_PanelPasueOn();
        Time.timeScale = 0f;
    }

    public virtual void PressResumeButton()
    {
        // Audio
        buttonPauseCtrl.CanvasController.AudioManager.PlaySFX(buttonPauseCtrl.CanvasController.AudioManager.effectClick);

        Time.timeScale = 1f;
        buttonPauseCtrl.TWPanelPasue.TW_PanelPasueOff();
    }

    public virtual void PressSettingButton()
    {
        // Audio
        buttonPauseCtrl.CanvasController.AudioManager.PlaySFX(buttonPauseCtrl.CanvasController.AudioManager.effectClick);

        buttonPauseCtrl.TWPanelSetting.TW_PaneSettingOn();
        buttonPauseCtrl.TWPanelPasue.TW_PanelPasueOff();
        //Invoke(nameof(buttonPauseCtrl.TWPanelPasue.TW_PanelPasueOff), 1.2f);
    }

    public virtual void PressConfirmButton()
    {
        // Audio
        buttonPauseCtrl.CanvasController.AudioManager.PlaySFX(buttonPauseCtrl.CanvasController.AudioManager.effectClick);

        buttonPauseCtrl.TWPanelPasue.TW_PanelPasueOn();
        buttonPauseCtrl.TWPanelSetting.TW_PaneSettingOff();
        //Invoke(nameof(buttonPauseCtrl.TWPanelSetting.TW_PaneSettingOff), 1.2f);
    }

    public virtual void PressRestartButton()
    {
        // Audio
        buttonPauseCtrl.CanvasController.AudioManager.PlaySFX(buttonPauseCtrl.CanvasController.AudioManager.effectClick);

        panelPause.SetActive(false);
        panelConfirm.SetActive(true);
    }

    public virtual void PressNoButton()
    {
        panelPause.SetActive(true);
        panelConfirm.SetActive(false);
    }

    public virtual void PressYesButton()
    {
        // Reset Game
        buttonPauseCtrl.CanvasController.SaveDataManager.ResetGame();
    }
}
