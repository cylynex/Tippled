using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGameOverLog : MonoBehaviour {

    private void Start() {
        GameController.gameNumber++;
        print("End of Game Stats:");
        print("Number of Games: " + GameController.gameNumber);
        print("Inconveniences: " + GameController.inconvenienceNumber);
        print("Actions: " + GameController.actionNumber);
        print("Specials: " + GameController.specialNumber);
        print("H2H: " + GameController.headtoheadNumber);
        print("Trivia: " + GameController.triviaNumber);
    }

}
