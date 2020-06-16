using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
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


    void Update()
    {
        CD = Mathf.Max(0, CD - Time.deltaTime);
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Plane plane = new Plane(Vector3.forward, transform.position);
            float distance = 0;
            Vector3 touchpos = Vector3.zero;
            if (plane.Raycast(ray, out distance))
            {
                touchpos = ray.GetPoint(distance);
            }
            transform.position = Vector3.Lerp(transform.position, touchpos + new Vector3(0, 3, 0), 1);
            if (CD <= 0)
            {
                CD = .5f;
                Vector3 pos = transform.position;
                Quaternion rotation = transform.rotation;
                GameObject temp = Instantiate(Bullet, pos, rotation);
                temp.transform.position = temp.transform.position + new Vector3(2, 0, 0);
                temp.GetComponent<Rigidbody>().velocity = new Vector3(20, 0, 0);
            }
        }
        else
        {
            rb.velocity = new Vector3(10, 0, 0);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            SceneManager.LoadScene(0);
        }
        if (other.gameObject.tag == "AttackingEnemy" || other.gameObject.tag == "DefendingEnemy")
        {
            SceneManager.LoadScene(0);
        }
    }
}