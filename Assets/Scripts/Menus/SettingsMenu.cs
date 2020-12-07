using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider soundFXSlider;
    public Toggle muteToggle;

    private void Start()
    {
        LoadPlayerPrefs();
    }

    /// <summary>
    /// Change Music volume using slider.
    /// </summary>
    /// <param name="volume"></param>
    public void ChangeMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    /// <summary>
    /// Change SoundFX volume using slider.
    /// </summary>
    /// <param name="volume"></param>
    public void ChangeSoundFXVolume(float volume)
    {
        audioMixer.SetFloat("SoundFXVolume", volume);
    }

    /// <summary>
    /// Mute all audio sources.
    /// </summary>
    /// <param name="isMuted"></param>
    public void ChangeMuteSetting(bool isMuted)
    {
        if (isMuted)
        {
            audioMixer.SetFloat("MutedVolume", -80);
        }
        else
        {
            audioMixer.SetFloat("MutedVolume", 0);
        }
    }

    /// <summary>
    /// Load info from player prefs.
    /// </summary>
    public void LoadPlayerPrefs()
    {
        //load audio Sliders
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            float musicVolume = PlayerPrefs.GetFloat("MusicVolume");
            musicSlider.value = musicVolume;
            audioMixer.SetFloat("MusicVolume", musicVolume);
        }
        if (PlayerPrefs.HasKey("SoundFXVolume"))
        {
            float soundFXVolume = PlayerPrefs.GetFloat("SoundFXVolume");
            soundFXSlider.value = soundFXVolume;
            audioMixer.SetFloat("SoundFXVolume", soundFXVolume);
        }

        if (PlayerPrefs.HasKey("MuteVolume"))
        {
            if (PlayerPrefs.GetInt("MuteVolume") == 0)
            {
                muteToggle.isOn = false;
            }
            else
            {
                muteToggle.isOn = true;
            }
        }

    }

    /// <summary>
    /// Save info to using player prefs.
    /// </summary>
    public void SavePlayerPrefs()
    {
        float musicVolume;
        if (audioMixer.GetFloat("MusicVolume", out musicVolume))
        {
            PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        }

        float soundFXVolume;
        if (audioMixer.GetFloat("SoundFXVolume", out soundFXVolume))
        {
            PlayerPrefs.SetFloat("SoundFXVolume", soundFXVolume);
        }

        if (muteToggle.isOn)
        {
            PlayerPrefs.SetInt("MuteVolume", 1);
        }
        else
        {
            PlayerPrefs.SetInt("MuteVolume", 0);
        }

        PlayerPrefs.Save();
    }
}
