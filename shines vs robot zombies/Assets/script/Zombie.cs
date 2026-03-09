using UnityEditor;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;
    public bool isMoving;
    public int health = 270;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){

        rb = GetComponent<Rigidbody>();
        StartMoveing();
    }

    public void StartMoveing() {

        rb.linearVelocity = transform.forward * speed;
        isMoving = true;
    }

    public void StopMoveing() {
        Debug.Log("shrine");
        rb.linearVelocity = new Vector3(0,0,0);
        isMoving = false;
    }

    private void Update(){

        Vector3 forward = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
        Debug.DrawLine(transform.position, forward, Color.green);
        if (IsCloseEnough() == true && isMoving == true){

            StopMoveing();
        }
        else if (IsCloseEnough() == false && isMoving == false) { 
        
            StartMoveing();
        }
    }

    bool IsCloseEnough(){

        RaycastHit _hit;
        
        if (Physics.Raycast(transform.position,transform.forward, out _hit, 2f)){

            if (_hit.transform.tag == "shrine"){

                return true;
            }
        }
        return false;
    }

    private void OnCollisionEnter(Collision collision){

        if (collision.gameObject.tag == "bullet"){

            TakeDamage();
        }
    }

    private void TakeDamage() { 
    

    }
}
