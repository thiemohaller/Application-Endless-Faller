using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSlider : MonoBehaviour {
    AudioSource audioSource;
    float volume;

    void Start() {
        volume = 0.4f;
        audioSource = GetComponent<AudioSource>();
    }

    void OnGUI() {
        volume = GUI.HorizontalSlider(new Rect(25, 25, 200, 60), volume, 0.0F, 1.0F);
        audioSource.volume = volume;
    }
}
