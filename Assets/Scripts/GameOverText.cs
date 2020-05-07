using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour {

    [SerializeField] string[] endOfGameMessages;
    [SerializeField] Text endOfGameTextSpot;

    private void Start() {
        int lineTouse = Random.Range(0, endOfGameMessages.Length);
        endOfGameTextSpot.text = endOfGameMessages[lineTouse];
    }

}
