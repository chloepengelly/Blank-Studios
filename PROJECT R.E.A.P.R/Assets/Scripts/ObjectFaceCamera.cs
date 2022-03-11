using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFaceCamera : MonoBehaviour
{
    Transform cam;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }


    void Update()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
