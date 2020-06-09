using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruthOrChugCards : MonoBehaviour {

    [SerializeField] GameController gameController;

    public void AddCardsToDeck() {

        gameController.AddCardToDeck(CardsManager.chugCards, "Truth or Chug", 1, "Truth or Chug", "I don't know what this is supposed to say lol");
    }

}