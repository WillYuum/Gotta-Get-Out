using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.GenericSingletons;

public class AudioManager : MonoBehaviourSingleton<AudioManager>
{
    public bool BGMIsMuted { get; private set; }
    public bool SFXIsMuted { get; private set; }


    [SerializeField] private Audio[] allSFX;
    [SerializeField] private Audio BGM;

    public void LoadAudioToGame()
    {
        LoadSFX();
        LoadBGM();
        print("Loaded All audio");
    }

    private void LoadSFX()
    {
        if (allSFX.Length == 0) return;

        foreach (Audio s in allSFX)
        {
            GameObject spawnedObject = Instantiate(new GameObject(), transform);
            spawnedObject.name = s.audioName;
            s.source = spawnedObject.AddComponent<AudioSource>();

            s.LoadAudioToGame();
        }
    }

    private void LoadBGM()
    {
        if (BGM.audioName == "") return;

        GameObject spawnedObject = Instantiate(new GameObject(), transform);
        spawnedObject.name = BGM.audioName;
        BGM.source = spawnedObject.AddComponent<AudioSource>();

        BGM.LoadAudioToGame();

    }


    public void PlaySFX(string _sfxName)
    {
        if (SFXIsMuted) return;

        Audio s = Array.Find(allSFX, item => item.audioName == _sfxName);
        if (s == null)
        {
            Debug.LogWarning("Audio: " + _sfxName + " not found! ");
            return;
        }

        PlayAudio(s);
    }

    public void StopSFX(string _sfxName)
    {
        Audio s = Array.Find(allSFX, item => item.audioName == _sfxName);
        if (s == null)
        {
            Debug.LogWarning("Audio: " + _sfxName + " not found! ");
            return;
        }

        StopAudio(s);
    }

    private void PlayAudio(Audio audio)
    {
        if (audio == null)
        {
            Debug.LogWarning("Play audio warning: Null reference to audio");
            return;
        }

        audio.source.volume = audio.volume;
        audio.source.loop = audio.loop;
        audio.source.Play();
    }

    private void StopAudio(Audio audio)
    {
        audio.source.Stop();
    }



    [System.Serializable]
    public class Audio
    {
        [SerializeField] public string audioName;

        [SerializeField] public bool loop;
        [SerializeField] public AudioClip clip;

        [Range(0f, 1.0f)]
        [SerializeField] public float volume = 1.0f;


        [HideInInspector] public AudioSource source;

        public void LoadAudioToGame()
        {
            source.volume = volume;
            source.clip = clip;
            source.loop = loop;
        }

        public void SetVolume(float volume) => source.volume = volume;
    }
}
