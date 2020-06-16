using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingWall : MonoBehaviour
{
    [SerializeField]
    float speed;

    Rigidbody rb;
    Renderer rd;

    void Start()
    {
        rd = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rd.isVisible)
        {
            rb.velocity = new Vector3(0, -speed, 0);
        }
    }
}
