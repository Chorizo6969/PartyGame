using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Musique : MonoBehaviour
{
    [SerializeField] private AudioClip _audioCLip;
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _audioCLip;
        _audioSource.playOnAwake = true;
        _audioSource.loop = true;
        _audioSource.Play();
    }
}
