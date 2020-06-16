using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingEnemy : MonoBehaviour
{
    public int hp;
    [SerializeField]
    float speed;

    Renderer rd;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rd = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (rd.isVisible)
        {
            rb.velocity = new Vector3(-1, 0, 0);
            rb.velocity *= speed;
        }
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
