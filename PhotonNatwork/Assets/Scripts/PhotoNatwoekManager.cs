using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PhotoNatwoekManager : MonoBehaviourPunCallbacks // ��� ���� 
{
    [SerializeField] InputField enmailInputField;
    [SerializeField] InputField passwordInputField;


    public void Sucess()
    {
        PhotonNetwork.AutomaticallySyncScene = false; // ��ü�� �̵��ϴ°� �����Ϸ��� Ư���� ��Ȳ������ true

        PhotonNetwork.GameVersion = "1.0f"; //������ �����ؾߵȴ�.

        PhotonNetwork.LoadLevel("LobbyScenes"); //�ſ����� �ص� �Ǵµ� �̰� �����Ѵ�. ���濡�� 
    }
}
