using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public List<AudioTrack> soundFX = new List<AudioTrack>();
    public List<AudioTrack> musicSoundtrack = new List<AudioTrack>();

    AudioSource efxSource;

    public static AudioManager Instance
    {
        get;
        private set;
    }

    void Awake()
    {
        // First we check if there are any other instances conflicting
        if (Instance != null && Instance != this)
        {
            // If that is the case, we destroy other instances            
            Destroy(gameObject);
        }

        // Here we save our singleton instance
        Instance = this;

        // Furthermore we make sure that we don't destroy between scenes (this is optional)
        //DontDestroyOnLoad(gameObject);
        efxSource = GetComponent<AudioSource>();
    }

    void LoadAudioClip(string name)
    {
        efxSource.clip = soundFX[GetSFXName(name)].clip;
    }

    public void PlayClip(string name)
    {
        StopClip();
        LoadAudioClip(name);
        efxSource.Play();
    }

    public void StopClip() {
        efxSource.Stop();
    }

    int GetSFXName(string _name) {
        for (int i = 0; i < soundFX.Count; i++) {
            if (_name == soundFX[i].name)
                return i;
        }
        return -1;
    }

    public AudioClip GetSFXClip(string _name) {
        for (int i = 0; i < soundFX.Count; i++) {
            if (_name == soundFX[i].name)
                return soundFX[i].clip;
        }
        return null;
    }


    public AudioTrack GetMusicTrack(string _name)
    {
        for (int i = 0; i < musicSoundtrack.Count; i++)
        {
            if (_name == musicSoundtrack[i].name)
                return musicSoundtrack[i];
        }
        throw new System.Exception("Album track does NOT exist");
    }


} // end class AudioManager


[System.Serializable]
public struct AudioTrack {
    public string name;
    public AudioClip clip;
}