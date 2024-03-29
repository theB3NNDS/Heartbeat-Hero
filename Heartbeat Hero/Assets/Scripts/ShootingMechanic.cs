using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingMechanic : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    private float timer;
    public float timeBetweenFiring;
    // Update is called once per frame

    [SerializeField]
    private InputActionReference shoot;

    public Vector2 pointerPosition { get; set; }

    void Update()
    {
        

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
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



