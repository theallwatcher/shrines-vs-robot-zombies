using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawning : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] int totZom = 10;
    [SerializeField] GameObject zombiePre;
    public float tilNextZom;
    public int randomSpawn;
    public int setupTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
     
        StartCoroutine(StartUp());
    }

    IEnumerator StartUp() { 
    
        yield return new WaitForSeconds(setupTime);
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning() {

        tilNextZom = Random.Range(2, 20);
        randomSpawn = Random.Range(0, spawnPoints.Count);

        yield return new WaitForSeconds(tilNextZom);

        GameObject zombie = Instantiate(zombiePre, spawnPoints[randomSpawn].position, spawnPoints[randomSpawn].rotation);

        if (totZom > 0) {

            totZom -- ;
            StartCoroutine(Spawning());
        }

    }
}
