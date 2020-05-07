using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanelButton : MonoBehaviour {

    public void ClosePanel() {
        GetComponent<Animation>().Play("AnswerPanelSlideOut");
        print("advance game");
    }

}
