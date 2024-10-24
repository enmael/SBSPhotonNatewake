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
    [SerializeField] Rigidbody rigidBody;

    private void Awake()
    {
        move = GetComponent<Move>();
        rotation = GetComponent<Rotation>();
        rigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        DisableCamera();
    }

    private void Update()
    {
        if (photonView.IsMine == false) return;


        if(Input.GetKeyDown(KeyCode.Escape))
        {
            MouseManager.Instance.SetMouse(true);
        }
        rotation.InputRotateY();
    }

    void FixedUpdate()
    {
        if (photonView.IsMine == false) return;

        move.Movement(rigidBody);

        rotation.RotateY(rigidBody);
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
