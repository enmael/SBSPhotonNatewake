using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Chat;
using UnityEngine.UI;
using UnityEditor.VersionControl;

public class DialogManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;
    [SerializeField] Transform parentTransform;
    [SerializeField] ScrollRect scrollRect; 

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            inputField.ActivateInputField(); //Ȱ��ȭ

           if(inputField.text.Length <= 0) return;
            
           string talk  = photonView.Owner.NickName + " : " + inputField.text;
            //Rpc Target.All :���� �뿡 �ִ� ��� Ŭ���̾�Ʈ�� Talk �Լ��� �����Ϸ��� ���
            photonView.RPC("Talk", RpcTarget.All, talk);

            scrollRect.verticalNormalizedPosition = 0.0f;
        }
    }
    [PunRPC]
    public void Talk(string message)
    {
        // �������� �ϳ� ������ ���� text���� �����մϴ�.
        GameObject talk = Instantiate(Resources.Load<GameObject>("String"));

        talk.GetComponent<Text>().text = message;

        //��ũ�� �� - coutent�� �ڽ����� ����մϴ�.
        talk.transform.SetParent(parentTransform);

        //ä���� �Է��� �Ŀ��� �̾ �Է��Ҽ� �ֵ��� �����Ѻ��
        inputField.ActivateInputField();

        scrollRect.verticalNormalizedPosition = 0.0f;

        //inputField.�� �ؽ�Ʈ�� �ʱ�ȭ
        inputField.text = "";
    }
}
