using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour {
    public GameObject settingsPanel;
    public GameObject playerInteractField;
    public Button settingsButton;

    public AudioClip toggleAudio;
    public Slider backgroundAudioSlider;
    public Toggle backgroundAudioToggle;
    public Slider soundEffectSlider;
    public Toggle soundEffectToggle;
    
    private void Start()
    {
        float backgroundAudioVolumeNow = PlayerPrefs.GetFloat("backgroundAudioVolume");
        if (backgroundAudioVolumeNow > 0)
        {
            backgroundAudioToggle.isOn = true;
            backgroundAudioSlider.interactable = true; 
            backgroundAudioSlider.value = backgroundAudioVolumeNow;
        }
        else
        {
            backgroundAudioSlider.value = PlayerPrefs.GetFloat("backgroundAudioVolumeSaved");
            backgroundAudioToggle.isOn = false;
            backgroundAudioSlider.interactable = false;
        }

        float soundEffectVolumeNow = PlayerPrefs.GetFloat("soundEffectVolume");
        if (soundEffectVolumeNow > 0)
        {
            soundEffectToggle.isOn = true;
            soundEffectSlider.interactable = true;
            soundEffectSlider.value = soundEffectVolumeNow;
        }
        else
        {

            soundEffectSlider.value = PlayerPrefs.GetFloat("soundEffectVolumeSaved");
            soundEffectToggle.isOn = false;
            soundEffectSlider.interactable = false;
        }

        PlayerPrefs.SetInt("isChangingScene", 0);
    }
    

    public void PlayToggleAudio()
    {
        if (PlayerPrefs.GetInt("isChangingScene", 0) != 1)
        {
            AudioSource.PlayClipAtPoint(toggleAudio, Vector3.zero, PlayerPrefs.GetFloat("soundEffectVolume"));
        }
    }

    public void AdjustBackgroundAudioVolume()
    {
        PlayerPrefs.SetFloat("backgroundAudioVolume", backgroundAudioSlider.value);
        PlayToggleAudio();
    }

    public void HandleBackgroundAudioSlider()
    {
        if (backgroundAudioSlider.interactable == true)
        {
            backgroundAudioSlider.interactable = false;
            PlayerPrefs.SetFloat("backgroundAudioVolumeSaved", backgroundAudioSlider.value);
            PlayerPrefs.SetFloat("backgroundAudioVolume", 0f);
        }
        else
        {
            backgroundAudioSlider.interactable = true;
            PlayerPrefs.SetFloat("backgroundAudioVolume", backgroundAudioSlider.value);
        }
    }

    public void AdjustSoundEffectVolume()
    {
        PlayerPrefs.SetFloat("soundEffectVolume",soundEffectSlider.value);
        PlayToggleAudio();
    }

    public void HandleSoundEffectSlider()
    {
        if (soundEffectSlider.interactable == true)
        {
            soundEffectSlider.interactable = false;
            PlayerPrefs.SetFloat("soundEffectVolumeSaved", soundEffectSlider.value);
            PlayerPrefs.SetFloat("soundEffectVolume", 0f);
        }
        else
        {
            soundEffectSlider.interactable = true;
            PlayerPrefs.SetFloat("soundEffectVolume", soundEffectSlider.value);
        }
    }

    public void ActiveSettingsPanel() {
        settingsPanel.SetActive(true);
        playerInteractField.SetActive(false);
        settingsButton.gameObject.SetActive(false);
        PlayerPrefs.SetInt("isSetting", 1);
    }
    public void DeactiveSettingsPanel()
    {
        settingsPanel.SetActive(false);
        playerInteractField.SetActive(true);
        settingsButton.gameObject.SetActive(true);
        PlayerPrefs.SetInt("isSetting", 0);
    }


}
