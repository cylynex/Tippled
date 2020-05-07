using UnityEngine;
using UnityEngine.UI;

public class ErrorHandler : MonoBehaviour {

    public Text errorText;

    public void SetErrorText(string eText) {
        errorText.text = eText;
    }

}
