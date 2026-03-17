using System.Collections;
using UnityEngine;

public class skyShard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

        StartCoroutine(KYS());
    }

    IEnumerator KYS(){

        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
