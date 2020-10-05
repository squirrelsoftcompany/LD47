using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance
    {
        get
        {
            return m_instance;
        }
    }
    public static SoundManager m_instance = null;
    public AudioMixer masterMixer;

    // Start is called before the first frame update
    void Start()
    {
        if (m_instance != null)
            Destroy(gameObject);
        else
            m_instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //float maxPitchFactor = Dora.Inst.behaviourSettings.wheelSpeedMax / Dora.Inst.behaviourSettings.wheelSpeedMin;
        float currentPitch = Dora.Inst.gameState.currentWheelSpeed / Dora.Inst.behaviourSettings.wheelSpeedMin;
        float currentBpm = (currentPitch * 60.0f);

        float volume60bpm = ComputeVolume(currentBpm,0,180,6) + ComputeVolume(currentBpm, 240, 3000, 6);
        float volume120bpm = ComputeVolume(currentBpm,120,3000,6);
        float volume240bpm = ComputeVolume(currentBpm,180,3000,6);
        float volume300bpm = ComputeVolume(currentBpm,300,3000,6);


        Set60BpmVolume(Mathf.Lerp(0.0001f, 1f, volume60bpm / 100.0f));
        Set120BpmVolume(Mathf.Lerp(0.0001f, 1f, volume120bpm / 100.0f));
        Set240BpmVolume(Mathf.Lerp(0.0001f, 1f, volume240bpm / 100.0f));
        Set300BpmVolume(Mathf.Lerp(0.0001f, 1f, volume300bpm / 100.0f));
    }

    public void SetMasterVolume(float volume)
    {
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    public void SetSfxVolume(float volume)
    {
        masterMixer.SetFloat("SfxVolume", Mathf.Log10(volume) * 20);
    }

    public void SetMusicVolume(float volume)
    {
        masterMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }

    public void SetMusicPitch(float pitch)
    {
        masterMixer.SetFloat("MusicPitch", pitch/2.0f);
    }

    public void Set60BpmPitch(float pitch)
    {
        masterMixer.SetFloat("60bpmPitch", pitch);
    }

    public void Set120BpmPitch(float pitch)
    {
        masterMixer.SetFloat("120bpmPitch", pitch);
    }

    public void Set240BpmPitch(float pitch)
    {
        masterMixer.SetFloat("240bpmPitch", pitch);
    }

    public void Set300BpmPitch(float pitch)
    {
        masterMixer.SetFloat("300bpmPitch", pitch);
    }

    public void Set60BpmVolume(float volume)
    {
        masterMixer.SetFloat("60bpm", Mathf.Log10(volume) * 20);
    }

    public void Set120BpmVolume(float volume)
    {
        masterMixer.SetFloat("120bpm", Mathf.Log10(volume) * 20);
    }

    public void Set240BpmVolume(float volume)
    {
        masterMixer.SetFloat("240bpm", Mathf.Log10(volume) * 20);
    }
    public void Set300BpmVolume(float volume)
    {
        masterMixer.SetFloat("300bpm", Mathf.Log10(volume) * 20);
    }

    private float ComputeVolume(float currentBpm, float start, float stop, float fade)
    {
        float volume = 0;
        if(currentBpm > start - fade && currentBpm < start + fade)
        {
            float progression = Mathf.InverseLerp(start - fade, start + fade, currentBpm);
            volume = Mathf.Lerp(0.0f, 100.0f, progression);
        }
        else if(currentBpm > start + fade && currentBpm < stop - fade)
        {
            volume = 100;
        }
        else if (currentBpm > stop - fade && currentBpm < stop + fade)
        {
            float progression = Mathf.InverseLerp(stop - fade, stop + fade, currentBpm);
            volume = 100.0f - Mathf.Lerp(0.0f, 100.0f, progression);
        }
        return volume;
    }
}
