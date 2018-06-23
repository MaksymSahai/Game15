using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource _sound;
    private AudioClip _audioMove;
    private AudioClip _audioStart;
    private AudioClip _audioSolved;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();

        _audioMove = Resources.Load<AudioClip>("move");
        _audioStart = Resources.Load<AudioClip>("start");
        _audioSolved = Resources.Load<AudioClip>("solved");
    }

    public void PlayMove()
    {
        _sound.PlayOneShot(_audioMove);
    }

    public void PlayStart()
    {
        _sound.PlayOneShot(_audioStart);
    }

    public void PlaySolved()
    {
        _sound.PlayOneShot(_audioSolved);
    }
}
