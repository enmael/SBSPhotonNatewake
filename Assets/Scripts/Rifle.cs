using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Rifle : MonoBehaviourPunCallbacks
{
    [SerializeField] Ray ray;
    [SerializeField] RaycastHit raycasHit;

    [SerializeField] Camera remoteCamera;
    [SerializeField] LayerMask layerMask;

    private void Update()
    {
        if (photonView.IsMine == false) return;


        if(Input.GetMouseButtonDown(0))
        {
            ray = remoteCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out raycasHit, Mathf.Infinity, layerMask)) 
            {
                PhotonView photonView = raycasHit.collider.GetComponent<PhotonView>(); 
            
                if(photonView.IsMine)
                {
                    photonView.GetComponent<Rake>().Die();
                }
            }
        }
    }

}
