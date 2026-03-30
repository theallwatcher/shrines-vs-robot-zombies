using System.Collections.Generic;
using UnityEngine;

public class levelOpener : MonoBehaviour
{
    levelCounter counter;
    [SerializeField] List<GameObject> buttons;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){

        counter = FindFirstObjectByType<levelCounter>();
        Open();
    }


    private void Open() {

        int count = counter.level;

        if (count >= 0) {

            buttons[0].SetActive(true);
        }

        if (count >= 1) {
        
            buttons[1].SetActive(true);
        }
    }
}
