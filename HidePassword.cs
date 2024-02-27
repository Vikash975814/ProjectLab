using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidePassword : MonoBehaviour
{
    public InputField passwordInputField;

    private void Start()
    {
        if (passwordInputField != null)
        {
            // Set the content type to Password
            passwordInputField.contentType = InputField.ContentType.Password;
        }
        else
        {
            Debug.LogError("Password InputField is not assigned in the inspector!");
        }
    }
}

