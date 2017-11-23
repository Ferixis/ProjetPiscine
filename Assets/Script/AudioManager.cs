using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource explosionAudio;
    public AudioSource powerUpSource;

    public static AudioManager Instance { get; private set; }

    public void Awake()
    {
        Instance = this;
    }

    public void PlayExplosion()
    {
        explosionAudio.Play();
    }

    public void PlayPowerUp()
    {
        powerUpSource.Play();
    }
}
