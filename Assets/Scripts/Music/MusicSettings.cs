using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSettings : MonoBehaviour
{
    public MusicSettingsSO settings;

    // Start is called before the first frame update
    void Start()
    {
        if (settings.mustInitialize)
        {
            settings.state = MusicSettingsSO.VolumeState.eAllActive;
            settings.generalVolume = settings.initialGeneralVolume;
            SoundManager.Instance.masterMixer.GetFloat("MusicVolume", out settings.initialMusicVolume);
            SoundManager.Instance.masterMixer.GetFloat("SfxVolume", out settings.initialSFXVolume);
            settings.mustInitialize = false;
        }

        SoundManager.Instance.SetMasterVolume(settings.generalVolume);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            settings.state = (MusicSettingsSO.VolumeState)( ((int)settings.state + 1) % 3 );
        }

        if (Input.GetKey(KeyCode.Plus) || Input.GetKey(KeyCode.KeypadPlus))
        {
            settings.generalVolume = Mathf.Clamp(settings.generalVolume + (settings.generalVolumeIncrement * Time.deltaTime), 0.0001f, 1);
            SoundManager.Instance.SetMasterVolume(settings.generalVolume);
        }

        if (Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.KeypadMinus))
        {
            settings.generalVolume = Mathf.Clamp(settings.generalVolume - (settings.generalVolumeIncrement * Time.deltaTime), 0.0001f, 1);
        }

        switch (settings.state)
        {
        case MusicSettingsSO.VolumeState.eAllActive:
            SoundManager.Instance.masterMixer.SetFloat("MusicVolume", settings.initialMusicVolume);
            SoundManager.Instance.masterMixer.SetFloat("SfxVolume", settings.initialSFXVolume);
            break;
        case MusicSettingsSO.VolumeState.eMusicMuted:
            SoundManager.Instance.masterMixer.SetFloat("MusicVolume", -80f);
            break;
        case MusicSettingsSO.VolumeState.eAllMuted:
            SoundManager.Instance.masterMixer.SetFloat("SfxVolume", -80f);
            break;
        }

        SoundManager.Instance.SetMasterVolume(settings.generalVolume);
    }
}
