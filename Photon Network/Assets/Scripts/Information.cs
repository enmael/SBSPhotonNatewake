using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using JetBrains.Annotations;


public class Information : MonoBehaviourPunCallbacks
{
    private string roomTile;
    [SerializeField] Text roomTileText;

    public Text Text
    {
        get { return roomTileText; }
        set { roomTileText = value; }
    }

    public void onConnectRoom()
    {
        // 특정 방에 들어가는 
        PhotonNetwork.JoinRoom(roomTile);   
    }

    public void SetData(string name, int currentStaff, int maxStaff) 
    {
        roomTile = name;

        roomTileText.text = roomTile + "(" + currentStaff + "/" + maxStaff + ")";
    }
}
