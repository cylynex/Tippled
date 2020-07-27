using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLCManager : MonoBehaviour {

    [SerializeField] TextAsset cardData;
    [SerializeField] GameController gameController;
    [SerializeField] List<string> cardPacks = new List<string>();

    string[] linesFromFile;

    private void Start() {
        Debug.Log(Application.persistentDataPath);
    }

    public void Import() {
        print("Starting DLC Import");
        string gamePath = Application.dataPath;
        string persistentPath = Application.persistentDataPath;
        string streamingPath = Application.streamingAssetsPath;

        foreach (string cardPackName in cardPacks) {
            AssetBundle ab = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, cardPackName)); //sampledlc
            TextAsset abText;

            if (ab == null) {
                Debug.Log("Failed to load AssetBundle (they probably have not purchased it.");
            } else {
                print("Loaded Asset Bundle successfully. " + ab.name);
                abText = ab.LoadAsset<TextAsset>(ab.GetAllAssetNames()[0]);
                print("And now the content we loaded. ");
                linesFromFile = abText.text.Split("\n"[0]);

                print("Number of lines in DLC: " + linesFromFile.Length);
                for (int i = 0; i < linesFromFile.Length; i++) {
                    print(linesFromFile[i]);
                }

                foreach (string line in linesFromFile) {
                    string[] cardDataArray;
                    cardDataArray = line.Split(","[0]);
                    //DeckManager.baseCards.Add(GetCardData(cardDataArray));
                    print("Card Type: " + cardDataArray[0]);

                    switch (cardDataArray[0]) {
                        case "Action": gameController.AddDLCCardToDeck(CardsManager.deckOfCards, GetCardData(cardDataArray)); break;
                        case "Inconvenience": gameController.AddDLCCardToDeck(CardsManager.inconvenienceCards, GetCardData(cardDataArray)); break;
                        case "Special": gameController.AddDLCCardToDeck(CardsManager.specialCards, GetCardData(cardDataArray)); break;
                        default: print("Encountered Error finding a deck for this DLC Card: " + cardDataArray[2] + "(" + cardDataArray[0] + ")"); break;
                    }

                    //gameController.AddDLCCardToDeck(CardsManager.dateCards, GetCardData(cardDataArray));
                }
            }

            ab = null;
            print("import finished for better or for worse");
        }        
    }

    string GetFilename(string inFile) {
        string[] wholeFilename = inFile.Split("/"[0]);
        print("should be a few items here: " + wholeFilename.Length);
        return wholeFilename[wholeFilename.Length - 1];
        
    }

    Card GetCardData(string[] cardDataArray) {
        Card thisCard = new Card();
        thisCard.cardCategory = cardDataArray[0];

        // TODO fix this conversion it needs to work right.
        //thisCard.stages = Convert.ToInt32(cardDataArray[1]);
        
        thisCard.stages = 1;
        thisCard.cardTitle = cardDataArray[2];
        thisCard.cardText = cardDataArray[3];
        if (cardDataArray.Length >= 5) {
            thisCard.cardAnswer = cardDataArray[4];
        }
        return thisCard;
    }

}
