using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsScript : MonoBehaviour {

    public AudioMixer audiomixer;

    public void SetVolume(float volume)
    {
        audiomixer.SetFloat("MusicVol", Mathf.Log10 (volume) * 20);
    }

    public void SetEffectVolume(float volume2)
    {
        audiomixer.SetFloat("EffectVol", Mathf.Log10(volume2) * 20);
    }
}
