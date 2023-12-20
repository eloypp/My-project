using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Fox;
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Fox.transform.position.x;  
        transform.position = position;
    }
}
