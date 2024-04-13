using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MangerOfVolume : MonoBehaviour
{

    Slider slider;
    GameObject MusicManager;
    AudioSource soundtrackPlayer;
    private void Start()
    {
        MusicManager = GameObject.FindWithTag("Music");
        soundtrackPlayer = MusicManager.GetComponent<AudioSource>();
        slider = this.GetComponent<Slider>();
    }

    private void Update()
    {
        soundtrackPlayer.volume = slider.value;
    }
}
