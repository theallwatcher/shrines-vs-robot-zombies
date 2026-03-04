using UnityEngine;

public class gridTile : MonoBehaviour
{
    [SerializeField] GameObject shinePrefab;
    [SerializeField] Transform spawnPoint;
    player player;
    GameObject shrineSpawn;
    shrine shrine;
    public bool canPlaceShrines = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        player = FindFirstObjectByType<player>();

    }

    // Update is called once per frame
    void Update(){
        
    }

    public void OnMouseUpAsButton(){

        if (canPlaceShrines == true){

            Debug.Log("test");
            shrineSpawn = Instantiate(player.shrines[0], spawnPoint.position, spawnPoint.rotation);
            shrineSpawn.GetComponent<shrine>().LinkShrine(this);
            canPlaceShrines = false;
        }
    }

   
}

