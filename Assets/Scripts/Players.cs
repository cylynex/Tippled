using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Players : MonoBehaviour {
    
    [SerializeField] Text playerCounterText;
    [SerializeField] Text errorText;

    [SerializeField] InputField newPlayerName;
    [SerializeField] GameObject playerNamePrefab;
    [SerializeField] Transform playerNameHolder;

    private void Start() {
        print(GameController.players.Count);
        int numPlayers = GameController.players.Count;

        if (GameController.players.Count > 0) {
            // Put the current players into the display
            for (int i = 0; i < numPlayers; i++) {
                AddPlayer(GameController.players[i], false);
            }
        }

    }

    public void AddPlayer(string newPlayer, bool isNewPlayer) {

        // Add to the Game Controller
        if (newPlayer.Length > 0 && GameController.numberOfPlayers < 20) {

            if (isNewPlayer) {
                GameController.players.Add(newPlayer);
                GameController.numberOfPlayers++;
            }           
            
            GameObject.FindGameObjectWithTag("ErrorHandler").GetComponent<ErrorHandler>().SetErrorText("");

            // Clear the UI
            newPlayerName.text = "";

            // Add to the lower UI section
            // TODO add icon for remove player (and method)
            GameObject newestPlayer = Instantiate(playerNamePrefab, playerNameHolder.position, Quaternion.identity);
            newestPlayer.transform.SetParent(playerNameHolder);
            newestPlayer.GetComponent<Text>().text = newPlayer;
        }
        
        // If they try to add > 20 players
        if (GameController.numberOfPlayers == 20) {
            errorText.text = "Maximum Number of Players Reached";
        } else {
            errorText.text = "";
        }
    }
    
    public void AddNewPlayer() {
        AddPlayer(newPlayerName.text, true);
    }

}
