using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCards : MonoBehaviour {

    [SerializeField] GameController gameController;

    public void AddCardsToDeck() {

        // Specials
        gameController.AddCardToDeck(CardsManager.specialCards, "Special", 1, "Pink Flllloyyyyd", "Why does a flamingo stand on one leg?  Who the hell knows!!  Everyone replicate that bird and honor it with a one leg chug.");
        gameController.AddCardToDeck(CardsManager.specialCards, "Special", 1, "Waterfall", "Everyone start drinking at the same time.  Starting with you, stop whenever you want.  Everyone around cannot stop pulling until the person before them does (or they run out of drink).");
        gameController.AddCardToDeck(CardsManager.specialCards, "Special", 1, "Makes No Difference", "Was it sunny out today? It doesn't matter, everybody take a drink!");
        gameController.AddCardToDeck(CardsManager.specialCards, "Special", 1, "LETS GET IT!!!", "Everybody take a big swig.");
        gameController.AddCardToDeck(CardsManager.specialCards, "Special", 1, "Waterfall", "Starting with you, start drinking.  Stop whenever you want.  Nobody stops drinking until the person before them does (or they run out of drink).");
        gameController.AddCardToDeck(CardsManager.specialCards, "Special", 1, "Higher Learning", "Anyone in college right now have a drink.");
        gameController.AddCardToDeck(CardsManager.specialCards, "Special", 1, "Workin for the man", "Anyone who worked today, have a drink.");
        gameController.AddCardToDeck(CardsManager.specialCards, "Special", 1, "Day of the Week", "Is it a weekday? All the fellas drink.  If it's a weekend, bottoms up ladies.");
        gameController.AddCardToDeck(CardsManager.specialCards, "Special", 1, "Seasonal Allergies", "What season is it? Drink appropriately. Fall - 1.  Winter - 2.  Spring - 3.  Summer - 5. Just because.");
        gameController.AddCardToDeck(CardsManager.specialCards, "Special", 1, "None Shall Pass", "Everyone have a drink in honor of the fallen black knight.");
        gameController.AddCardToDeck(CardsManager.specialCards, "Special", 1, "Half a J", "Anyone whose drink is less than half full, stop being a b*tch, finish it, and get a new one.");
        gameController.AddCardToDeck(CardsManager.specialCards, "Special", 1, "Merica", "Everybody take a drink for the good-ole US of A, or where ever you might be from.");
        gameController.AddCardToDeck(CardsManager.specialCards, "Special", 1, "Liberty!", "Everybody take a drink for Liberty and Justice for all!");
        gameController.AddCardToDeck(CardsManager.specialCards, "Special", 1, "Woof Woof", "Who let the dogs out? Nobody wants to admit it, so everybody takes a drink.");
        gameController.AddCardToDeck(CardsManager.specialCards, "Special", 1, "Drink!", "Everybody take a drink!");
        gameController.AddCardToDeck(CardsManager.specialCards, "Special", 1, "Drink!", "Everybody take a drink!");
        gameController.AddCardToDeck(CardsManager.specialCards, "Special", 1, "Drink!", "Everybody take a drink!");
        gameController.AddCardToDeck(CardsManager.specialCards, "Special", 1, "Drink!", "Everybody take a drink!");
        gameController.AddCardToDeck(CardsManager.specialCards, "Special", 1, "Take a sip", "… Yeah we thought you all needed a sip, 1 drink this time");

    }

}