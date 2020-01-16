using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class CharityManager : MonoBehaviour
{
    public CharityList questGivers;

    public void GetCharityData()
    {

        PlayFabClientAPI.GetTitleData(new PlayFab.ClientModels.GetTitleDataRequest
        { 
            Keys = null
        },
        GetCharityDataSuccess, OnError);
    }

    private void OnError(PlayFabError obj)
    {
        Debug.Log(obj.GenerateErrorReport());
    }

    private void GetCharityDataSuccess(GetTitleDataResult result)
    {
        string json;
        result.Data.TryGetValue("CharityList", out json);

        questGivers = JsonUtility.FromJson<CharityList>(json);

    }

}
