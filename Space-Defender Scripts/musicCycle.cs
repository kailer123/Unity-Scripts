using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundtrackManager : MonoBehaviour
{
    public AudioClip[] soundtracks;
    private AudioSource audioSource;
    private int currentSoundtrackIndex = 0;

    
    void Start()
    {
        // Get the AudioSource component attached to the GameObject
        audioSource = GetComponent<AudioSource>();

        // Check if any soundtracks are assigned
        if (soundtracks.Length > 0)
        {
            // Start playing the first soundtrack
            PlayNextSoundtrack();
        }
        else
        {
            Debug.LogError("No soundtracks assigned to the SoundtrackManager!");
        }
    }


    void Update()
    {
        // Check if the current soundtrack has finished playing
        if (!audioSource.isPlaying)
        {
            // Move to the next soundtrack
            PlayNextSoundtrack();
        }
    }

    void PlayNextSoundtrack()
    {
        // Increment the index to play the next soundtrack
        currentSoundtrackIndex = (currentSoundtrackIndex + 1) % soundtracks.Length;

        // Set the next soundtrack to play
        audioSource.clip = soundtracks[currentSoundtrackIndex];

        // Play the next soundtrack
        audioSource.Play();
    }
}