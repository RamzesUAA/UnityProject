using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shorspeed : MonoBehaviour
{
    public float speed;
    public float destroyTime;
    public int damage;

    public GameObject effects;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyAmmo", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void DestroyAmmo()
    {
        Destroy(gameObject);
    }

 private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        Instantiate(effects, gameObject.transform.position, Quaternion.identity);
        if ( enemy != null )
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);

        Box box = collision.GetComponent<Box>();

        if ( box != null )
        {
            box.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
