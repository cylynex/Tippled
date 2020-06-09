using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruthOrChugCards : MonoBehaviour {

    [SerializeField] GameController gameController;

    public void AddCardsToDeck() {

        gameController.AddCardToDeck(CardsManager.chugCards, "Truth or Chug", 1, "Truth or Chug", "Ask somebody in the room any question you want.  They have to answer truthfully or take a nice long chug.");
    }

}