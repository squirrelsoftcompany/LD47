using UnityEngine;
using System.Collections;


public class SoundEffectsManager : MonoBehaviour
{

    public static SoundEffectsManager Instance;

    public AudioSource OneShotAudioSource;

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
        OneShotAudioSource.PlayOneShot(originalClip);
    }
}
