using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;


public class PlayfabManager : MonoBehaviour
{

    public Text messageText;
    public InputField emailInput;
    public InputField passInput;

    /*** Registro ***/
    public void RegisterButton() {

        if (passInput.text.Length < 6) {
            messageText.text = "¡contraseña muy corta!";
            return;
        }

        var request = new RegisterPlayFabUserRequest {
        Email = emailInput.text,
        Password = passInput.text,
        RequireBothUsernameAndEmail = false
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result) {
        messageText.text = "registered and logged in!";
    }


    /*** Login ***/
    public void LoginButton() {
        var request = new LoginWithEmailAddressRequest {
            Email = emailInput.text,
            Password = passInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    void OnLoginSuccess(LoginResult result) {
        messageText.text = "has iniciado sesión";
    }


    /*** Error ***/
    void OnError(PlayFabError error) {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

}
