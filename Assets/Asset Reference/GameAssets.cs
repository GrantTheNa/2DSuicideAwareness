using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    [SerializeField] List<MyAudioClip> _audioBank;

    public static GameAssets _instance;

    private void Awake()
    {
        _instance = this;
    }

    public AudioClip GetAudioClip(string name)
    {
        foreach (MyAudioClip clip in _audioBank)
        {
            if (string.Compare(clip._name, name) == 0)
            {
                return clip._audioClip;
            }
        }
        return null;
    }
}
