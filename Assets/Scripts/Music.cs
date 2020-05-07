using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    static Music instance = null;

    private void Awake() {
        
        if (instance != null) { 
            Destroy(gameObject);
        } else {
            instance = this;
            //GameObject.DontDestroyOnLoad(GetComponent<AudioSource>();
            //GameObject.DontDestroyOnLoad();
            DontDestroyOnLoad(GetComponent<AudioSource>());
        }

        // Turn Music On
        if (GameObject.FindGameObjectWithTag("Sound Manager")) {
            GameObject.FindGameObjectWithTag("Sound Manager").GetComponent<AudioSource>().volume = 1;
        }
    }
      
}
