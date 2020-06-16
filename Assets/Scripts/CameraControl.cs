using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    Vector3 offset;
    [SerializeField]
    GameObject target;

    void Update()
    {
        transform.position = offset + target.transform.position;
    }
}
