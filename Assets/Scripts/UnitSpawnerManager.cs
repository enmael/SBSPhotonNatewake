using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class UnitSpawnerManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform spawnerPosition;
    WaitForSeconds waitForSeconds = new WaitForSeconds(5);
    [SerializeField] GameObject gameObject;

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(Corouti());
        }
    
    }

    IEnumerator Corouti()
    {
        while (true)
        {
            PhotonNetwork.InstantiateRoomObject(gameObject.name, spawnerPosition.position, Quaternion.identity);
            yield return waitForSeconds;

        }
    }
}





    
