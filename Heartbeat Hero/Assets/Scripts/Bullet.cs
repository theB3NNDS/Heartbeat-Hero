using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;
    public float speed;
    public int damage;
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy (effect, 1f);
        Destroy(gameObject);
    }
    */
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy"){
            Destroy(gameObject);
        }
    }
    
}
