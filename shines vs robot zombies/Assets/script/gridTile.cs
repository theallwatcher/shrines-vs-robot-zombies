using UnityEngine;

public class gridTile : MonoBehaviour
{
    [SerializeField] GameObject shinePrefab;
    [SerializeField] Transform spawnPoint;
    player player;
    inventory inventory;
    GameObject shrineSpawn;
    shrine shrine;
    public bool canPlaceShrines = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        player = FindFirstObjectByType<player>();
        inventory = FindFirstObjectByType<inventory>();

    }

    // Update is called once per frame
    void Update(){
        
    }

    public void OnMouseUpAsButton(){

        if (canPlaceShrines == true){

            bool noTimeOut = inventory.TimeOutCheck(player.curSelectShrine);

            if (noTimeOut == true){

                bool enoughSkyShards = inventory.CheckSkyShards(inventory.skyShardsCost[player.curSelectShrine]);

                if (enoughSkyShards == true){

                    Debug.Log("test");
                    shrineSpawn = Instantiate(player.shrines[player.curSelectShrine], spawnPoint.position, spawnPoint.rotation);
                    shrineSpawn.GetComponent<shrine>().LinkShrine(this);
                    canPlaceShrines = false;
                    inventory.ActivteTimeOut(player.curSelectShrine);
                }
            }
        }
    }
}

