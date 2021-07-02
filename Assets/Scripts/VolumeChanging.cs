using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class VolumeChanging : MonoBehaviour
{
    [SerializeField] private float _speedOfChanging;
    private AudioSource _source;
    private float _endVolume;
    private Coroutine _changeVolume;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        if (_changeVolume != null)
        {
            StopCoroutine(_changeVolume);
        }

        _endVolume = 1f;
        _changeVolume = StartCoroutine(ChangeVolume(_endVolume));
    }

    public void StopSound()
    {
        StopCoroutine(ChangeVolume(_endVolume));
        _endVolume = 0f;
        _changeVolume = StartCoroutine(ChangeVolume(_endVolume));
    }

    private IEnumerator ChangeVolume(float endVolume)
    {
        while (endVolume != _source.volume)
        {
            _source.volume = Mathf.MoveTowards(_source.volume, _endVolume, _speedOfChanging * Time.deltaTime);
            yield return null;
        }
    }
}
