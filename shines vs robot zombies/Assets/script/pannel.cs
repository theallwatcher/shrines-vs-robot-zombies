using UnityEngine;

public class pannel : MonoBehaviour
{
    [SerializeField] GameObject panel;

    public void PannelOn(){

        panel.SetActive(true);
    }

    public void PannelOff() { 
        
        panel.SetActive(false); 
    }
}
