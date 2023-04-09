using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _source;

    [SerializeField] private AudioClip _buttonSound;
    [SerializeField] private AudioClip _wing;
    [SerializeField] private AudioClip _hit;
    [SerializeField] private AudioClip _point;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void PlayButtonSound() => _source.PlayOneShot(_buttonSound);
    public void PlayWingSound() => _source.PlayOneShot(_wing);
    public void PlayHitSound() => _source.PlayOneShot(_hit);
    public void PlayPointSound() => _source.PlayOneShot(_point);

    public void AdjustSoundVolume(float value)
    {
        PlayerPrefs.SetFloat(PlayerPrefsConsts.SOUND_VOLUME, value);
        _source.volume = value / 10;
    }
}
