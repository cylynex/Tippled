using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamesToggle : MonoBehaviour {
    
    public GameObject nameList;

    public void ToggleNames() {
        if (nameList.active == true) {
            nameList.SetActive(false);
        } else {
            nameList.SetActive(true);
        }
    }

}
