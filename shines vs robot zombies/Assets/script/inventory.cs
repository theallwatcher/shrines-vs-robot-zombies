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

    public bool s0 = true;
    public bool s1 = true;
    public bool s2 = true;

    public bool paused = false;
    public bool godMode = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){

        UpdateText();
        StartCoroutine(SkyShardSpawning());
    }

    // Update is called once per frame
    public void UpdateText(){

        skyShardText.text = skyShardsCount.ToString();
    }

    public bool CheckSkyShards(int cost){

        if (godMode == false){

            if (cost <= skyShardsCount){

                skyShardsCount = skyShardsCount - cost;
                skyShardText.text = skyShardsCount.ToString();
                return true;
            }
            else{

                return false;
            }
        }
        else {

            return true;
        }
    }

    public bool TimeOutCheck(int type) {

        if (paused == false){

            if (type == 0 && s0 == false){
                return false;
            }
            else if (type == 0 && s0 == true){
                return true;
            }
            else if (type == 1 && s1 == false){
                return false;
            }
            else if (type == 1 && s1 == true){
                return true;
            }
            else if (type == 2 && s2 == false){
                return false;
            }
            else if (type == 2 && s2 == true){
                return true;
            }
            else{
                return false;
            }
        }
        else { return false; }
    }

    public void ActivteTimeOut(int type)
    {

        if (godMode == false) { 

            if (type == 0) { StartCoroutine(S0()); }
            else if (type == 1) { StartCoroutine(S1()); }
            else if (type == 2) { StartCoroutine(S2()); }
        }
    }

    IEnumerator S0() { 
    
        s0 = false;
        yield return new WaitForSeconds(7.5f);
        s0 = true;
    }

    IEnumerator S1(){

        s1 = false;
        yield return new WaitForSeconds(7.5f);
        s1 = true;
    }

    IEnumerator S2(){

        s2 = false;
        yield return new WaitForSeconds(30);
        s2 = true;
    }

    IEnumerator SkyShardSpawning() {

        randomX = Random.Range(10, 35);
        randomZ = (int)Random.Range(-7.5f, 7.5f);

        Vector3 spawnPoint = new Vector3(randomX,30,randomZ);
        yield return new WaitForSeconds(10);

        GameObject skyShard = Instantiate(skyShardPref, spawnPoint, transform.rotation);
        
        StartCoroutine(SkyShardSpawning());
    }
}
