using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using PlayFab.ClientModels;
using PlayFab;
using UnityEditor.PackageManager.Requests;

public class PhotoNatwoekManager : MonoBehaviourPunCallbacks // 상속 받음 
{
    [SerializeField] InputField enmailInputField;
    [SerializeField] InputField passwordInputField;


    public void Success(LoginResult loinResult)
    {

        PhotonNetwork.AutomaticallySyncScene = false;

        PhotonNetwork.GameVersion = "1.0f";

        PhotonNetwork.LoadLevel("LobbyScenes");
    }

    public void Success(RegisterPlayFabUserResult registerPlayFabUserResult)
    {
        Debug.Log(registerPlayFabUserResult.ToString());
    }

    public void Failure(PlayFabError playFabError)
    {
        PopUpManager.Instance.Show(AlarmType.SIGNINFAILURE, playFabError.GenerateErrorReport());
        //Debug.Log(playFabError.GenerateErrorReport());
    }

    public void OnSignUp()
    {
        var result = new RegisterPlayFabUserRequest
        {
            Email = enmailInputField.text,
            Password = passwordInputField.text,
            RequireBothUsernameAndEmail = false,

        };

        PlayFabClientAPI.RegisterPlayFabUser
        (
            result,
            Success,
            Failure
         );
            
        
    }

    public void OnSigIn()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = enmailInputField.text,
            Password = passwordInputField.text, 
        };

        PlayFabClientAPI.LoginWithEmailAddress
        (
                request,
                Success,
                Failure
         );
    }

}
