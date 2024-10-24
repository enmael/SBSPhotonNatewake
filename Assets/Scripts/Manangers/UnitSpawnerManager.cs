using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class UnitSpawnerManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform spawnerPosition;

    WaitForSeconds waitForSeconds = new WaitForSeconds(5);

    void Start()
    {
        if(PhotonNetwork.IsMasterClient) //한번만 호출된다.
        {
            StartCoroutine(Create());
        }      
    }

    public IEnumerator Create()
    {
        while(true)
        {
            PhotonNetwork.InstantiateRoomObject("Unit", spawnerPosition.position, Quaternion.identity);

            yield return waitForSeconds;
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);
        //마스터 클라이언트가 탈주하면 다음으로 들어온 사람이 마스터

        if(PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(Create());
        }
    }
}
