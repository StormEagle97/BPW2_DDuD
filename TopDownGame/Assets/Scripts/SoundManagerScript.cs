using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

    public AudioClip ZombieImpactSound;
    public AudioClip playerDamageSound;
    public AudioClip newWaveSound;

    private AudioSource m_AudioSource;

    public bool zombieHit = false;
    public bool addWaveSound = false;

    void Start () {
        m_AudioSource = GetComponent<AudioSource>();
    }

    void Update () {
		
	}
    public void ZombieHit()
    {
        if (zombieHit)
        {
            m_AudioSource.PlayOneShot(ZombieImpactSound);
            zombieHit = false;
        }

    }
    public void PlayerDamageSound()
    {
        m_AudioSource.PlayOneShot(playerDamageSound);
    }

    public void StartWaveSound()
    {
        if (addWaveSound)
        {
            m_AudioSource.PlayOneShot(newWaveSound);
            StartCoroutine(DisableWaveSound());
        }

    }

    IEnumerator DisableWaveSound()
    {
        if (addWaveSound)
        {
            yield return new WaitForSeconds(4);
            addWaveSound = false;
        }
    }
}
