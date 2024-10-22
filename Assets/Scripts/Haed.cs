using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rotation))]
public class Haed : MonoBehaviour
{
    private Rotation rotation;
    // Start is called before the first frame update
    void Start()
    {
        rotation = GetComponent<Rotation>();    
    }

    // Update is called once per frame
    void Update()
    {
        rotation.RotateX();
    }
}
