using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieSpawning : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] int totZom = 50;
    public int maxZom = 50;
    [SerializeField] GameObject zombiePre;
    [SerializeField] Image progressBar;
    public float tilNextZom;
    public int randomSpawn;
    public int setupTime;
    public int waveSize;
    bool finalWave= false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){

        StartCoroutine(StartUp());
        float newWidth = (float)totZom / maxZom;
        progressBar.fillAmount = newWidth;
    }

    IEnumerator StartUp() { 
    
        yield return new WaitForSeconds(setupTime);
        StartCoroutine(Spawning1());
    }

    IEnumerator Spawning1() {

        tilNextZom = Random.Range(30, 40);
        randomSpawn = Random.Range(0, spawnPoints.Count);

        GameObject zombie = Instantiate(zombiePre, spawnPoints[randomSpawn].position, spawnPoints[randomSpawn].rotation);

        yield return new WaitForSeconds(tilNextZom);


        if (totZom > 0 && totZom > 45){

            totZom--;
            float newWidth = (float)totZom / maxZom;
            progressBar.fillAmount = newWidth;
            StartCoroutine(Spawning1());
        }
        else if (totZom > 0 && totZom <= 45){

            Debug.Log("2");
            StartCoroutine(Spawning2());
        }
        
    }

    IEnumerator Spawning2(){

        tilNextZom = Random.Range(20, 30);
        randomSpawn = Random.Range(0, spawnPoints.Count);

        GameObject zombie = Instantiate(zombiePre, spawnPoints[randomSpawn].position, spawnPoints[randomSpawn].rotation);

        yield return new WaitForSeconds(tilNextZom);


        if (totZom > 0 && totZom != 25){

            totZom--;
            float newWidth = (float)totZom / maxZom;
            progressBar.fillAmount = newWidth;
            StartCoroutine(Spawning2());
        }
        else if (totZom > 0 && totZom == 25){

            waveSize = Random.Range(5, 10);
            StartCoroutine(Wave());
        }
        else if (totZom == 0){

            waveSize = Random.Range(20, 30);
            finalWave = true;
            StartCoroutine(Wave());
        }
    }

    IEnumerator Wave() {

        randomSpawn = Random.Range(0, spawnPoints.Count);
        GameObject zombie = Instantiate(zombiePre, spawnPoints[randomSpawn].position, spawnPoints[randomSpawn].rotation);
        yield return new WaitForSeconds(3);
        Debug.Log("wave" + waveSize);
        if (waveSize > 0){

            waveSize--;
            StartCoroutine(Wave());
        }
        else if (waveSize == 0 && finalWave == false) {

            totZom--;
            float newWidth = (float)totZom / maxZom;
            progressBar.fillAmount = newWidth;
            StartCoroutine(Spawning2());
        }
        else if (waveSize == 0 && finalWave == true){

            Debug.Log("win");
        }
    }
}
