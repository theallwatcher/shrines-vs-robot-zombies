using System.Collections;
using UnityEngine;

public class SkySmasherShrine : MonoBehaviour
{

    [SerializeField] GameObject skyShard;
    [SerializeField] Transform firePoint;
    Coroutine lastRoutine = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastRoutine = StartCoroutine(Smashing());   
    }


    IEnumerator Smashing()
    {
        int randomX = Random.Range(-1, 2);
        int randomZ = Random.Range(-1, 2);

        Vector3 pos = new Vector3(firePoint.position.x + randomX, 0, firePoint.position.z + randomZ);
        yield return new WaitForSeconds(24);
        GameObject shard = Instantiate(skyShard, pos, firePoint.rotation);
        lastRoutine = StartCoroutine(Smashing());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
