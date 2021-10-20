using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject vileturon;

    private Vector2 randomVector;
    
    private void Update()
    {
        transform.Translate(randomVector * Time.deltaTime);
    }


    public int health = 10;

    public void TakeDamage( int damage )
    {
        Vector2 damagePos = new Vector2(transform.position.x + Random.Range(-0.7f,0.7f), transform.position.y + Random.Range(0.7f,1f));
        Instantiate(vileturon, damagePos, Quaternion.identity);
        vileturon.GetComponentInChildren<vileturon>().damage = damage;
        health -= damage;

        if ( health <= 0 )
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
