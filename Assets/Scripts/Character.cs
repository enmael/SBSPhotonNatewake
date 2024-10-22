using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Move))]
[RequireComponent(typeof(Rotation))]

public class Character : MonoBehaviourPun
{
    [SerializeField] Move move;
    [SerializeField] Rotation rotation;
    [SerializeField] Camera remoteCamera;
    [SerializeField] Rigidbody rigidbody;

    private void Awake()
    {
        move = GetComponent<Move>();
        rotation = GetComponent<Rotation>();
        rigidbody = GetComponent<Rigidbody>();  
    }

    void Start()
    {
        DisableCamera();
    }

    private void Update()
    {
        rotation.InputRotateY();
    }

    void FixedUpdate()
    {
        move.Movement(rigidbody);

        rotation.RotateY(rigidbody);
    }

    public void DisableCamera()
    {
        // ���� �÷��̾ �� �ڽ��̶��
        if(photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            remoteCamera.gameObject.SetActive(false);
        }
    }
}
