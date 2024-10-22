using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float mouseX;
    [SerializeField] float speed = 200.0f;
    [SerializeField] float mouseY;


    public void InputRotateY()
    {
        mouseX += Input.GetAxisRaw("Mouse X") * speed * Time.deltaTime;
    }
    public void RotateY(Rigidbody rigidbody)
    {
       

        rigidbody.transform.eulerAngles = new Vector3(0, mouseX, 0);
    }

    public void RotateX()
    {
        //mouseY 에 마우스로 입력한 값을 저장
        mouseY += Input.GetAxisRaw("Mouse Y") * speed * Time.deltaTime;

        //if (mouseY >= -65  && mouseY <= 65 )
        //{

        //}
        //-65 ~ 65 사이의 값 제한
        //mouseY <- Math.Calmp (제한)
        mouseY = Mathf.Clamp(mouseY, -65, 65);

        transform.localEulerAngles = new Vector3(-mouseY, 0, 0);
    }
}
