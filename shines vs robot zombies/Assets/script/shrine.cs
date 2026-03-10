using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class shrine : MonoBehaviour
{
    Coroutine lastRoutine = null;
    gridTile _tile;
    [SerializeField] int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StartCoroutine(KYS());
    }

    IEnumerator KYS() {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    public void LinkShrine(gridTile tile)
    {
        _tile = tile;
    }

    private void OnDestroy()
    {
        _tile.canPlaceShrines = true;
    }

    private void OnTriggerEnter(Collider other){

        if (other.tag == "zombie"){

            lastRoutine = StartCoroutine(TakeDamage());
        }
    } 
    IEnumerator TakeDamage() {

        yield return new WaitForSeconds(1);
        health = health - 100;
        if (health <= 0) { 
        
            Destroy(gameObject);
        }
        lastRoutine = StartCoroutine(TakeDamage());
    }

    private void OnTriggerExit(Collider other){

        if (other.tag == "zombie"){

            StopCoroutine(lastRoutine);
        }
    }

}