using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;
    private AudioSource audioSource;
    public AudioClip[] clips;

    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    void Start() {
        clips = Resources.LoadAll<AudioClip>("Music");
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
    }

    // Update is called once per frame
    void Update() {
        if (!audioSource.isPlaying) {
            audioSource.clip = clips[Random.Range(0, clips.Length)];
            audioSource.Play();
        }
    }
}
