using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    GameObject Bullet;
    [SerializeField]
    GameObject temp;
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
<<<<<<< Updated upstream
            rb.velocity = new Vector3(10, 10, 0); 
            transform.eulerAngles = new Vector3(
                 transform.eulerAngles.x,
                 transform.eulerAngles.y,
                 -45
             );
            if (Input.GetKeyDown(KeyCode.Space))
=======
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Plane plane = new Plane(Vector3.forward, transform.position);
            float distance = 0;
            Vector3 touchpos = Vector3.zero;
            if (plane.Raycast(ray, out distance))
            { 
                touchpos = ray.GetPoint(distance);
            }
            transform.position = touchpos;
            if (CD == 0)
>>>>>>> Stashed changes
            {
                CD = .5f;
                Vector3 pos = transform.position;
                Quaternion rotation = transform.rotation;
                GameObject temp = Instantiate(Bullet, pos, rotation);
                temp.transform.position = temp.transform.position + new Vector3(1, 0, 0);
                temp.GetComponent<Rigidbody>().velocity = new Vector3(20, 0, 0);
            }
            /*
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began && CD == 0)
                {
                    CD = .5f;
                    Vector3 pos = transform.position;
                    Quaternion rotation = transform.rotation;
                    GameObject temp = Instantiate(Bullet, pos, rotation);
                    temp.transform.position = temp.transform.position + new Vector3(1, 0, 0);
                    temp.GetComponent<Rigidbody>().velocity = new Vector3(20, 0, 0);
                }
            }*/
        }
        else
        {
<<<<<<< Updated upstream
            rb.velocity = new Vector3(10, -10, 0);
            transform.eulerAngles = new Vector3(
                 transform.eulerAngles.x,
                 transform.eulerAngles.y,
                 -135
             );
=======
            rb.velocity = new Vector3(10, 0, 0);
>>>>>>> Stashed changes
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            SceneManager.LoadScene(0);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(0);
        }
    }
}
