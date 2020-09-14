using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<AudioManager>();

            return _instance;
        }
    }

    private static AudioManager _instance;

    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip _addGoldClip;

    [SerializeField]
    private AudioClip _buyFx;

    [SerializeField]
    private AudioClip _drumFx;

    [SerializeField] private AudioClip _fireballFx;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void AddGold()
    {
        PlayClip(_addGoldClip);
    }

    public void Buy()
    {
        PlayClip(_buyFx);
    }

    public void Drum()
    {
        PlayClip(_drumFx);
    }

    public void Fireball()
    {
        PlayClip(_fireballFx);
    }

    private void PlayClip(AudioClip clip)
    {
        if(_audioSource.isPlaying)
            _audioSource.Stop();

        _audioSource.PlayOneShot(clip);
    }
}
