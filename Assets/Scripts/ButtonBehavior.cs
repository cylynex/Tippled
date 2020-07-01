using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour {

    [SerializeField] GameObject warningPanel;

    public void ContinueButton() {
        Destroy(warningPanel);
    }

}
