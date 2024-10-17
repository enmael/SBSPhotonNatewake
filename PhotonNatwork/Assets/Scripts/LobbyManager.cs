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
        // ������ �����ϴ� �Լ� 
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
        //JoinLobby : Ư�� �κ� �����Ͽ� �����ϴ� �Լ� 

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
