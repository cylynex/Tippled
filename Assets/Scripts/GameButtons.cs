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

        print("Remove a Player now");
        print(GameController.players.Count);
        string deleteMe = GetComponent<Text>().text;
        print(deleteMe);
        GameController.players.Remove(deleteMe);
        GameController.numberOfPlayers--;
        print("Should have deleted now");
        print(GameController.players.Count);

        Destroy(gameObject);
    }

}
