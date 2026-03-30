using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [Header("movement")]

    [SerializeField] private float speed;
    private Vector2 movementInput;
    private Rigidbody rb;

    [Header("health")]
    public int health = 2000;
    [SerializeField] TextMeshProUGUI healthText;
    bool canTakeDamage = true;

    [Header("shine select")]
    public int curSelectShrine = 0;
    [SerializeField] GameObject shrineSelectorPref;
    [SerializeField] List<RectTransform> spawnPoints;
    public List<GameObject> shrines;
    GameObject shrineSelect;
    public bool paused =false;

    inventory _inventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _inventory = FindFirstObjectByType<inventory>();
        Cursor.lockState = CursorLockMode.Locked;
        UpdateHealth();
        ValueChange();
    }

    private void OnMove(InputValue inputValue){

        movementInput = inputValue.Get<Vector2>();

    }

    private void OnSelectUp() {

        if (paused == false){
            curSelectShrine++;
            Debug.Log("up");
            ValueChange();
        }
    }

    private void OnSelectDown() {

        if (paused == false){
            curSelectShrine--;
            Debug.Log("douwn");
            ValueChange();
        }
    }


    // Update is called once per frame
    void Update(){

        if (Keyboard.current.vKey.wasPressedThisFrame)
        {
            levelCounter counter = FindFirstObjectByType<levelCounter>();
            counter.LevelWin();
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("startScene");
        }

        Move();

        
    }

    private void Move() { 
    
        Vector3 positionChange = new Vector3(movementInput.x,0,movementInput.y) * speed;

        rb.linearVelocity = transform.rotation * positionChange;

        //made with help of tutoriel from Ketra Games (https://www.youtube.com/watch?v=V09EyTSNNN8)
    }

    IEnumerator UpdateHealth() { 
    
        healthText.text = health.ToString();
        if (health <= 0) {

            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("gameOver");
        }
        yield return new WaitForSeconds(1);
        canTakeDamage = true;
    }

    private void OnTriggerEnter(Collider other){
        
        if (other.tag == "zombie" && canTakeDamage == true) { 
            
            health = health - 100; 
            canTakeDamage = false;
            StartCoroutine(UpdateHealth());
        }

        if (other.tag == "skyShard") {
        
            _inventory.skyShardsCount = _inventory.skyShardsCount + 25;
            Destroy(other.gameObject);
            _inventory.UpdateText();
        }
    }


    private void ValueChange() {

        if (curSelectShrine <= 0){

            curSelectShrine = 0;
        }

        if (curSelectShrine >= 2){

            curSelectShrine = 2;
        }

        if (shrineSelect != null) {

            Destroy(shrineSelect);
            
        }

        shrineSelect = Instantiate(shrineSelectorPref, spawnPoints[curSelectShrine].position, spawnPoints[curSelectShrine].rotation, spawnPoints[curSelectShrine]);
    }
}
