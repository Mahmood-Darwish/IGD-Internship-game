using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    public float speed;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            transform.parent.gameObject.GetComponent<Rigidbody>().velocity = transform.parent.gameObject.transform.up * -speed;
        }
    }
}
