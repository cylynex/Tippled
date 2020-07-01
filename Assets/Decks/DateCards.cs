using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateCards : MonoBehaviour {

    [SerializeField] GameController gameController;

    public void AddCardsToDeck() {

        gameController.AddCardToDeck(CardsManager.dateCards, "Date", 1, "Date Me B*tch", "Choose someone who will have the unfortunate opportunity of drinking everytime you drink for the duration of the game");
        //gameController.AddCardToDeck(CardsManager.dateCards, "Date", 1, "Dinner and a movie", "Choose someone to date.  As in they have to drink every time you do.");
        //gameController.AddCardToDeck(CardsManager.dateCards, "Date", 1, "The Party is OVER", "If you are currently dating someone (in the game), you just broke up.  Pick a new dating partner.  Your ex is off the hook!  You drink, your (new) date drinks.");
    }

}