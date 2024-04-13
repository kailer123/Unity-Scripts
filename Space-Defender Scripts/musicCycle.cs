using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SoundtrackManager : MonoBehaviour
{
    public AudioClip[] soundtracks;
    public AudioClip menuMusic;
    public AudioSource audioSource;
    int currentSoundtrackIndex = 0;
    Scene currentScene;

    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        int sceneIndex = currentScene.buildIndex;

        switch (sceneIndex)
        {
            case 0:
                if (audioSource.isPlaying == false || audioSource.clip != menuMusic)
                {
                    PlayMenu();
                }
                break;
            case 1:
                if (audioSource.isPlaying == false || audioSource.clip == menuMusic)
                {
                    PlayNextSoundtrack();
                }
                break;
        }
    }
    void PlayNextSoundtrack()
    {
        currentSoundtrackIndex = (currentSoundtrackIndex + 1) % soundtracks.Length;
        audioSource.clip = soundtracks[currentSoundtrackIndex];
        audioSource.Play();
    }

    void PlayMenu()
    { 
        audioSource.clip = menuMusic;
        audioSource.Play();
    }
}