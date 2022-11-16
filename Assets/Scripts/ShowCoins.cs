using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class ShowCoins : MonoBehaviour
{
    public Text coins;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = PlayfabManager.inst.coins.ToString();
    }

    public void addMoney() {
        var request = new AddUserVirtualCurrencyRequest {
            VirtualCurrency = "MN",
            Amount = 1
        };
        PlayFabClientAPI.AddUserVirtualCurrency(request, OnAddMoneySuccess, OnError);
    }

    void OnAddMoneySuccess(ModifyUserVirtualCurrencyResult result) {
        Debug.Log("moneda adquirida");
        PlayfabManager.inst.getMoney();
    }

    void OnError(PlayFabError error) {
        Debug.Log(error.ErrorMessage);
    }
}
