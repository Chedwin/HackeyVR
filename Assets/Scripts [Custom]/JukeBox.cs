using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JukeBox : MonoBehaviour {

    public List<AlbumCover> soundtrack;
    public AudioSource jukebox;
    List<AudioTrack> tracks = new List<AudioTrack>();

    int currentlyIndex = 0;
    bool isMusicPlaying = false;
    public Sprite defaultCover;

    public Image albumCoverHolder;

    static JukeBox Instance;

    [Tooltip("Should the music start on awake?")]
    public bool startOnAwake = false;

	// Use this for initialization
	void Awake () {

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject); 

        if (soundtrack == null)
            soundtrack = new List<AlbumCover>();     
	}

    void Start()
    {
        isMusicPlaying = false;

        foreach (AudioTrack aud in AudioManager.Instance.musicSoundtrack)
            tracks.Add(aud);

        if (startOnAwake)
            RandomSong();
    }

    void RandomSong()
    {
        int rand = Random.Range(0, soundtrack.Count);

        if (rand == soundtrack.Count)
            SetAlbumCover(ref defaultCover);
        else {
            currentlyIndex = rand;
            PlaySong();
        }
            
    }

    void SetAlbumCover(ref Sprite _cover)
    {
        albumCoverHolder.sprite = _cover;
    }

    void LoadTrack(ref AudioTrack _track)
    {
        jukebox.clip = _track.clip;
    }

    public void PrevSong()
    {
        currentlyIndex--;
        if (currentlyIndex < 0)
            currentlyIndex = tracks.Count - 1;

        isMusicPlaying = false;
        PlaySong();
    }

    public void NextSong()
    {
        currentlyIndex++;
        if (currentlyIndex > tracks.Count - 1)
            currentlyIndex = 0;

        isMusicPlaying = false;
        PlaySong();
    }

    public void PauseSong()
    {
        isMusicPlaying = false;
        jukebox.Pause();
    }

    public void PlaySong()
    {
        if (isMusicPlaying)
            return;

        isMusicPlaying = true;

        AudioTrack a = AudioManager.Instance.GetMusicTrack(soundtrack[currentlyIndex].name);
        LoadTrack(ref a);
        Sprite spr = soundtrack[currentlyIndex].albumCover;
        SetAlbumCover(ref spr);
        jukebox.Play();
    }

} //  end class JukeBox


[System.Serializable]
public struct AlbumCover
{
    public string name;
    public Sprite albumCover;
}