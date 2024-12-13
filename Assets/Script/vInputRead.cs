using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class vInputRead : MonoBehaviour
{
    public TMP_InputField vInput;

    public void ReadInput()
    {
        Debug.Log("User Input: " + vInput.text);
    }
}
