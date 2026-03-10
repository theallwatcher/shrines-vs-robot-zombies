using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector2 movementInput;
    private Rigidbody rb;
    public int t = 1;

    public List<GameObject> shrines;

    public int health = 2000;
    [SerializeField] TextMeshProUGUI healthText;
    bool canTakeDamage = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        UpdateHealth();
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

        rb.linearVelocity = transform.rotation * positionChange;

        //made with help of tutoriel from Ketra Games (https://www.youtube.com/watch?v=V09EyTSNNN8)
    }

    IEnumerator UpdateHealth() { 
    
        healthText.text = health.ToString();
        yield return new WaitForSeconds(1);
        canTakeDamage = true;
    }

    private void OnTriggerEnter(Collider other){
        
        if (other.tag == "zombie" && canTakeDamage == true) { 
            
            health = health - 100; 
            canTakeDamage = false;
            StartCoroutine(UpdateHealth());
        }
    }

}
