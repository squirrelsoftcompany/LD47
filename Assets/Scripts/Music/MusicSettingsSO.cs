using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicSettingsSO", menuName = "SO/Music/Settings")]
public class MusicSettingsSO : ScriptableObject
{
    public enum VolumeState
    {
        eAllActive,
        eMusicMuted,
        eAllMuted
    }

    public float initialGeneralVolume = 0.5f;
    public float generalVolumeIncrement = 0.1f;
    public VolumeState state = VolumeState.eAllActive;

    [NonSerialized]
    public float initialSFXVolume = 0;
    [NonSerialized]
    public float initialMusicVolume = 0;
    [NonSerialized]
    public float generalVolume = 0.5f;
    [NonSerialized]
    public bool mustInitialize = true;
}
