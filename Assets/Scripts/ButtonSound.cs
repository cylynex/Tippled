using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour {

    AudioSource audioSource;
    [SerializeField] float timeToPlay = 0.4f;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        Invoke("PlaySound", timeToPlay);
    }

    void PlaySound() {
        audioSource.Play();
    }

}
