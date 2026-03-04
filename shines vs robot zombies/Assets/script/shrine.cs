using System.Collections;
using UnityEngine;

public class shrine : MonoBehaviour
{

    gridTile _tile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(KYS());
    }

    IEnumerator KYS() {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    public void LinkShrine(gridTile tile)
    {
        _tile = tile;
    }

    private void OnDestroy()
    {
        _tile.canPlaceShrines = true;
    }
}