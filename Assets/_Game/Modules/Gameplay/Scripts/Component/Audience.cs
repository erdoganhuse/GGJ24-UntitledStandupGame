using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Library.SignalBusSystem;
using Modules.Gameplay;

public class Audience : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource AudioSourcePrefab;

    void Start()
    {
        SignalBus.Subscribe<MusicKeyBlastedSignal>(OnMusicKeyBlasted);
    }

    private void OnMusicKeyBlasted(MusicKeyBlastedSignal signal)
    {
        var go = Instantiate(AudioSourcePrefab);
        go.GetComponent<AudioSource>().clip = clips[Random.Range(0,clips.Length)];
        go.GetComponent<AudioSource>().Play();
    }
}
