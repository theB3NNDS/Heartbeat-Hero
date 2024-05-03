using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fountain : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public healthBar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0){
            SceneManager.LoadScene("titlescreen");
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy"){
            currentHealth -= 5;
            healthbar.SetHealth(currentHealth);
        }
    }
}
