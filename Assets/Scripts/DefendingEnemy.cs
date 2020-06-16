using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendingEnemy : MonoBehaviour
{
    GameObject point1;
    GameObject point2;
    public int hp;
    [SerializeField]
    float speed;

    GameObject target;
    Vector3 targetpos;
    Rigidbody rb;

    private void Start()
    {
        point1 = transform.GetChild(0).gameObject;
        point2 = transform.GetChild(1).gameObject;
        point1.transform.parent = null;
        point2.transform.parent = null;
        rb = GetComponent<Rigidbody>();
        target = point1;
        targetpos = (target.transform.position - transform.position).normalized;
        rb.velocity = targetpos * speed;
    }


    void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
        if(Vector3.Distance(transform.position, target.transform.position) < .5f)
        {
            if(target == point1)
            {
                target = point2;
            }
            else
            {
                target = point1;
            }
            targetpos = (target.transform.position - transform.position).normalized;
            rb.velocity = targetpos * speed;
        }
    }
}
