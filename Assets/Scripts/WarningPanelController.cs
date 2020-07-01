using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningPanelController : MonoBehaviour {

    static bool warningShown = false;
    [SerializeField] GameObject warningPanel;

    private void Start() {
        if (warningShown == false) {
            // Activate the warning box
            warningPanel.SetActive(true);
            warningShown = true;
        }
    }

}
