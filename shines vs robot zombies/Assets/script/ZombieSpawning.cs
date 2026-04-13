using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ZombieSpawning : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] int totZom = 40;
    public int maxZom = 40;
    [SerializeField] List<GameObject> zombiePre;
    [SerializeField] Image progressBar;
    public float tilNextZom;
    public int randomSpawn;
    public int setupTime;
    public int waveSize;
    public int randomZom;
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

        GameObject zombie = Instantiate(zombiePre[0], spawnPoints[randomSpawn].position, spawnPoints[randomSpawn].rotation);

        yield return new WaitForSeconds(tilNextZom);


        if (totZom > 0 && totZom > 35){

            totZom--;
            float newWidth = (float)totZom / maxZom;
            progressBar.fillAmount = newWidth;
            StartCoroutine(Spawning1());
        }
        else if (totZom > 0 && totZom <= 35){

            Debug.Log("2");
            StartCoroutine(Spawning2());
        }
        
    }

    IEnumerator Spawning2(){

        tilNextZom = Random.Range(20, 30);
        randomSpawn = Random.Range(0, spawnPoints.Count);
        randomZom = Random.Range(0, 2);
        GameObject zombie = Instantiate(zombiePre[randomZom], spawnPoints[randomSpawn].position, spawnPoints[randomSpawn].rotation);

        yield return new WaitForSeconds(tilNextZom);

        if (totZom > 0 && totZom != 20){

            totZom--;
            float newWidth = (float)totZom / maxZom;
            progressBar.fillAmount = newWidth;
            StartCoroutine(Spawning2());
        }
        else if (totZom > 0 && totZom <= 20){

            waveSize = Random.Range(10, 20);
            StartCoroutine(Wave());
        }        
    }

    IEnumerator Spawning3(){

        tilNextZom = Random.Range(15, 25);
        randomSpawn = Random.Range(0, spawnPoints.Count);
        randomZom = Random.Range (0, 3);
        GameObject zombie = Instantiate(zombiePre[randomZom], spawnPoints[randomSpawn].position, spawnPoints[randomSpawn].rotation);

        yield return new WaitForSeconds(tilNextZom);


        if (totZom > 0){

            totZom--;
            float newWidth = (float)totZom / maxZom;
            progressBar.fillAmount = newWidth;
            StartCoroutine(Spawning3());
        }
        else if (totZom == 0){

            waveSize = Random.Range(20, 30);
            finalWave = true;
            StartCoroutine(Wave());
        }
    }

    IEnumerator Wave() {

        randomSpawn = Random.Range(0, spawnPoints.Count);

        if (finalWave == false){

            randomZom = Random.Range(0, 2);
        }
        else if(finalWave == true){

            randomZom = Random.Range(0, 3);
        }

        GameObject zombie = Instantiate(zombiePre[randomZom], spawnPoints[randomSpawn].position, spawnPoints[randomSpawn].rotation);
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
            StartCoroutine(Spawning3());
        }
        else if (waveSize == 0 && finalWave == true){

            levelCounter counter = FindFirstObjectByType<levelCounter>();
            counter.LevelWin();
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("startScene");
        }
    }
}
