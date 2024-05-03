using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Transform player;

    public float speed;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet"){
            TakeDamage(other.GetComponent<Bullet>().damage);
        }

        if (other.tag == "Player"){
            Destroy(gameObject);
        }
    }

    void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0){
            Destroy(gameObject);
        } 
    }
}
