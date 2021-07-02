using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class VolumeChanging : MonoBehaviour
{
    private AudioSource _source;
    private float _volume;
    private float _startVolume;
    private float _endVolume;
    private Coroutine _changeVolume;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        if (_changeVolume!=null)
        {
            StopCoroutine(_changeVolume);
        }

        _startVolume = _source.volume;
        _endVolume = 1f;
        _changeVolume=StartCoroutine(ChangeVolume(_endVolume));
    }

    public void StopSound()
    {
        StopCoroutine(_changeVolume);
        _startVolume = _source.volume;
        _endVolume =0f;
        _changeVolume= StartCoroutine( ChangeVolume(_endVolume));
    }

    private IEnumerator ChangeVolume(float endVolume)
    {
        _volume = 0;
        
        while (endVolume!=_source.volume)
        {
                _volume +=Time.deltaTime;
                _source.volume = Mathf.Lerp(_startVolume, _endVolume, _volume);
                yield return null;
        } 
    }
}
