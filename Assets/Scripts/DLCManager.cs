using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLCManager : MonoBehaviour {

    [SerializeField] TextAsset cardData;
    [SerializeField] GameController gameController;

    string[] linesFromFile;

    private void Start() {
        Debug.Log(Application.persistentDataPath);
    }

    public void Import() {
        print("STARTING IMPORT FROM IMPORTDLC HERE");

        print("First step - load the asset bundle");
        string gamePath = Application.dataPath;
        string persistentPath = Application.persistentDataPath;
        string streamingPath = Application.streamingAssetsPath;
        /*
        print("Path Data (gamePath): " + gamePath);
        foreach(string file in System.IO.Directory.GetFiles(gamePath)) {
            print(file);
        }
        */
        
        AssetBundle ab = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "quarantini")); //sampledlc
        TextAsset abText;

        if (ab == null) {
            Debug.Log("Failed to load AssetBundle (they probably have not purchased it.");
        } else {
            print("Loaded Asset Bundle successfully. "+ab.name);
            abText = ab.LoadAsset<TextAsset>(ab.GetAllAssetNames()[0]);
            print("And now the content we loaded. ");
            linesFromFile = abText.text.Split("\n"[0]);
            
            print("Number of lines in DLC: " + linesFromFile.Length);
            for(int i = 0; i < linesFromFile.Length; i++) {
                print(linesFromFile[i]);
            }

            foreach (string line in linesFromFile) {
                string[] cardDataArray;
                cardDataArray = line.Split(","[0]);
                //DeckManager.baseCards.Add(GetCardData(cardDataArray));
                print("Card Type: " + cardDataArray[0]);
                
                switch(cardDataArray[0]) {
                    case "Action": gameController.AddDLCCardToDeck(CardsManager.deckOfCards, GetCardData(cardDataArray)); break;
                    case "Inconvenience": gameController.AddDLCCardToDeck(CardsManager.inconvenienceCards, GetCardData(cardDataArray)); break;
                    case "Special": gameController.AddDLCCardToDeck(CardsManager.specialCards, GetCardData(cardDataArray)); break;
                    default: print("Encountered Error finding a deck for this DLC Card: " + cardDataArray[2] + "(" + cardDataArray[0] + ")"); break;
                }

                //gameController.AddDLCCardToDeck(CardsManager.dateCards, GetCardData(cardDataArray));
            }
        }

        ab = null;

        // Dummy DLCs for  Testing
        ab = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "testdlc.testdlc"));
        if (ab == null) {
            Debug.Log("Failed to load AssetBundle (they probably have not purchased it.");
        } else {
            print("Coooool.....we found a DLC pack that doesn't exist....hmmmm....");
        }

        ab = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "testdlc3.testdlc"));
        if (ab == null) {
            Debug.Log("Failed to load AssetBundle (they probably have not purchased it.");
        } else {
            print("Coooool.....we found a DLC pack that doesn't exist....hmmmm....");
        }

        /*
        print("Attempting to load ab now");
        AssetBundle ab = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, "AssetBundles/testdlc.testdlc")); // Your asset-bundle path
        print("Did we find the asset bundle? "+ab.name);
        */
        /*
        TextAsset textAsset = ab.LoadAsset<TextAsset>(ab.GetAllAssetNames()[0]); // In my example I only have 1 file in the asset-bundle, the TextAsset
        print("ABNAME: " + ab + " - " + ab.name);
        print("Asset: " + textAsset.name);
        print("Asset2: " + textAsset.text);

        string[] fileData = textAsset.text.Split("\n"[0]);
        print("number of string items: " + fileData.Length);
        */


        /*
        //foreach (string file in System.IO.Directory.GetFiles("Resources/BaseDecks/")) {
        string filePath = Application.dataPath + "/Resources/DLC/";
        print("Attempting filepath: " + filePath);
        DirectoryInfo levelDirectoryPath = new DirectoryInfo(Application.dataPath);
        TextAsset[] files = Resources.LoadAll<TextAsset>("DLC");
        print("Files found: " + files.Length);
        print("First File name (name): " + files[0].name);
        print("First File name (int): " + files[0]);

        string fileData = files.ToString();
        print("STRING OUTPUT NOW: " + fileData);

        string[] fileDataUsable = fileData.Split("\n"[0]);
        print("Amount of Split data we can use: " + fileDataUsable.Length);
        for(int i = 0; i < fileDataUsable.Length; i++) {
            print("DATASTRING: " + fileDataUsable[i]);
        }


        foreach (string file in System.IO.Directory.GetFiles(filePath)) {

            string extension = file.Substring(Math.Max(0, file.Length - 3));
            print("EXTENSION IS: " + extension);
            if (extension == "csv") {

                print("Found File: " + file);
                string fileName = GetFilename(file);
                string dlcFileName = fileName.Substring(0, fileName.Length - 4);
                string DLCFileName = "DLC/" + dlcFileName;
                print("USING: " + DLCFileName);

                cardData = Resources.Load(DLCFileName) as TextAsset;
                linesFromFile = cardData.text.Split("\n"[0]);

                foreach (string line in linesFromFile) {
                    string[] cardDataArray;
                    cardDataArray = line.Split(","[0]);
                    //DeckManager.baseCards.Add(GetCardData(cardDataArray));
                    gameController.AddDLCCardToDeck(CardsManager.dateCards, GetCardData(cardDataArray));
                }

            } else {
                print("Unneeded File Found, ignoring: " + file);
            }
        }

        */

        print("import finished for better or for worse");
        
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
