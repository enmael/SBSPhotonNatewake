using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviourPunCallbacks
{
    [SerializeField] Button button;
    public void Resume()
    {
        MouseManager.Instance.SetMouse(false);

        gameObject.SetActive(false);    
    }

    public void Exit()
    {
        PhotonNetwork.LeaveRoom(); //방을 나가다 
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Lobby Scene");
    }

}
