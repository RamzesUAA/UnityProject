using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int health = 10;
    public GameObject effects2;

    public void TakeDamage( int damage )
    {
        health -= damage;

        if ( health <= 0 )
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Instantiate(effects2, gameObject.transform.position, Quaternion.identity);
    }
}
