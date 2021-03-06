using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    

    public Sound[] sounds;
    // Start is called before the first frame update
    public static AudioManager instance;


    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Play("Theme");
        }
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            
            Play("PlayGround");
        }
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            Play("AlleyWay");
        }
       
    }

    void Awake()
    {
        
        /*if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);*/
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.group;
        }
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
}
