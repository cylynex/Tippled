using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldController : MonoBehaviour {

    [SerializeField] InputField inputField;

    private void Start() {
        inputField.characterLimit = 12;
    }

}
