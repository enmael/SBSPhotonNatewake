using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using PlayFab.ClientModels;
using PlayFab;

public class PhotoNatwoekManager : MonoBehaviourPunCallbacks // ��� ���� 
{
    [SerializeField] InputField enmailInputField;
    [SerializeField] InputField passwordInputField;


    public void Sucess(LoinResult loinResult)
    {
        
        PhotonNetwork.AutomaticallySyncScene = false; // ��ü�� �̵��ϴ°� �����Ϸ��� Ư���� ��Ȳ������ true

        PhotonNetwork.GameVersion = "1.0f"; //������ �����ؾߵȴ�.

        PhotonNetwork.LoadLevel("LobbyScenes"); //�ſ����� �ص� �Ǵµ� �̰� �����Ѵ�. ���濡�� 
    }

    public void Success(RegisterPlayFabUserResult registerPlayFabUserResult)
    {
        Debug.Log(registerPlayFabUserResult.ToString());
    }

    public void Failure(PlayFabError playFabError)
    {
        Debug.Log(playFabError.GenerateErrorReport());
    }





}
