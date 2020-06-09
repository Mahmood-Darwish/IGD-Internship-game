using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    GameObject Bullet;
    float CD;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(5, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CD = Mathf.Max(0, CD - Time.deltaTime);
        if (Input.touchCount > 0 || Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector3(10, 10, 0); 
            transform.eulerAngles = new Vector3(
                 transform.eulerAngles.x,
                 transform.eulerAngles.y,
                 -45
             );
            
            if(Input.GetTouch(0).phase == TouchPhase.Began && CD == 0)
            {
                CD = .5f;
                Vector3 pos = transform.position;
                Quaternion rotation = transform.rotation;
                GameObject temp = Instantiate(Bullet, pos, rotation);
                temp.transform.position = temp.transform.position + new Vector3(1, 0, 0);
                temp.GetComponent<Rigidbody>().velocity = new Vector3(20, 0, 0);
            }
        }
        else
        {
            rb.velocity = new Vector3(10, -10, 0);
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
