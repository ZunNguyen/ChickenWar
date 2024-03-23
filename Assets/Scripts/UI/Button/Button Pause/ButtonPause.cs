using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : ErshenMonoBehaviour
{
    [Header("---Connect Ctrl---")]
    [SerializeField] protected ButtonPauseCtrl buttonPauseCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadButtonPauseCtrl();
    }

    protected virtual void LoadButtonPauseCtrl()
    {
        if (buttonPauseCtrl != null) return;
        buttonPauseCtrl = transform.GetComponent<ButtonPauseCtrl>();
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

        //buttonPauseCtrl.TWPanelPasue.TW_PanelPasueOff();

        buttonPauseCtrl.CanvasController.SaveDataManager.ResetGame();
        Debug.Log("restart game");
    }
}
