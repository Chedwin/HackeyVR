using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{

    public AudioSource efxSource;
    public AudioSource musicSource;

    public static AudioManager Instance
    {
        get;
        private set;
    }

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    //private void Start()
    //{
    //    musicSource.Play();
    //}

    //public void PlaySingle(AudioClip clip) {

    //}

    
	

} // end class AudioManager
