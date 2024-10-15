using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PhotoNatwoekManager : MonoBehaviourPunCallbacks // 상속 받음 
{
    [SerializeField] InputField enmailInputField;
    [SerializeField] InputField passwordInputField;


    public void Sucess()
    {
        PhotonNetwork.AutomaticallySyncScene = false; // 단체로 이동하는걸 방지하려고 특정한 상황에서만 true

        PhotonNetwork.GameVersion = "1.0f"; //버전은 통일해야된다.

        PhotonNetwork.LoadLevel("LobbyScenes"); //신엘리로 해도 되는데 이걸 권장한다. 포톤에선 
    }
}
