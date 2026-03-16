using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class inventory : MonoBehaviour
{
    public int skyShardsCount;
    [SerializeField] public List<int> skyShardsCost;
    [SerializeField] TextMeshProUGUI skyShardText;

    public int randomX;
    public int randomZ;
    [SerializeField] GameObject skyShardPref;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){

        UpdateText();
        StartCoroutine(SkyShardSpawning());
    }

    // Update is called once per frame
    public void UpdateText()
    {
        skyShardText.text = skyShardsCount.ToString();
    }

    public bool CheckSkyShards(int cost){

        if (cost <= skyShardsCount){

            skyShardsCount = skyShardsCount - cost;
            skyShardText.text = skyShardsCount.ToString();
            return true;
        }
        else{

            return false;
        }
    }

    IEnumerator SkyShardSpawning() {

        randomX = Random.Range(10, 35);
        randomZ = (int)Random.Range(-7.5f, 7.5f);

        Vector3 spawnPoint = new Vector3(randomX,30,randomZ);
        yield return new WaitForSeconds(1);

        GameObject skyShard = Instantiate(skyShardPref, spawnPoint, transform.rotation);
        
        StartCoroutine(SkyShardSpawning());
    }
}
