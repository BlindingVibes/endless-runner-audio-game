using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UserSettings : MonoBehaviour
{
    public AudioMixer gameMixer;
    public AudioMixer menuMixer;

    #region input components
    // Volume sliders
    public Slider masterSlider;
    public Slider bacgroundMusicSlider;
    public Slider assistiveSoundsSlider;
    public Slider soundEffectsSlider;

    // Game mode toggles
    public Toggle audioToggle;
    public Toggle hapticToggle;
    public Toggle visualToggle;
    #endregion

    #region local storage variables
    // Current volumes
    private float master;
    private float backgroundMusic;
    private float assistiveSounds;
    private float soundEffects;
    #endregion

    private void Start()
    {
        if (UAP_AccessibilityManager.IsEnabled()) menuMixer.SetFloat("Navigation volume", -80);
        else menuMixer.SetFloat("Navigation volume", 0);

        LoadSettings();
    }

    public void SetMasterVolume(float volume)
    {
        gameMixer.SetFloat("Game master volume", volume);
        menuMixer.SetFloat("Menu master volume", volume);
        master = volume;
    } 

    public void SetBackgroundMusic(float volume)
    {
        menuMixer.SetFloat("Menu master volume", volume);
        gameMixer.SetFloat("Background music volume", volume);
        backgroundMusic = volume;
    }
    
    public void SetAssistiveSoundsVolume(float volume)
    {
        gameMixer.SetFloat("Assistive sounds volume", volume);
        assistiveSounds = volume;
    }

    public void SetSoundEffectsVolume(float volume)
    {
        gameMixer.SetFloat("Sound effects volume", volume);
        soundEffects = volume;
    }

    public void SaveSettings()
    {
        // Save audio settings
        PlayerPrefs.SetFloat("master volume", master);
        PlayerPrefs.SetFloat("background music volume", backgroundMusic);
        PlayerPrefs.SetFloat("assistive sounds volume", assistiveSounds);
        PlayerPrefs.SetFloat("sound effects volume", soundEffects);
    }

    public void LoadSettings()
    {
        masterSlider.value = PlayerPrefs.GetFloat("master volume", 0);
        bacgroundMusicSlider.value = PlayerPrefs.GetFloat("background music volume", 0);
        assistiveSoundsSlider.value = PlayerPrefs.GetFloat("assistive sounds volume", 0);
        soundEffectsSlider.value = PlayerPrefs.GetFloat("sound effects volume", 0);
    }

    public void RevertChanges()
    {
        LoadSettings();
    }
}
