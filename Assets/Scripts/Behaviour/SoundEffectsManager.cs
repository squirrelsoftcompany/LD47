﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Création d'effets sonores en toute simplicité
/// </summary>
public class SoundEffectsManager : MonoBehaviour
{

    /// <summary>
    /// Singleton
    /// </summary>
    public static SoundEffectsManager Instance;

    public AudioClip dashSound;
    public AudioClip hurtSound;
    public AudioClip slideSound;
    public AudioClip supporterSound;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffectsManager!");
        }
        Instance = this;
    }

    public void MakeDashSound()
    {
        MakeSound(dashSound);
    }

    public void MakeHurtSound()
    {
        MakeSound(hurtSound);
    }

    public void MakeSlideSound()
    {
        MakeSound(slideSound);
    }

    public void MakeSupporterSound()
    {
        MakeSound(supporterSound);
    }


    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}