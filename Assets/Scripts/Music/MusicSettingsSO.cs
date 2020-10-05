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

    [Tooltip("0: mute, 1: 33%, 2: 66%, 3: max"),Range(0, 3)]
    public int initialGeneralVolume = 2;
    public VolumeState state = VolumeState.eAllActive;

    [NonSerialized]
    public float initialSFXVolume = 0;
    [NonSerialized]
    public float initialMusicVolume = 0;
    [NonSerialized]
    public int generalVolume = 2;
    [NonSerialized]
    public bool mustInitialize = true;
}
