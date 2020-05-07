using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateCards : MonoBehaviour {

    [SerializeField] GameController gameController;

    public void AddDateCardsToDeck() {

        gameController.AddDateCard("Date", 1, "Date Me B*tch", "Choose someone who will have the unfortunate opportunity of drinking everytime you drink through the remaining duration of the game");

    }

}