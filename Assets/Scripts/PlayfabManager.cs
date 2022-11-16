using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;


public class PlayfabManager : MonoBehaviour
{

    public static PlayfabManager inst;

    public int coins;
    public Text messageText;
    public string emailInput;
    public string passInput;

    private void Awake() {
        if (inst == null) {
            inst = this;
            DontDestroyOnLoad(gameObject);
        }

        else {
            Destroy(gameObject);
        }
    }

    /*** Registro ***/
    public void RegisterButton() {

        if (passInput.Length < 6) {
            messageText.text = "¡contraseña muy corta!";
            return;
        }

        var request = new RegisterPlayFabUserRequest {
        Email = emailInput,
        Password = passInput,
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
            Email = emailInput,
            Password = passInput
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    void OnLoginSuccess(LoginResult result) {
        messageText.text = "has iniciado sesión";
        getMoney();
        SceneManager.LoadScene("Game");
    }

    public void getMoney() {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorySuccess, OnError);
    }

    void OnGetUserInventorySuccess(GetUserInventoryResult result) {
        coins = result.VirtualCurrency["MN"];
    }


    /*** Error ***/
    void OnError(PlayFabError error) {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

}
