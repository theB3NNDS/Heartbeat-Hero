using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float timeBetweenFire;
    float nextFireTime;

    [SerializeField]
    private InputActionReference shoot;

    void Shoot()
    {
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + timeBetweenFire;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }

        
        //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    private void OnEnable()
    {
        shoot.action.performed += PerformShoot;
    }

    private void OnDisable()
    {
        shoot.action.performed -= PerformShoot;
    }

    private void PerformShoot (InputAction.CallbackContext obj)
    {
        Debug.Log("Shoot");
        Shoot();
    }

}
