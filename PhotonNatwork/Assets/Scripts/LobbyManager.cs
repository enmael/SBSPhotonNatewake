using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Canvas lobbyCanvs;
    private void Awake()
    {
       if(PhotonNetwork.IsConnected)
       {
         lobbyCanvs.gameObject.SetActive(false);    
       }
    }

    public void Connect()
    {
        // 서버에 접속하는 함수 
        PhotonNetwork.ConnectUsingSettings();
        lobbyCanvs.gameObject.SetActive(false);
    }

    public override void OnJoinedLobby()
    {
        if(lobbyCanvs.gameObject.activeSelf)
        {
            lobbyCanvs.gameObject.SetActive(true);

        }
    }

    public override void OnConnectedToMaster()
    {
        //JoinLobby : 특정 로비를 생성하여 진입하느 함수 

        PhotonNetwork.JoinLobby
        (
            new TypedLobby
            (
                "Default",
                LobbyType.Default
             )
            
         );

    }
}
