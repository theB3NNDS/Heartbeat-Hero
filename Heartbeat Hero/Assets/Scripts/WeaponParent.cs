using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponParent : MonoBehaviour
{
    //references weapon and character sprite to change layer order
    public SpriteRenderer characterRenderer, weaponRenderer;

    //gets pointer position from PlayerMovement script
    public Vector2 pointerPosition { get; set; }

    /*
    //shooting mechanics
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;
    public float timeBetweenFire;
    float nextFireTime;

    //input reference
    [SerializeField]
    private InputActionReference shoot;
    */

    void Update()
    {
        WeaponRotation();
    }

    //function responsible for weapon rotation and layer order logic
    void WeaponRotation()
    {   
        //always point to mouse position
        Vector2 direction = (pointerPosition-(Vector2)transform.position).normalized;
        transform.right = direction;

        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -1;
        }
        else if (direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;

        if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            weaponRenderer.sortingOrder = characterRenderer.sortingOrder - 1;
        }
        else
        {
            weaponRenderer.sortingOrder = characterRenderer.sortingOrder + 1;
        }
    }

    /*
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

    //input events
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
    */
}
