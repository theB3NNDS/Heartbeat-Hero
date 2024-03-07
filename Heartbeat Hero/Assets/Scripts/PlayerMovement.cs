using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //necessary variables
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movementInput, pointerInput;

    //input reference so it can be called
    [SerializeField]
    private InputActionReference movement, pointerPosition;

    //reference for WeaponParent script to pass pointer position
    private WeaponParent weaponParent;

    private void Awake()
    {
        
        weaponParent = GetComponentInChildren<WeaponParent>();
    }

    void Update()
    {
        movementInput = movement.action.ReadValue<Vector2>();
        pointerInput = GetPointerInput();
        weaponParent.pointerPosition = pointerInput;
    }

    void FixedUpdate()
    {
        //movement logic
        rb.MovePosition(rb.position + movementInput.normalized * moveSpeed * Time.fixedDeltaTime);
    }    
 
    //gets pointer input to be used by WeaponParent script
    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
