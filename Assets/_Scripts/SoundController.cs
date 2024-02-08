using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private GameObject _on;
    [SerializeField] private GameObject _off;

    private void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("music", 1);
        if (AudioListener.volume == 0)
        {
            _on.SetActive(false);
            _off.SetActive(true);
        }
        else if (AudioListener.volume == 1)
        {
            _off.SetActive(false);
            _on.SetActive(true);
        }
    }

    public void MuteMusic()
    {
        _on.SetActive(false);
        _off.SetActive(true);
        AudioListener.volume = 0;
        Debug.Log(AudioListener.volume);
        PlayerPrefs.SetFloat("music", AudioListener.volume);
    }

    public void UnMuteMusic()
    {
        _off.SetActive(false);
        _on.SetActive(true);
        AudioListener.volume = 1;
        PlayerPrefs.SetFloat("music", AudioListener.volume);
    }
}
