using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System.Diagnostics.Contracts;

public class RommManager : MonoBehaviourPunCallbacks
{
  
    [SerializeField] InputField roomCreateInputField;
    [SerializeField] InputField roomCapacityInputField;

    [SerializeField] Transform contentTransfomInputField;

    Dictionary<string, RoomInfo> dictionary = new Dictionary<string, RoomInfo>();

    //Information information;

    //private void Start()
    //{

    //    information = FindObjectOfType<Information>();
    //}

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

    //���� ������ų� �����ǰų� ���������� ȣ�� �Ǵ� �Լ�
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        //�� ����

        //�� ������Ʈ

        //�� ����
        InstantiateRoom();
    }

    public void InstantiateRoom()
    {
        foreach(RoomInfo roomInfo in dictionary.Values)
        {
            //1. Room ������Ʈ �����մϴ�.
            GameObject room = Instantiate(Resources.Load<GameObject>("Room"));

            //2. room ������Ʈ�� ��ġ ���� ���� �մϴ�.
            room.transform.SetParent(contentTransfomInputField);

            //3. room ������Ʈ �ȿ� �ִ� text �Ӽ��� �����մϴ�.
            room.GetComponent<Information>().SetData
              (
                roomInfo.Name,
                roomInfo.PlayerCount,
                roomInfo.MaxPlayers
               );


        }
    }

    public void UpdateRoom()
    {
        
    }

    public void RemovRoom()
    {

    }
}
