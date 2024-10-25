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
            inputField.ActivateInputField(); //활성화

           if(inputField.text.Length <= 0) return;
            
           string talk  = photonView.Owner.NickName + " : " + inputField.text;
            //Rpc Target.All :현재 룸에 있는 모든 클라이언트에 Talk 함수를 실행하려는 명령
            photonView.RPC("Talk", RpcTarget.All, talk);

            scrollRect.verticalNormalizedPosition = 0.0f;
        }
    }
    [PunRPC]
    public void Talk(string message)
    {
        // 프리템을 하나 생성한 다음 text값을 설정합니다.
        GameObject talk = Instantiate(Resources.Load<GameObject>("String"));

        talk.GetComponent<Text>().text = message;

        //스크롤 뷰 - coutent에 자식으로 등록합니다.
        talk.transform.SetParent(parentTransform);

        //채팅을 입력한 후에도 이어서 입력할수 있도록 설정한빈다
        inputField.ActivateInputField();

        scrollRect.verticalNormalizedPosition = 0.0f;

        //inputField.의 텍스트를 초기화
        inputField.text = "";
    }
}
