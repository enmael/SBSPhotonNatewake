using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousManager : MonoBehaviour
{
    [SerializeField] Texture2D texture2D;

    private void Awake()
    {
        setMouse();
    }
    public void setMouse()
    {
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.ForceSoftware);
    }
}
