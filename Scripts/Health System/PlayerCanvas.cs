using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanvas : MonoBehaviour
{
    private Transform camTransform;

    void Start()
    {
        if (Camera.main != null)
        {
            camTransform = Camera.main.transform;
        }
        else
        {
            Debug.Log("Main Camera not found.");
        }
    }

    void LateUpdate()
    {
        if (camTransform != null)
        {
            transform.LookAt(camTransform);
        }
    }
}
