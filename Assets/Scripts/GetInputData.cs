using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInputData : MonoBehaviour
{
    GameObject Data;
    public InputField userInput;
    public InputField passInput;
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getLoginUserData() {
        PlayfabManager.inst.emailInput = userInput.text;
        PlayfabManager.inst.passInput = passInput.text;
        PlayfabManager.inst.LoginButton();
    }

        public void getRegisterUserData() {
        PlayfabManager.inst.emailInput = userInput.text;
        PlayfabManager.inst.passInput = passInput.text;
        PlayfabManager.inst.RegisterButton();
    }

}
