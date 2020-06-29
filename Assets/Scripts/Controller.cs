using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;
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

    bool HasTouch()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        return Input.GetMouseButton(0);
#else
        return Input.touchCount > 0;
#endif
    }

    Vector2 TouchPosition()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        return Input.mousePosition;
#else
        return Input.GetTouch(0).position;
#endif
    }

    IEnumerator Die()
    {
        float scale = Time.timeScale;
        Time.timeScale = 0;
        enabled = false;
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = scale;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        CD = Mathf.Max(0, CD - Time.deltaTime);
        if (HasTouch())
        {
            Ray ray = Camera.main.ScreenPointToRay(TouchPosition());
            Plane plane = new Plane(Vector3.forward, transform.position);
            float distance = 0;
            Vector3 touchpos = Vector3.zero;
            if (plane.Raycast(ray, out distance))
            {
                touchpos = ray.GetPoint(distance);
            }
            if (Physics.Linecast(transform.position, touchpos + new Vector3(0, 3, 0), 1 << LayerMask.NameToLayer("Enemies and walls")))
            {
                StartCoroutine(Die());
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, touchpos + new Vector3(0, 3, 0), 3);
            }
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
            StartCoroutine(Die());
        }

        if (other.gameObject.tag == "AttackingEnemy" || other.gameObject.tag == "DefendingEnemy")
        {
            StartCoroutine(Die());
        }
    }
}