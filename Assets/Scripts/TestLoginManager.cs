using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class TestLoginManager : MonoBehaviour
{
    #region Parameters
    
    [SerializeField]
    string customID = "TestCustomID";

    [SerializeField]
    string titleID = "D8E6D";
    #endregion Parameters

    CharityManager charityManager;

    private void Awake() 
    {
        charityManager = GameObject.Find("CharityManager").GetComponent<CharityManager>();
    }

    private void Start() 
    {
        AttemptLogin(); 
    }

    public void AttemptLogin()
    {
        //Note: Setting title Id here can be skipped if you have set the value in Editor Extensions already.
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = titleID; // Please change this value to your own titleId from PlayFab Game Manager
        }
        
        if(!PlayFabClientAPI.IsClientLoggedIn())
        {
            var request = new LoginWithCustomIDRequest { CustomId = customID, CreateAccount = true };
            PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);

        }

    }
    private void OnLoginFailure(PlayFabError error)
    {
        Debug.Log("Fail!");
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Success!");

        charityManager.GetCharityData();
    }

    public void Logout()
    {
        PlayFabClientAPI.ForgetAllCredentials();
   
    }

}
