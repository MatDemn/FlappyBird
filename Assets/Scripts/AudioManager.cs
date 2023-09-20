using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioSource pointAudioSource;
    [SerializeField] AudioSource gameOverAudioSource;
    [SerializeField] AudioSource flapAudioSource;

    private void Start()
    {
        GManager.Instance.onScoreChange += (_) => PlayPointAudioSource();
        GManager.Instance.onGameOver += PlayGameOverAudioSource;
        Player.onFlapEvent += PlayFlapAudioSource;
    }

    public void PlayPointAudioSource()
    {
        pointAudioSource.Play();
    }

    public void PlayGameOverAudioSource()
    {
        gameOverAudioSource.Play();
    }

    public void PlayFlapAudioSource()
    {
        flapAudioSource.Play();
    }
}
