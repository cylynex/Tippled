using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class ImportCards : MonoBehaviour {

    [SerializeField] TextAsset cardData;

    string[] linesFromFile;

    private void Start() {
        print("ok lets read some god damned cards");

        foreach (string file in System.IO.Directory.GetFiles("Resources/BaseDecks/")) {
            print("reading files now");
        }

        cardData = Resources.Load("BaseDecks/ActionCardDeck") as TextAsset;
        linesFromFile = cardData.text.Split("\n"[0]);
        
        foreach(string line in linesFromFile) {
            string[] cardDataArray;
            cardDataArray = line.Split(","[0]);
            DeckManager.baseCards.Add(GetCardData(cardDataArray));
        }

        print("Total Cards Found: " + DeckManager.baseCards.Count);
        
    }

    Card GetCardData(string[] cardDataArray) {
        Card thisCard = new Card();
        thisCard.cardCategory = cardDataArray[0];
        thisCard.stages = Convert.ToInt32(cardDataArray[1]);
        thisCard.cardTitle = cardDataArray[2];
        thisCard.cardText = cardDataArray[3];
        if (cardDataArray.Length >= 5) {
            thisCard.cardAnswer = cardDataArray[4];
        }
        return thisCard;
    }
}
