using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameButtons : MonoBehaviour {

    [SerializeField] GameObject thisPanel;

    public void RevealAnswer() {
        thisPanel.SetActive(false);
    }

    public void MuteSounds() {
        AudioSource music = GameObject.FindGameObjectWithTag("Sound Manager").GetComponent<AudioSource>();
        if (music.volume == 0) {
            music.volume = 1;
        } else {
            music.volume = 0;
        }
    }

    public void RemovePlayer() {

        string deleteMe = GetComponent<Text>().text;
        GameController.players.Remove(deleteMe);
        GameController.numberOfPlayers--;
        print(GameController.players.Count);
        Destroy(gameObject);
    }

}
