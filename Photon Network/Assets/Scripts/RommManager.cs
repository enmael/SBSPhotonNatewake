using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class RommManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Button roomCreateButton;
    [SerializeField] InputField roomCreateInputField;
    [SerializeField] InputField roomCapacityInputField;

    [SerializeField] InputField contentTransfomInputField;

    Dictionary<string, RoomInfo> dictionary = new Dictionary<string, RoomInfo>();

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game Scene");
    }

    public void OnCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();

        roomOptions.MaxPlayers = byte.Parse(roomCapacityInputField.text);

        roomOptions.IsOpen = true;  

        roomOptions.IsVisible = true;

        PhotonNetwork.CreateRoom(roomCapacityInputField.text, roomOptions);
    }
}
