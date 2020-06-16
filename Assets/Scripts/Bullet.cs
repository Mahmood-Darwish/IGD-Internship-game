using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float timer = 2f;

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "AttackingEnemy")
        {
            other.gameObject.GetComponent<AttackingEnemy>().hp--;
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "DefendingEnemy")
        {
            other.gameObject.GetComponent<DefendingEnemy>().hp--;
            Destroy(gameObject);
        }
    }
}
