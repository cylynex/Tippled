﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Players : MonoBehaviour {
    
    [SerializeField] Text errorText;

    [SerializeField] InputField newPlayerName;
    [SerializeField] GameObject playerNamePrefab;
    [SerializeField] Transform playerNameHolder;
    [SerializeField] int maxPlayersPerGame = 12;

    // For the touchscreen keyboard
    private TouchScreenKeyboard touchScreenKeyboard;
    private string inputText = string.Empty;

    private void Start() {
        int numPlayers = GameController.players.Count;

        if (GameController.players.Count > 0) {
            print("found current players - distributinh");
            // Put the current players into the display
            for (int i = 0; i < numPlayers; i++) {
                AddExistingPlayer(GameController.players[i]);
            }
        }

        //touchScreenKeyboard = TouchScreenKeyboard.Open(inputText, TouchScreenKeyboardType.Default);
        //TouchScreenKeyboard.hideInput = true;
        //FocusInput();
    }

    public void OpenKeyboard() {
        touchScreenKeyboard = TouchScreenKeyboard.Open(inputText, TouchScreenKeyboardType.Default);
        FocusInput();
    }

    void FocusInput() {
        newPlayerName.Select();
        newPlayerName.ActivateInputField();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            AddNewPlayer();
        }

        if (touchScreenKeyboard == null)
            return;
        inputText = touchScreenKeyboard.text;
        if (touchScreenKeyboard.done) {
            AddNewPlayer();
        }
    }

    void AddExistingPlayer(string playerName) {
        print("add existing player");
        CreatePlayerEntry(playerName);
    }

    public void AddPlayer(string newPlayer, bool isNewPlayer) {
        // Add to the Game Controller
        if (newPlayer.Length > 0 && GameController.numberOfPlayers < maxPlayersPerGame && isNewPlayer == true) {
            
            print("Its ok to add this NEW player, continue");
            if (isNewPlayer) {
                GameController.players.Add(newPlayer);
                GameController.numberOfPlayers++;
            }           
            
            GameObject.FindGameObjectWithTag("ErrorHandler").GetComponent<ErrorHandler>().SetErrorText("");

            // Clear the UI
            newPlayerName.text = "";

            // Add to the lower UI section
            CreatePlayerEntry(newPlayer);
        }
        
        // If they try to add > maxPlayers
        if (GameController.numberOfPlayers >= maxPlayersPerGame) {
            errorText.text = "Maximum Number of Players Reached";
        } else {
            errorText.text = "";
        }
    }

    void CreatePlayerEntry(string newPlayer) {
        GameObject newestPlayer = Instantiate(playerNamePrefab, playerNameHolder.position, Quaternion.identity);
        newestPlayer.transform.SetParent(playerNameHolder);
        newestPlayer.GetComponentInChildren<Text>().text = newPlayer;
    }
    
    public void AddNewPlayer() {
        AddPlayer(newPlayerName.text, true);
        newPlayerName.text = "";
        inputText = "";
        //touchScreenKeyboard = TouchScreenKeyboard.Open(inputText, TouchScreenKeyboardType.Default);
        //FocusInput();
        
    }

}
