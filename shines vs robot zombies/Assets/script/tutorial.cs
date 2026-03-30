using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class tutorial : MonoBehaviour
{
    [SerializeField] gridTile tile;
    bool firstTime = true;
    bool s2 = false;
    [SerializeField] skyShard shard;
    [SerializeField] GameObject text1;
    [SerializeField] GameObject text2;
    [SerializeField] GameObject text3;
    [SerializeField] GameObject text4;
    [SerializeField] GameObject skyShardTut;

    [Header("zombies")]
    [SerializeField] GameObject zombiePre;
    [SerializeField] GameObject zombieTut;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Image progressBar;

    public int totZom;
    public int maxZom;
    public int tilNextZom;
    public int waveSize = 3;

    // Update is called once per frame
    void Update(){

        if (firstTime == true && tile.canPlaceShrines == false) { 
        
            firstTime = false;
            Stage1();
        }

        if (shard == null && s2 == false) {

            s2 = true;
            Stage2();
        }

        if (zombieTut == null && totZom == maxZom ){

            totZom--;
            Stage3();
        }
    }

    public void Stage1() {
    
        text1.SetActive(false);
        skyShardTut.SetActive(true);
        text2.SetActive(true);
    }

    public void Stage2() {

        text2.SetActive(false);
        text3.SetActive(true);
        text4.SetActive(true);
        zombieTut.SetActive(true);
        Debug.Log("stage2");
    }

    public void Stage3() { 
    
        text3.SetActive(false);
        text4.SetActive(false);
        StartCoroutine(Spawning1());
        inventory i = FindFirstObjectByType<inventory>();
        StartCoroutine(i.SkyShardSpawning());
    }

    IEnumerator Spawning1(){

        tilNextZom = Random.Range(30, 40);

        GameObject zombie = Instantiate(zombiePre, spawnPoint.position, spawnPoint.rotation);

        yield return new WaitForSeconds(tilNextZom);

        if (totZom > 0){

            totZom--;
            float newWidth = (float)totZom / maxZom;
            progressBar.fillAmount = newWidth;
            StartCoroutine(Spawning1());
        }
        else if (totZom == 0){

            StartCoroutine(Wave());
        }
    }

    IEnumerator Wave(){

        GameObject zombie = Instantiate(zombiePre, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(3);
        Debug.Log("wave" + waveSize);
        if (waveSize > 0){

            waveSize--;
            StartCoroutine(Wave());
        }
        else if (waveSize == 0){

            levelCounter counter = FindFirstObjectByType<levelCounter>();
            counter.LevelWin();
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("startScene");
        }
    }
}

