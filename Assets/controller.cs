using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(5, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 || Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector3(5, 6, 0); 
            transform.eulerAngles = new Vector3(
                 transform.eulerAngles.x,
                 transform.eulerAngles.y,
                 -45
             );

        }
        else
        {
            rb.velocity = new Vector3(5, -6, 0);
            transform.eulerAngles = new Vector3(
                 transform.eulerAngles.x,
                 transform.eulerAngles.y,
                 -135
             );
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            SceneManager.LoadScene(0);
        }
    }
}
