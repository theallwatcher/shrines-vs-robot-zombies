using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 movementInput;
    private Rigidbody rb;
    public int t = 1;

    public List<GameObject> shrines;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnMove(InputValue inputValue){

        movementInput = inputValue.Get<Vector2>();

    }

    // Update is called once per frame
    void Update(){

        Move();
        if (Keyboard.current.pKey.wasPressedThisFrame){

            if (t == 0)
            {

                Cursor.lockState = CursorLockMode.Locked;
                t = 1;
            }
            else if (t == 1){

                Cursor.lockState = CursorLockMode.None;
                t = 0;
            }
            
        }
    }

    private void Move() { 
    
        Vector3 positionChange = new Vector3(movementInput.x,0,movementInput.y) * Time.deltaTime * speed;

        //Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward
        transform.position += transform.rotation * positionChange;

        //made with help of tutoriel from Ketra Games (https://www.youtube.com/watch?v=V09EyTSNNN8)
    }

}
